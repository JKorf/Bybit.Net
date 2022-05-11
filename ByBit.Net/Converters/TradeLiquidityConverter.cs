using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using System.Collections.Generic;

namespace Bybit.Net.Converters
{
    internal class TradeLiquidityConverter : BaseConverter<TradeLiquidity>
    {
        public TradeLiquidityConverter() : this(true) { }
        public TradeLiquidityConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<TradeLiquidity, string>> Mapping => new List<KeyValuePair<TradeLiquidity, string>>
        {
            new KeyValuePair<TradeLiquidity, string>(TradeLiquidity.Maker, "AddedLiquidity"),
            new KeyValuePair<TradeLiquidity, string>(TradeLiquidity.Taker, "RemovedLiquidity"),
            new KeyValuePair<TradeLiquidity, string>(TradeLiquidity.Other, "LiquidityIndNA"),
        };
    }
}
