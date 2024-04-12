using System.Runtime.Serialization;

namespace TossPayments.Core.Models.Response;

[DataContract]
public enum RefundStatus
{
    [EnumMember(Value = "NONE")]
    None,

    [EnumMember(Value = "PENDING")]
    Pending,

    [EnumMember(Value = "FAILED")]
    Failed,

    [EnumMember(Value = "PARTIAL_FAILED")]
    PartialFailed,

    [EnumMember(Value = "COMPLETED")]
    Completed
}
