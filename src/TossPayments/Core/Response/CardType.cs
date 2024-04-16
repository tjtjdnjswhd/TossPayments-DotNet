using System.Runtime.Serialization;

namespace TossPayments.Core.Response;

[DataContract]
public enum CardType
{
    [EnumMember(Value = "신용")]
    Credit,

    [EnumMember(Value = "체크")]
    Check,

    [EnumMember(Value = "기프트")]
    Gift,

    [EnumMember(Value = "미확인")]
    Unknown
}
