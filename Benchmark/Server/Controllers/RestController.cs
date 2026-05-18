using Microsoft.AspNetCore.Mvc;

namespace Bybit.Net.Benchmark.Controllers
{
    [ApiController]
    [Route("v5/market")]
    public class RestController : ControllerBase
    {
        [HttpGet("time")]
        public object GetTime()
        {
            Response.ContentType = "application/json";
            return new
            {
                retCode = 0,
                retMsg = "OK",
                result = new
                {
                    timeSecond = "1763802578",
                    timeNano = "1763802578000000000"
                },
                time = 1763802578000
            };
        }

        [HttpGet("tickers")]
        public object GetTickers([FromQuery] string? symbol)
        {
            Response.ContentType = "application/json";
            return new
            {
                retCode = 0,
                retMsg = "OK",
                result = new
                {
                    category = "spot",
                    list = new[]
                    {
                        new
                        {
                            symbol = symbol ?? "ETHUSDT",
                            bid1Price = "2009.90000000",
                            bid1Size = "1.00000000",
                            ask1Price = "2010.10000000",
                            ask1Size = "1.00000000",
                            lastPrice = "2010.00000000",
                            prevPrice24h = "2000.00000000",
                            price24hPcnt = "0.005",
                            highPrice24h = "2020.00000000",
                            lowPrice24h = "1990.00000000",
                            turnover24h = "24765432.10000000",
                            volume24h = "12345.67800000",
                            usdIndexPrice = "2010.00000000"
                        }
                    }
                },
                time = 1763802578000
            };
        }
    }
}
