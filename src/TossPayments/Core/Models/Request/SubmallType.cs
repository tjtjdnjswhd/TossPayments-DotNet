using System.Runtime.Serialization;

namespace TossPayments.Core.Models.Request
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