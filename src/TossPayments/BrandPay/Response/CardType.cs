using System.Runtime.Serialization;

namespace TossPayments.BrandPay.Response
{
    [DataContract]
    public enum CardType
    {
        [EnumMember(Value = "신용")]
        Credit,

        [EnumMember(Value = "체크")]
        Check,

        [EnumMember(Value = "기프트")]
        Gift,
    }
}
