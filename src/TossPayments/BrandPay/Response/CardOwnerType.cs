using System.Runtime.Serialization;

namespace TossPayments.BrandPay.Response
{
    [DataContract]
    public enum CardOwnerType
    {
        [EnumMember(Value = "개인")]
        Personal,

        [EnumMember(Value = "법인")]
        Corporate,
    }
}
