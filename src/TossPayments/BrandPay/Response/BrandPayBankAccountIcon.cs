using System.Runtime.Serialization;

namespace TossPayments.BrandPay.Response
{
    [DataContract]
    public enum BrandPayBankAccountIcon
    {
        [EnumMember(Value = "NORMAL")]
        Normal,

        [EnumMember(Value = "SQUARE")]
        Square
    }
}