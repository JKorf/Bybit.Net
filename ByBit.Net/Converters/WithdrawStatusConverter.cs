using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using System.Collections.Generic;

namespace Bybit.Net.Converters
{
    internal class WithdrawStatusConverter : BaseConverter<WithdrawStatus>
    {
        public WithdrawStatusConverter() : this(true) { }
        public WithdrawStatusConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<WithdrawStatus, string>> Mapping => new List<KeyValuePair<WithdrawStatus, string>>
        {
            new KeyValuePair<WithdrawStatus, string>(WithdrawStatus.ToBeConfirmed, "ToBeConfirmed"),
            new KeyValuePair<WithdrawStatus, string>(WithdrawStatus.UnderReview, "UnderReview"),
            new KeyValuePair<WithdrawStatus, string>(WithdrawStatus.Pending, "Pending"),
            new KeyValuePair<WithdrawStatus, string>(WithdrawStatus.Success, "Success"),
            new KeyValuePair<WithdrawStatus, string>(WithdrawStatus.CanceledByUser, "CancelByUser"),
            new KeyValuePair<WithdrawStatus, string>(WithdrawStatus.Rejected, "Reject"),
            new KeyValuePair<WithdrawStatus, string>(WithdrawStatus.Expired, "Expire"),
        };
    }
}
