using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Tier of account for ratelimiting purposes
    /// </summary>
    public enum RateLimitTier
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        Default,
        Vip1,
        Vip2,
        Vip3,
        Vip4,
        Vip5,
        VipSupreme,
        Pro1,
        Pro2,
        Pro3,
        Pro4,
        Pro5,
        Pro6
    }
}
