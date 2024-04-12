using System.Runtime.Serialization;

namespace TossPayments.Core.Models.Response;

public enum CashReceiptTransactionType
{
    /// <summary>
    /// 현금영수증 발급 건입니다.
    /// </summary>
    [EnumMember(Value = "CONFIRM")]
    Confirm,

    /// <summary>
    /// 현금영수증 취소 건입니다.
    /// </summary>
    [EnumMember(Value = "CANCEL")]
    Cancel
}