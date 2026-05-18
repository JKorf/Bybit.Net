using Bybit.Net.Benchmark.Server;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bybit.Net.Benchmark.Controllers
{
    [ApiController]
    [Route("")]
    public class WsController : ControllerBase
    {
        [HttpGet("v5/public/spot")]
        public async Task Get()
        {
            var webSocket = await Request.HttpContext.WebSockets.AcceptWebSocketAsync();

            var cts = new CancellationTokenSource();

            _ = Task.Run(async () =>
            {
                while (!cts.IsCancellationRequested)
                {
                    var buffer = new byte[8096];
                    var result = await webSocket.ReceiveAsync(buffer, CancellationToken.None);
                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        cts.Cancel();

                        if (webSocket.State == WebSocketState.CloseReceived)
                            await webSocket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "Closing", default).ConfigureAwait(false);
                    }
                    else
                    {
                        var data = Encoding.UTF8.GetString(buffer, 0, result.Count);
                        var msg = JsonSerializer.Deserialize<SubscribeMessage>(data)!;

                        var response = "{\"success\":true,\"ret_msg\":\"\",\"conn_id\":\"benchmark\",\"req_id\":\"" + msg.RequestId + "\",\"op\":\"" + msg.Operation + "\"}";
                        await SendAsync(webSocket, response);

                        if (msg.Args.Any(x => string.Equals(x, "publicTrade.ETHUSDT", StringComparison.OrdinalIgnoreCase)))
                            _ = PushTradeUpdates(webSocket, cts.Token);
                    }
                }
            });

            try
            {
                await Task.Delay(-1, cts.Token);
            }
            catch (Exception) { }
        }

        private async Task SendAsync(WebSocket webSocket, string message)
        {
            await webSocket.SendAsync(Encoding.UTF8.GetBytes(message),
                WebSocketMessageType.Text,
                endOfMessage: true,
                CancellationToken.None);
        }

        private async Task SendAsync(WebSocket webSocket, byte[] data)
        {
            await webSocket.SendAsync(data,
                WebSocketMessageType.Text,
                endOfMessage: true,
                CancellationToken.None);
        }

        private async Task PushTradeUpdates(WebSocket webSocket, CancellationToken ct)
        {
            var time = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds;
            for (var i = 0; i < 1_000_000; i++)
            {
                if (ct.IsCancellationRequested)
                    break;

                var trade = "{\"topic\":\"publicTrade.ETHUSDT\",\"type\":\"snapshot\",\"ts\":" + time + ",\"data\":[{\"T\":" + time + ",\"s\":\"ETHUSDT\",\"S\":\"Buy\",\"v\":\"0.00170000\",\"p\":\"3187.96000000\",\"L\":\"PlusTick\",\"i\":\"" + (5000000000L + i) + "\",\"BT\":false,\"RPI\":false,\"seq\":" + i + "}]}";
                await SendAsync(webSocket, Encoding.UTF8.GetBytes(trade));
            }

            try
            {
                await Task.Delay(5000, ct);
            }
            catch (Exception) { }
        }
    }

    public record SubscribeMessage
    {
        [JsonPropertyName("req_id")]
        [JsonConverter(typeof(AutoNumberToStringConverter))]
        public string RequestId { get; set; } = string.Empty;

        [JsonPropertyName("op")]
        public string Operation { get; set; } = string.Empty;

        [JsonPropertyName("args")]
        public string[] Args { get; set; } = [];
    }
}
