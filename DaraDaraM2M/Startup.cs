using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using DaraDaraM2M.Data;
using System.Reflection;

namespace DaraDaraM2M
{
	public class Startup
	{
		private OM2MCseConfig CseConfig
		{
			get;
			set;
		}

		private OM2MCseServiceImpl CseService
		{
			get;
			set;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole();

			CseConfig = new OM2MCseConfig();
			CseConfig.CseBaseId = "in-cse";
			CseConfig.CseBaseName = "in-cse";
			CseConfig.CseType = OM2MCseTypeID.InCSE;

			CseService = new OM2MCseServiceImpl(CseConfig);
			CseService.Initialize();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseWebSockets();

			app.Use(async (http, next) =>
			{

				string org = "guest:guest";
				Microsoft.Extensions.Primitives.StringValues vals;
				if (http.Request.Query.TryGetValue("org", out vals))
				{
					org = vals[0];
				}

				if (http.WebSockets.IsWebSocketRequest)
				{
					var webSocket = await http.WebSockets.AcceptWebSocketAsync();

					var originator = new OM2MOriginatorWebSocket(CseService, org, webSocket);
					while (webSocket.State == WebSocketState.Open)
					{
						var token = CancellationToken.None;
						var buffer = new ArraySegment<Byte>(new byte[64 * 1024]);
						var received = await webSocket.ReceiveAsync(buffer, token);

						try
						{
							switch (received.MessageType)
							{
								case WebSocketMessageType.Text:
									var message = Encoding.UTF8.GetString(buffer.Array,
																		  buffer.Offset,
																		  buffer.Count);
									await originator.ProcessMessageAsync(message);
									break;
							}
						}
						catch (Exception ex)
						{
							Console.Error.WriteLine(ex);
						}
					}
				}
				else
				{
					await next();
				}
			});

			app.Run(async (context) =>
			{
				await context.Response.WriteAsync("Hello World!");
			});
		}

		public class ResultWait<T> : IDisposable
		{
			public ResultWait()
			{
				m_event = new ManualResetEvent(false);
			}

			public void Dispose()
			{
				m_event.Dispose();
			}

			public void SetResult(T value)
			{
				m_resultValue = value;
				m_event.Set();
			}

			public T Wait(TimeSpan timeout)
			{
				if (!m_event.WaitOne(timeout))
				{
					throw new TimeoutException();
				}

				return m_resultValue;
			}

			private ManualResetEvent m_event;
			private T m_resultValue;
		}

		class OM2MOriginatorWebSocket : IOM2MOriginator
		{
			public OM2MOriginatorWebSocket(OM2MCseServiceImpl cseService, string originatorId, WebSocket webSocket)
			{
				CseService = cseService;
				OriginatorId = originatorId;
				WebSocket = webSocket;
			}

			Dictionary<string, ResultWait<OM2MResponsePrimitive>> m_waittingResponses =
				new Dictionary<string, ResultWait<OM2MResponsePrimitive>>();

			public async Task ProcessMessageAsync(string message)
			{
				var packet = OM2MJsonSerializer.Deserialize(message);
				if (packet is OM2MRequestPrimitive)
				{
					var request = packet as OM2MRequestPrimitive;

					request.From = OriginatorId;

					var response = CseService.DoBlockingRequest(request);

					await SendResponseAsync(response);
				}
				else if (packet is OM2MResponsePrimitive)
				{
					var response = packet as OM2MResponsePrimitive;
					ResultWait<OM2MResponsePrimitive> resultWait;

					if (m_waittingResponses.TryGetValue(response.RequestIdentifier, out resultWait))
					{
						resultWait.SetResult(response);
					}
				}
			}

			public async Task SendResponseAsync(OM2MResponsePrimitive response)
			{
				// Correct primitiveContent
				if (response.Content != null && response.PrimitiveContent == null)
				{
					response.PrimitiveContent = new OM2MPrimitiveContent();
					response.PrimitiveContent.Any = new List<object>();
					response.PrimitiveContent.Any.Add(response.Content);
				}
				
				var responseMessage = OM2MJsonSerializer.Serialize(response);

				var responseMessageData = Encoding.UTF8.GetBytes(responseMessage);

				ArraySegment<byte> buffer = new ArraySegment<byte>(responseMessageData);

				await WebSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
			}
			
			public void SendResponse(OM2MResponsePrimitive response)
			{
				Task.WaitAll(SendResponseAsync(response));
			}

			public OM2MResponsePrimitive SendRequest(OM2MRequestPrimitive request)
			{
				// Correct primitiveContent
				if (request.Content != null && request.PrimitiveContent == null)
				{
					request.PrimitiveContent = new OM2MPrimitiveContent();
					request.PrimitiveContent.Any = new List<object>();
					request.PrimitiveContent.Any.Add(request.Content);
				}
				
				var requestMessage = OM2MJsonSerializer.Serialize(request);

				var requestMessageData = Encoding.UTF8.GetBytes(requestMessage);

				ArraySegment<byte> buffer = new ArraySegment<byte>(requestMessageData);

				using (var resultWait = new ResultWait<OM2MResponsePrimitive>())
				{
					OM2MResponsePrimitive response;

					m_waittingResponses.Add(request.RequestIdentifier,
								 resultWait);
					try
					{
						Task.WaitAll(WebSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None));

						response = resultWait.Wait(TimeSpan.FromSeconds(30));
					}
					finally
					{
						m_waittingResponses.Remove(request.RequestIdentifier);
					}

					return response;
				}
			}

			public OM2MCseServiceImpl CseService
			{
				get;
				private set;
			}

			public string OriginatorId
			{
				get;
				private set;
			}

			public WebSocket WebSocket
			{
				get;
				private set;
			}
		}
	}
}
