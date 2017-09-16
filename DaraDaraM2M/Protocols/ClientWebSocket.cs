using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net.WebSockets;
using System.Collections.Generic;
using Wss = WebSocketSharp;

namespace DaraDaraM2M.Protocols
{
	public sealed class ClientWebSocket : WebSocket
	{
		public ClientWebSocket()
		{
		}

		private Wss.WebSocket m_ws;
		private TaskCompletionSource<object> m_connectCloseTCS;
		private TaskCompletionSource<WebSocketReceiveResult> m_receiveTCS;
		private Queue<Wss.MessageEventArgs> m_receiveQueue = new Queue<Wss.MessageEventArgs>();
		private Queue<Waiter> m_waiters = new Queue<Waiter>();
		private object m_recieveLock = new object();

		class Waiter
		{
			public TaskCompletionSource<WebSocketReceiveResult> TCS;
			public ArraySegment<byte> Buffer;
		}

		private WebSocketCloseStatus? m_closeStatus;
		private string m_closeStatusDescription;
		private WebSocketState m_state = WebSocketState.Closed;
		const int MaxQueuingMessageCount = 1024;

		public override WebSocketCloseStatus? CloseStatus
		{
			get
			{
				return m_closeStatus;
			}
		}

		public override string CloseStatusDescription
		{
			get
			{
				return m_closeStatusDescription;
			}
		}

		public override WebSocketState State
		{
			get
			{
				return m_state;
			}
		}

		public override string SubProtocol
		{
			get;
		}

		public override void Abort()
		{
		}

		public Task ConnectAsync(Uri uri, CancellationToken cancellationToken)
		{
			if (m_state != WebSocketState.Closed)
			{
				throw new InvalidOperationException("Websocket is not closed.");
			}
			
			var connectTCS = new TaskCompletionSource<object>();

			try
			{
				m_state = WebSocketState.Connecting;

				m_ws = new Wss.WebSocket(uri.ToString());

				m_connectCloseTCS = connectTCS;

				m_ws.OnOpen += (sender, e) =>
				{
					var tmp = m_connectCloseTCS;
					m_connectCloseTCS = null;
					m_state = WebSocketState.Open;
					tmp.SetResult(null);
				};

				m_ws.OnClose += (sender, e) =>
				{
					var tmp = m_connectCloseTCS;
					m_connectCloseTCS = null;
					m_state = WebSocketState.Closed;
					tmp.SetResult(null);

					lock (m_recieveLock)
					{
						foreach (var w in m_waiters)
						{
							w.TCS.SetException(new WebSocketException(WebSocketNativeError_FailedToRecv));
						}
					}
				};

				m_ws.OnError += (sender, e) =>
				{
					if (m_receiveTCS != null)
					{
						var tmp = m_connectCloseTCS;
						m_connectCloseTCS = null;
						m_state = WebSocketState.Closed;
						tmp.SetResult(null);
					}

					lock (m_recieveLock)
					{
						foreach (var w in m_waiters)
						{
							w.TCS.SetException(new WebSocketException(WebSocketNativeError_FailedToRecv));
						}
					}
				};

				m_ws.OnMessage += (sender, e) =>
				{
					lock(m_recieveLock)
					{
						if (m_waiters.Count > 0)
						{
							var waiter = m_waiters.Dequeue();

							var r = new WebSocketReceiveResult(e.RawData.Length, WebSocketMessageType.Text, true);
							for (int i = 0; i < e.RawData.Length; i++)
							{
								waiter.Buffer.Array[waiter.Buffer.Offset + i] = e.RawData[i];
							}

							waiter.TCS.SetResult(r);
						}
						else if (m_receiveQueue.Count >= MaxQueuingMessageCount)
						{
							return;
						}
						else
						{
							m_receiveQueue.Enqueue(e);
						}
					}
				};

				m_ws.ConnectAsync();
			}
			catch (Exception ex)
			{
				m_state = WebSocketState.Closed;
				connectTCS.SetException(new WebSocketException(0, ex));
			}

			return connectTCS.Task;
		}

		public override Task CloseAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken)
		{
			if (m_state != WebSocketState.Open)
			{
				throw new InvalidOperationException();
			}

			var closeTCS = new TaskCompletionSource<object>();

			try
			{
				m_connectCloseTCS = closeTCS;
				m_ws.CloseAsync();
			}
			catch (Exception ex)
			{
				closeTCS.SetException(new WebSocketException(0, ex));
			}

			return closeTCS.Task;
		}

		public override Task CloseOutputAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken)
		{
			throw new NotSupportedException();
		}

		public override void Dispose()
		{
			if (m_state != WebSocketState.Closed)
			{
				Task.WaitAll(CloseAsync(WebSocketCloseStatus.Empty, "", CancellationToken.None));
			}
		}

		public override Task<WebSocketReceiveResult> ReceiveAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken)
		{
			if (m_state != WebSocketState.Open)
			{
				throw new InvalidOperationException();
			}

			var receiveTCS = new TaskCompletionSource<WebSocketReceiveResult>();
			
			lock(m_recieveLock)
			{
				if (m_state != WebSocketState.Open)
				{
					throw new InvalidOperationException();
				
				}

				if (m_receiveQueue.Count > 0)
				{
					var e = m_receiveQueue.Dequeue();
					var r = new WebSocketReceiveResult(e.RawData.Length, WebSocketMessageType.Text, true);
					for (int i = 0; i < e.RawData.Length; i++)
					{
						buffer.Array[buffer.Offset + i] = e.RawData[i];
					}
					receiveTCS.SetResult(r);
				}
				else
				{
					var w = new Waiter();
					w.TCS = receiveTCS;
					w.Buffer = buffer;
					m_waiters.Enqueue(w);
				}
			}

			return receiveTCS.Task;
		}

		public override Task SendAsync(ArraySegment<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken)
		{
			if (m_state != WebSocketState.Open)
			{
				throw new InvalidOperationException();
			}
			
			var sendTCS = new TaskCompletionSource<object>();
			var data = new byte[buffer.Count];
			for (int i = 0; i < buffer.Count; i++)
			{
				data[i] = buffer.Array[i + buffer.Offset];
			}

			try
			{
				m_ws.SendAsync(data, sent =>
				{
					if (sent)
					{
						sendTCS.SetResult(null);
					}
					else
					{
						sendTCS.SetException(new WebSocketException(WebSocketNativeError_FailedToSend));
					}
				});
			}
			catch (Exception ex)
			{
				sendTCS.SetException(new WebSocketException(WebSocketNativeError_Unknown, ex));
			}

			return sendTCS.Task;
		}

		const int WebSocketNativeError_Unknown = 0;
		const int WebSocketNativeError_FailedToSend = 1;
		const int WebSocketNativeError_FailedToRecv = 2;
	}
}
