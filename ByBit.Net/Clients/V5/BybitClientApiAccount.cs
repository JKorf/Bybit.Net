using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using CryptoExchange.Net.Objects;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;

namespace Bybit.Net.Clients.V5
{
    public class BybitClientApiAccount
    {
        private BybitClientApi _baseClient;

        internal BybitClientApiAccount(BybitClientApi baseClient)
        {
            _baseClient = baseClient;
        }

    }
}
