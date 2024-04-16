using System.Runtime.Serialization;

namespace TossPayments.Core.Response
{
    /// <summary>
    /// 결제 상태를 나타내는 열거형입니다.
    /// </summary>
    [DataContract]
    public enum PaymentStatus
    {
        [EnumMember(Value = "READY")]
        Ready,

        [EnumMember(Value = "IN_PROGRESS")]
        InProgress,

        [EnumMember(Value = "WAITING_FOR_DEPOSIT")]
        WaitingForDeposit,

        [EnumMember(Value = "DONE")]
        Done,

        [EnumMember(Value = "CANCELED")]
        Canceled,

        [EnumMember(Value = "PARTIAL_CANCELED")]
        PartialCanceled,

        [EnumMember(Value = "ABORTED")]
        Aborted,

        [EnumMember(Value = "EXPIRED")]
        Expired
    }
}