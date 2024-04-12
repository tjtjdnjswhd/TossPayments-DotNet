using System.Runtime.Serialization;

namespace TossPayments.Core.Models.Response;

[DataContract]
public enum SettlementStatus
{
    /// <summary>
    /// 정산이 완료되지 않은 상태입니다.
    /// </summary>
    [EnumMember(Value = "INCOMPLETED")]
    Incompleted,

    /// <summary>
    /// 정산이 완료된 상태입니다.
    /// </summary>
    [EnumMember(Value = "COMPLETED")]
    Completed
}