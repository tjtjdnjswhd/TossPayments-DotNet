using System.Runtime.Serialization;

namespace TossPayments.Core.Response;

[DataContract]
public enum CashReceiptStatus
{
    [EnumMember(Value = "IN_PROGRESS")]
    InProgress,

    [EnumMember(Value = "COMPLETED")]
    Completed,

    [EnumMember(Value = "FAILED")]
    Failed
}