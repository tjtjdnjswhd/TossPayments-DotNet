using System.Runtime.Serialization;

namespace TossPayments.Core.Response;

[DataContract]
public enum VirtualAccountType
{
    [EnumMember(Value = "일반")]
    Normal,

    [EnumMember(Value = "고정")]
    Fixed
}
