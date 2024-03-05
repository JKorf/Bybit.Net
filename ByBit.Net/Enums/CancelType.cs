namespace Bybit.Net.Enums
{
    /// <summary>
    /// Cancel type
    /// </summary>
    public enum CancelType
    {
        /// <summary>
        /// Cancel by user
        /// </summary>
        CancelByUser,
        /// <summary>
        /// Cancel by reduce only
        /// </summary>
        CancelByReduceOnly,
        /// <summary>
        /// Cancel due to liquidation
        /// </summary>
        CancelyByPrepareLiq,
        /// <summary>
        /// Cancel due to liquidation
        /// </summary>
        CancelAllBeforeLiq,
        /// <summary>
        /// Cancel due to ADL
        /// </summary>
        CancelByPrepareAdl,
        /// <summary>
        /// Cancel due to ADL
        /// </summary>
        CancelAllBeforeAdl,
        /// <summary>
        /// Cancel by admin
        /// </summary>
        CancelByAdmin,
        /// <summary>
        /// Cancel by TP/SL ts clear
        /// </summary>
        CancelByTpSlTsClear,
        /// <summary>
        /// Cancel by Pz Side Ch
        /// </summary>
        CancelByPzSideCh,
        /// <summary>
        /// Cancel by setlle
        /// </summary>
        CancelBySettle,
        /// <summary>
        /// Cancel by cannot afford
        /// </summary>
        CancelByCannotAffordOrderCost,
        /// <summary>
        /// Cancel by Pm Trial Mm over equity
        /// </summary>
        CancelByPmTrialMmOverEquity,
        /// <summary>
        /// Cancel by account blocking
        /// </summary>
        CancelByAccountBlocking,
        /// <summary>
        /// Cancel by delivery
        /// </summary>
        CancelByDelivery,
        /// <summary>
        /// Cancel by market maker protection triggered
        /// </summary>
        CancelByMmpTriggered,
        /// <summary>
        /// Cancel by cross self much
        /// </summary>
        CancelByCrossSelfMuch,
        /// <summary>
        /// Cancel by reached max trade number
        /// </summary>
        CancelByCrossReachMaxTradeNum,
        /// <summary>
        /// Cancel by DCP
        /// </summary>
        CancelByDCP,
        /// <summary>
        /// Cancel by Self match prevention
        /// </summary>
        CancelBySmp,
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown
    }
}
