using System;
using System.Collections.Generic;
using DaraDaraM2M.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Net.WebSockets;
using System.Text;

namespace DaraDaraM2M.Protocols
{
	public class OM2MWSClient
	{
		public OM2MWSClient(string serverUrl)
		{
			ServerUrl = serverUrl;
		}

		private async Task MainProcess()
		{
			var data = new byte[64 * 1024];
			var buffer = new ArraySegment<byte>(data);

			while (WebSocket.State == WebSocketState.Open)
			{
				var r = await WebSocket.ReceiveAsync(buffer, CancellationToken.None);
				try
				{
					var text = Encoding.UTF8.GetString(data, 0, r.Count);

					var msg = OM2MJsonSerializer.Deserialize(text);

					if (msg is OM2MResponsePrimitive)
					{
						var response = msg as OM2MResponsePrimitive;
						TaskCompletionSource<OM2MResponsePrimitive> tcs;
						lock (m_responseWaiters)
						{
							if (m_responseWaiters.TryGetValue(response.RequestIdentifier, out tcs))
							{
								m_responseWaiters.Remove(response.RequestIdentifier);
							}
							else
							{
								continue;
							}
						}
						tcs.SetResult(response);
					}
					else if (msg is OM2MRequestPrimitive)
					{
						m_recieveQueue.Enqueue(msg as OM2MRequestPrimitive);
					}
				}
				catch (Exception ex)
				{
					Console.Error.WriteLine(ex);
				}
			}
		}

		public async Task ConnectAsync()
		{
			WebSocket = new ClientWebSocket();
			await WebSocket.ConnectAsync(new Uri(ServerUrl), CancellationToken.None);

			m_mainTask = Task.WhenAll(MainProcess());
		}

		public async Task CloseAsync()
		{
			await WebSocket.CloseAsync(WebSocketCloseStatus.Empty,
			                           "", CancellationToken.None);
			WebSocket = null;
			try
			{
				m_mainTask.Wait();
			}
			catch
			{
			}

			m_mainTask = null;
		}

		public async Task<OM2MResponsePrimitive> SendBlockingRequestAsync(OM2MRequestPrimitive request)
		{
			var text = OM2MJsonSerializer.Serialize(request);
			var data = Encoding.UTF8.GetBytes(text);
			var buffer = new ArraySegment<byte>(data);

			var tcs = new TaskCompletionSource<OM2MResponsePrimitive>();

			lock(m_responseWaiters)
			{
				m_responseWaiters.Add(request.RequestIdentifier, tcs);
			}

			await WebSocket.SendAsync(buffer, WebSocketMessageType.Text,
								true, CancellationToken.None);

			// Wait for response
			await tcs.Task;

			return tcs.Task.Result;
		}

		public Task<OM2MRequestPrimitive> RecieveRequestAsync(CancellationToken cancellationToken)
		{
			return m_recieveQueue.DequeueAsync(cancellationToken);
		}

		public async Task SendResponseAsync(OM2MResponsePrimitive response)
		{
			var text = OM2MJsonSerializer.Serialize(response);
			var data = Encoding.UTF8.GetBytes(text);
			var buffer = new ArraySegment<byte>(data);

			await WebSocket.SendAsync(buffer, WebSocketMessageType.Text,
								true, CancellationToken.None);
		}

		public string ServerUrl
		{
			get;
			private set;
		}

		public ClientWebSocket WebSocket
		{
			get;
			private set;
		}

		private Task m_mainTask;

		private Dictionary<string, TaskCompletionSource<OM2MResponsePrimitive>> m_responseWaiters =
			new Dictionary<string, TaskCompletionSource<OM2MResponsePrimitive>>();
			
		private AsyncQueue<OM2MRequestPrimitive> m_recieveQueue = new AsyncQueue<OM2MRequestPrimitive>();
	}

	public class AsyncQueue<T>
	{
		public Task<T> DequeueAsync(CancellationToken cancellationToken)
		{
			var tcs = new TaskCompletionSource<T>();

			lock (m_lock)
			{
				if (m_queue.Count > 0)
				{
					tcs.SetResult(m_queue.Dequeue());
				}
				else
				{
					m_waiter.Enqueue(tcs);
				}
			}

			return tcs.Task;
		}

		public void Enqueue(T value)
		{
			lock(m_lock)
			{
				if (m_waiter.Count > 0)
				{
					var waiter = m_waiter.Dequeue();
					waiter.SetResult(value);
				}
				else
				{
					m_queue.Enqueue(value);
				}
			}
		}

		private object m_lock = new object();
		private Queue<T> m_queue = new Queue<T>();
		private Queue<TaskCompletionSource<T>> m_waiter = new Queue<TaskCompletionSource<T>>();
	}
}
