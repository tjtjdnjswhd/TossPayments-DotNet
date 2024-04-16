using System.Runtime.Serialization;

namespace TossPayments.Core.Request
{
    [DataContract]
    public enum SubmallType
    {
        [EnumMember(Value = "CORPORATE")]
        Corporate,

        [EnumMember(Value = "INDIVIDUAL")]
        Individual
    }
}