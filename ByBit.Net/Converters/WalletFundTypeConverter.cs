using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using System.Collections.Generic;

namespace Bybit.Net.Converters
{
    internal class WalletFundTypeConverter : BaseConverter<WalletFundType>
    {
        public WalletFundTypeConverter() : this(true) { }
        public WalletFundTypeConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<WalletFundType, string>> Mapping => new List<KeyValuePair<WalletFundType, string>>
        {
            new KeyValuePair<WalletFundType, string>(WalletFundType.Deposit, "Deposit"),
            new KeyValuePair<WalletFundType, string>(WalletFundType.Withdrawal, "Withdrawal"),
            new KeyValuePair<WalletFundType, string>(WalletFundType.RealizedPnl, "RealisedPNL"),
            new KeyValuePair<WalletFundType, string>(WalletFundType.Commission, "Commission"),
            new KeyValuePair<WalletFundType, string>(WalletFundType.Refund, "Refund"),
            new KeyValuePair<WalletFundType, string>(WalletFundType.Prize, "Prize"),
            new KeyValuePair<WalletFundType, string>(WalletFundType.ExchangeOrderWithdraw, "ExchangeOrderWithdraw"),
            new KeyValuePair<WalletFundType, string>(WalletFundType.ExchangeOrderDeposit, "ExchangeOrderDeposit"),
            new KeyValuePair<WalletFundType, string>(WalletFundType.ReturnServiceCash, "ReturnServiceCash"),
            new KeyValuePair<WalletFundType, string>(WalletFundType.Insurance, "Insurance"),
            new KeyValuePair<WalletFundType, string>(WalletFundType.SubMember, "SubMember"),
            new KeyValuePair<WalletFundType, string>(WalletFundType.Coupon, "Coupon"),
            new KeyValuePair<WalletFundType, string>(WalletFundType.AccountTransfer, "AccountTransfer"),
            new KeyValuePair<WalletFundType, string>(WalletFundType.Cashback, "CashBack"),
        };
    }
}
