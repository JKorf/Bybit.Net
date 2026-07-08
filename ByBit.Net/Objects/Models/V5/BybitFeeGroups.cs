using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bybit.Net.Objects.Models.V5
{
    /// <summary>
    /// Fee group info
    /// </summary>
    public record BybitFeeGroup
    {
        /// <summary>
        /// ["<c>groupName</c>"] Group name
        /// </summary>
        [JsonPropertyName("groupName")]
        public string GroupName { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>weightingFactor</c>"] Weight factor
        /// </summary>
        [JsonPropertyName("weightingFactor")]
        public decimal WeightFactor { get; set; }
        /// <summary>
        /// ["<c>symbolsNumbers</c>"] Number of symbols
        /// </summary>
        [JsonPropertyName("symbolsNumbers")]
        public int SymbolCount { get; set; }
        /// <summary>
        /// ["<c>symbols</c>"] Symbols
        /// </summary>
        [JsonPropertyName("symbols")]
        public string[] Symbols { get; set; } = [];
        /// <summary>
        /// ["<c>updateTime</c>"] Update time
        /// </summary>
        [JsonPropertyName("updateTime")]
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// ["<c>feeRates</c>"] Update time
        /// </summary>
        [JsonPropertyName("feeRates")]
        public BybitFeeGroupRates FeeRates { get; set; } = default!;
    }

    /// <summary>
    /// Fee group rates
    /// </summary>
    public record BybitFeeGroupRates
    {
        /// <summary>
        /// ["<c>pro</c>"] Pro-level fee structures
        /// </summary>
        [JsonPropertyName("pro")]
        public BybitFeeGroupRate[] Pro { get; set; } = default!;
        /// <summary>
        /// ["<c>marketMaker</c>"] Market maker fee structures
        /// </summary>
        [JsonPropertyName("marketMaker")]
        public BybitFeeGroupRate[] MarketMaker { get; set; } = default!;
    }

    /// <summary>
    /// Fee group rate info
    /// </summary>
    public record BybitFeeGroupRate
    {
        /// <summary>
        /// ["<c>level</c>"] Level
        /// </summary>
        [JsonPropertyName("level")]
        public string Level { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>takerFeeRate</c>"] Taker fee rate
        /// </summary>
        [JsonPropertyName("takerFeeRate")]
        public decimal TakerFeeRate { get; set; }
        /// <summary>
        /// ["<c>makerFeeRate</c>"] Maker fee rate
        /// </summary>
        [JsonPropertyName("makerFeeRate")]
        public decimal MakerFeeRate { get; set; }
        /// <summary>
        /// ["<c>makerRebate</c>"] Maker rebate
        /// </summary>
        [JsonPropertyName("makerRebate")]
        public decimal? MakerRebate { get; set; }
    }
}
