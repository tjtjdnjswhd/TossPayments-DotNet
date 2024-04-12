using System.Runtime.Serialization;

namespace TossPayments.Core.Models.Response;

[DataContract]
public enum VirtualAccountType
{
    [EnumMember(Value = "일반")]
    Normal,

    [EnumMember(Value = "고정")]
    Fixed
}
