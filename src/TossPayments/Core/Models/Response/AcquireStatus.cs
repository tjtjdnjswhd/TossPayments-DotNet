using System.Runtime.Serialization;

namespace TossPayments.Core.Models.Response;

[DataContract]
public enum AcquireStatus
{
    [EnumMember(Value = "READY")]
    Ready,

    [EnumMember(Value = "REQUESTED")]
    Requested,

    [EnumMember(Value = "COMPLETED")]
    Completed,

    [EnumMember(Value = "CANCEL_REQUESTED")]
    CancelRequested,

    [EnumMember(Value = "CANCELED")]
    Canceled
}
