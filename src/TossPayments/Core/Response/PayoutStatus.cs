using System.Runtime.Serialization;

namespace TossPayments.Core.Response
{
    [DataContract]
    public enum PayoutStatus
    {
        [EnumMember(Value = "REQUESTED")]
        Request,

        [EnumMember(Value = "IN_PROGRESS")]
        InProgress,

        [EnumMember(Value = "COMPLETED")]
        Completed,

        [EnumMember(Value = "FAILED")]
        Failed,

        [EnumMember(Value = "CANCELED")]
        Canceled
    }
}