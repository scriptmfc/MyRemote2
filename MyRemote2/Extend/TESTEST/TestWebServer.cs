using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyRemote2.Extend.TESTEST
{
    public static class TestWebServer
    {

        static readonly string scriptname = "WebSocketServer";
        private static HttpListener _httpListener;
        private static CancellationTokenSource _cancellationTokenSource;

        static readonly string url = "http://localhost:8080/";

        static Action<string> DoAction_WhenReceive;
        public static async Task Start()
        {
            consoleUtil.ConsoleW($"WebServer _Start", scriptname);
            _httpListener = new HttpListener();
            _httpListener.Prefixes.Add(url);
            _httpListener.Start();
            consoleUtil.ConsoleW($"{_httpListener} : _httpListener", scriptname);
            consoleUtil.ConsoleW($"{_httpListener.Prefixes} : _httpListener.Prefixes", scriptname);
            foreach (var item in _httpListener.Prefixes)
            {
                consoleUtil.ConsoleW($"{item} : _httpListener.Prefixes item", scriptname);
            }
            consoleUtil.ConsoleW($"{_httpListener.Prefixes} : _httpListener.Prefixes", scriptname);

            _cancellationTokenSource = new CancellationTokenSource();
            consoleUtil.ConsoleW($"{_cancellationTokenSource} : _cancellationTokenSource", scriptname);
            while (_httpListener.IsListening)
            {
                consoleUtil.ConsoleW($"_httpListener.IsListening 진입 성공", scriptname);
                var context = await _httpListener.GetContextAsync();

                consoleUtil.ConsoleW($"{context} : context", scriptname);


                if (context.Request.IsWebSocketRequest)
                {
                    HandleWebSocketRequest(context);
                }
                else
                {
                    context.Response.StatusCode = 400;
                    context.Response.Close();
                }
            }
        }

        private static async void HandleWebSocketRequest(HttpListenerContext context)
        {
            try
            {
                HttpListenerWebSocketContext webSocketContext = await context.AcceptWebSocketAsync(subProtocol: null);


                // WebSocket 연결이 수립되었을 때 수행할 로직을 작성합니다.
                // 클라이언트와의 메시지 송수신, 연결 상태 확인 등을 구현할 수 있습니다.
                Console.WriteLine($"{webSocketContext.WebSocket}[WebSocket] : 연결됨");
                await WebSocketCommunicationLoop(webSocketContext.WebSocket);
            }
            catch (Exception ex)
            {
                // 예외 처리
            }
        }

        private static async Task WebSocketCommunicationLoop(System.Net.WebSockets.WebSocket webSocket)
        {
            var buffer = new byte[4096];

            while (webSocket.State == WebSocketState.Open)
            {
                var receiveResult = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                if (receiveResult.MessageType == WebSocketMessageType.Close)
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                }
                else
                {
                    string receivedMessage = Encoding.UTF8.GetString(buffer, 0, receiveResult.Count);
                    DoAction_WhenReceive?.Invoke(receivedMessage);
                    consoleUtil.ConsoleW($"{receivedMessage} : 을 클라이언트에서 받아서 서버에서 수행합니다.", scriptname);
                    // 클라이언트로부터 메시지를 받았을 때 수행할 로직을 작성합니다.
                    // 받은 메시지에 대한 처리, 클라이언트에게 응답 메시지 전송 등을 구현할 수 있습니다.
                }
            }
        }

        public static void Stop()
        {
            _cancellationTokenSource?.Cancel();
            _httpListener?.Stop();
            _httpListener?.Close();
        }
        public static void SettingReceiveAction(Action<string> action)
        {
            DoAction_WhenReceive = action;
        }

        public static async Task<string> CheckStatusAsync()
        {
            string result = "";

            if (_httpListener != null && _httpListener.IsListening)
            {
                Console.WriteLine("WebSocket server is running.");
                var context = await _httpListener.GetContextAsync();
                HttpListenerWebSocketContext webSocketContext = await context.AcceptWebSocketAsync(subProtocol: null);


                Console.WriteLine("Connected clients:");
                result += "\r\nWebSocket server is running.";
                result += "\r\nConnected clients:";
                result += $"\r\n{webSocketContext.WebSocket}";

                //foreach (var context in _httpListener.GetContext())
                //{
                //if (context.Request.IsWebSocketRequest && context.Response.IsClientConnected)
                //{
                //Console.WriteLine($"{context.Request.RemoteEndPoint} - Connected");
                //}
                //}
            }
            else
            {
                result += "\r\nWebSocket server is not running.";
                Console.WriteLine("WebSocket server is not running.");
            }

            return result;
        }


    }
}
