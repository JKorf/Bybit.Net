using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.RateLimiting;
using CryptoExchange.Net.RateLimiting.Filters;
using CryptoExchange.Net.RateLimiting.Guards;
using CryptoExchange.Net.RateLimiting.Interfaces;
using CryptoExchange.Net.SharedApis;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bybit.Net
{
    /// <summary>
    /// Bybit exchange information and configuration
    /// </summary>
    public static class BybitExchange
    {
        /// <summary>
        /// Exchange name
        /// </summary>
        public static string ExchangeName => "Bybit";

        /// <summary>
        /// Exchange name
        /// </summary>
        public static string DisplayName => "Bybit";

        /// <summary>
        /// Url to exchange image
        /// </summary>
        public static string ImageUrl { get; } = "https://raw.githubusercontent.com/JKorf/Bybit.Net/master/ByBit.Net/Icon/icon.png";

        /// <summary>
        /// Url to the main website
        /// </summary>
        public static string Url { get; } = "https://www.bybit.com";

        /// <summary>
        /// Urls to the API documentation
        /// </summary>
        public static string[] ApiDocsUrl { get; } = new[] {
            "https://bybit-exchange.github.io/docs/v5/intro"
            };

        /// <summary>
        /// Type of exchange
        /// </summary>
        public static ExchangeType Type { get; } = ExchangeType.CEX;

        internal static JsonSerializerContext _serializerContext = JsonSerializerContextCache.GetOrCreate<BybitSourceGenerationContext>();

        /// <summary>
        /// Aliases for Bybit assets
        /// </summary>
        public static AssetAliasConfiguration AssetAliases { get; } = new AssetAliasConfiguration
        {
            Aliases = [
                new AssetAlias("USDT", SharedSymbol.UsdOrStable.ToUpperInvariant(), AliasType.OnlyToExchange)
            ]
        };
        
        /// <summary>
        /// Format a base and quote asset to a Bybit recognized symbol 
        /// </summary>
        /// <param name="baseAsset">Base asset</param>
        /// <param name="quoteAsset">Quote asset</param>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="deliverTime">Delivery time for delivery futures</param>
        /// <returns></returns>
        public static string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
        {
            baseAsset = AssetAliases.CommonToExchangeName(baseAsset.ToUpperInvariant());
            quoteAsset = AssetAliases.CommonToExchangeName(quoteAsset.ToUpperInvariant());

            if (tradingMode == TradingMode.Spot)
                return baseAsset + quoteAsset;

            if (tradingMode.IsLinear())
            {
                if (tradingMode.IsPerpetual())
                {
                    if (quoteAsset == "USDC")
                        return baseAsset + "PERP";

                    return baseAsset + quoteAsset;
                }

                return baseAsset + "-" + deliverTime!.Value.ToString("ddMMMyy");
            }

            return baseAsset + quoteAsset + (deliverTime == null ? string.Empty : (ExchangeHelpers.GetDeliveryMonthSymbol(deliverTime.Value) + deliverTime.Value.ToString("yy")));
        }

        /// <summary>
        /// Rate limiter configuration for the Bybit API
        /// </summary>
        public static BybitRateLimiters RateLimiter { get; } = new BybitRateLimiters();
    }

    /// <summary>
    /// Rate limiter configuration for the Bybit API
    /// </summary>
    public class BybitRateLimiters
    {
        private static Dictionary<AccountLevel, (int limitOther, int limitSpot)> _orderTierLimits = new Dictionary<AccountLevel, (int, int)>()
        {
            { AccountLevel.Default, (10, 20) },
            { AccountLevel.Vip1, (20, 25) },
            { AccountLevel.Vip2, (40, 30) },
            { AccountLevel.Vip3, (60, 40) },
            { AccountLevel.Vip4, (60, 40) },
            { AccountLevel.Vip5, (60, 40) },
            { AccountLevel.VipSupreme, (60, 40) },
            { AccountLevel.Pro1, (150, 150) },
            { AccountLevel.Pro2, (200, 200) },
            { AccountLevel.Pro3, (250, 250) },
            { AccountLevel.Pro4, (300, 300) },
            { AccountLevel.Pro5, (300, 300) },
            { AccountLevel.Pro6, (300, 300) }
        };

        /// <summary>
        /// Event for when a rate limit is triggered
        /// </summary>
        public event Action<RateLimitEvent> RateLimitTriggered;

        /// <summary>
        /// Event when the rate limit is updated. Note that it's only updated when a request is send, so there are no specific updates when the current usage is decaying.
        /// </summary>
        public event Action<RateLimitUpdateEvent> RateLimitUpdated;

        /// <summary>
        /// The Tier to use when calculating rate limits
        /// </summary>
        public AccountLevel Tier { get; private set; } = AccountLevel.Default;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        internal BybitRateLimiters()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            Initialize();
        }

        internal (int limitSpot, int limitOther) GetOrderLimits()
        {
            var limits = _orderTierLimits[Tier];
            return (limits.limitSpot, limits.limitOther);
        }

        /// <summary>
        /// Configure the rate limit with a different tier
        /// </summary>
        /// <param name="tier"></param>
        public void Configure(AccountLevel tier)
        {
            Tier = tier;
            Initialize();
        }

        private void Initialize()
        {
            BybitRest = new RateLimitGate("Bybit Rest")
                .AddGuard(new RateLimitGuard(RateLimitGuard.PerHost, Array.Empty<IGuardFilter>(), 600, TimeSpan.FromSeconds(5), RateLimitWindowType.Sliding)); // 600 requests per 5 seconds
            BybitSocket = new RateLimitGate("Bybit Socket")
                .AddGuard(new RateLimitGuard(RateLimitGuard.PerHost, [new LimitItemTypeFilter(RateLimitItemType.Connection)], 500, TimeSpan.FromMinutes(5), RateLimitWindowType.Sliding)); // 500 connections per 5 minutes
            BybitRest.RateLimitTriggered += (x) => RateLimitTriggered?.Invoke(x);
            BybitRest.RateLimitUpdated += (x) => RateLimitUpdated?.Invoke(x);
            BybitSocket.RateLimitTriggered += (x) => RateLimitTriggered?.Invoke(x);
            BybitSocket.RateLimitUpdated += (x) => RateLimitUpdated?.Invoke(x);
        }


        internal IRateLimitGate BybitRest { get; private set; }
        internal IRateLimitGate BybitSocket { get; private set; }

    }
}
