﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bybit.Net.Interfaces.Clients.V5
{
    /// <summary>
    /// Repay id
    /// </summary>
    public record BybitRepayId
    {
        /// <summary>
        /// Repay id
        /// </summary>
        [JsonPropertyName("repayId")]
        public string RepayId { get; set; } = string.Empty;
    }


}
