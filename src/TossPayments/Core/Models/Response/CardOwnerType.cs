using System.Runtime.Serialization;

namespace TossPayments.Core.Models.Response;

[DataContract]
public enum CardOwnerType
{
    [EnumMember(Value = "개인")]
    Personal,

    [EnumMember(Value = "법인")]
    Corporate,

    [EnumMember(Value = "미확인")]
    Unknown
}
