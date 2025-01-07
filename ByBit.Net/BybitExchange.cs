﻿using Bybit.Net.Enums;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.RateLimiting;
using CryptoExchange.Net.RateLimiting.Filters;
using CryptoExchange.Net.RateLimiting.Guards;
using CryptoExchange.Net.RateLimiting.Interfaces;
using CryptoExchange.Net.SharedApis;
using System;
using System.Collections.Generic;

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
        /// Format a base and quote asset to a Bybit recognized symbol 
        /// </summary>
        /// <param name="baseAsset">Base asset</param>
        /// <param name="quoteAsset">Quote asset</param>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="deliverTime">Delivery time for delivery futures</param>
        /// <returns></returns>
        public static string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
        {
            if (tradingMode == TradingMode.Spot)
                return baseAsset.ToUpperInvariant() + quoteAsset.ToUpperInvariant();

            if (tradingMode.IsLinear())
            {
                if (tradingMode.IsPerpetual())
                {
                    if (quoteAsset == "USDC")
                        return baseAsset + "PERP";

                    return baseAsset.ToUpperInvariant() + quoteAsset.ToUpperInvariant();
                }

                return baseAsset.ToUpperInvariant() + "-" + deliverTime!.Value.ToString("ddMMMyy").ToUpperInvariant();
            }

            return baseAsset.ToUpperInvariant() + quoteAsset.ToUpperInvariant() + (deliverTime == null ? string.Empty : (ExchangeHelpers.GetDeliveryMonthSymbol(deliverTime.Value) + deliverTime.Value.ToString("yy")));
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
        private static Dictionary<RateLimitTier, (int limitOther, int limitSpot)> _orderTierLimits = new Dictionary<RateLimitTier, (int, int)>()
        {
            { RateLimitTier.Default, (10, 20) },
            { RateLimitTier.Vip1, (20, 25) },
            { RateLimitTier.Vip2, (40, 30) },
            { RateLimitTier.Vip3, (60, 40) },
            { RateLimitTier.Vip4, (60, 40) },
            { RateLimitTier.Vip5, (60, 40) },
            { RateLimitTier.VipSupreme, (60, 40) },
            { RateLimitTier.Pro1, (150, 150) },
            { RateLimitTier.Pro2, (200, 200) },
            { RateLimitTier.Pro3, (250, 250) },
            { RateLimitTier.Pro4, (300, 300) },
            { RateLimitTier.Pro5, (300, 300) },
            { RateLimitTier.Pro6, (300, 300) }
        };

        /// <summary>
        /// Event for when a rate limit is triggered
        /// </summary>
        public event Action<RateLimitEvent> RateLimitTriggered;

        /// <summary>
        /// The Tier to use when calculating rate limits
        /// </summary>
        public RateLimitTier Tier { get; private set; } = RateLimitTier.Default;

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
        public void Configure(RateLimitTier tier)
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
            BybitSocket.RateLimitTriggered += (x) => RateLimitTriggered?.Invoke(x);
        }


        internal IRateLimitGate BybitRest { get; private set; }
        internal IRateLimitGate BybitSocket { get; private set; }

    }
}
