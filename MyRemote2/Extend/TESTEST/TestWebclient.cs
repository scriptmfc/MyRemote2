using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyRemote2.Extend.TESTEST
{
    public static class TestWebclient
    {
        static readonly string scriptname = "ConnectWebSocket";

        internal static ClientWebSocket _webSocket;

        private static readonly string url = "ws://localhost:8080/";

        public static async Task Connect()
        {
            _webSocket = new ClientWebSocket();
            consoleUtil.ConsoleW($"UTILWebSocketClient Connect Try...{url}", scriptname);
            await _webSocket.ConnectAsync(new Uri(url), CancellationToken.None);
            consoleUtil.ConsoleW($"UTILWebSocketClient Connect Success!", scriptname);
        }

        public static async Task SendMessage(string message)
        {
            if (_webSocket.State != WebSocketState.Open)
            {
                throw new InvalidOperationException("WebSocket connection is not open.");
            }

            var buffer = new ArraySegment<byte>(System.Text.Encoding.UTF8.GetBytes(message));
            await _webSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
        }

        public static async Task<string> ReceiveMessage()
        {
            if (_webSocket.State != WebSocketState.Open)
            {
                throw new InvalidOperationException("WebSocket connection is not open.");
            }

            var buffer = new ArraySegment<byte>(new byte[4096]);
            var result = await _webSocket.ReceiveAsync(buffer, CancellationToken.None);
            var receivedMessage = System.Text.Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
            return receivedMessage;
        }

        public static async Task CloseConnection()
        {
            if (_webSocket.State == WebSocketState.Open || _webSocket.State == WebSocketState.CloseReceived)
            {
                await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing WebSocket connection.", CancellationToken.None);
            }
        }

        public static WebSocketState CheckStatus()
        {
            WebSocketState result=WebSocketState.None;

            if (_webSocket != null)
            {
                result = _webSocket.State;
            }

            return result;
        }
    }
}
