using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Auction phase
    /// </summary>
    [JsonConverter(typeof(EnumConverter<AuctionPhase>))]
    public enum AuctionPhase
    {
        /// <summary>
        /// Not started
        /// </summary>
        [Map("NotStarted")]
        NotStarted,
        /// <summary>
        /// Pre-market trading is finished
        /// </summary>
        [Map("Finished")]
        Finished,
        /// <summary>
        /// Auction phase of pre-market trading<br/>
        /// - only timeInForce=GTC, orderType=Limit order is allowed to submit<br/>
        /// - TP/SL are not supported; Conditional orders are not supported<br/>
        /// - cannot modify the order at this stage<br/>
        /// - order price range: [preOpenPrice x 0.5, maxPrice]
        /// </summary>
        [Map("CallAuction")]
        CallAuction,
        /// <summary>
        /// Auction no cancel phase of pre-market trading<br/>
        /// only timeInForce=GTC, orderType=Limit order is allowed to submit<br/>
        /// TP/SL are not supported; Conditional orders are not supported<br/>
        /// cannot modify and cancel the order at this stage<br/>
        /// order price range: Buy [lastPrice x 0.5, markPrice x 1.1], Sell [markPrice x 0.9, maxPrice]
        /// </summary>
        [Map("CallAuctionNoCancel")]
        CallAuctionNoCancel,
        /// <summary>
        /// cross matching phase<br/>
        /// cannot create, modify and cancel the order at this stage<br/>
        /// Candle data is released from this stage
        /// </summary>
        [Map("CrossMatching")]
        CrossMatching,
        /// <summary>
        /// Continuous trading phase<br/>
        /// There is no restriction to create, amend, cancel orders<br/>
        /// orderbook, public trade data is released from this stage
        /// </summary>
        [Map("ContinuousTrading")]
        ContinuousTrading,
    }
}
