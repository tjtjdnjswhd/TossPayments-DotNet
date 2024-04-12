using System.Runtime.Serialization;


namespace TossPayments.BrandPay.Request
{
    [DataContract]
    [Flags]
    public enum TermsScope
    {
        [EnumMember(Value = "REGISTER")]
        Register = 1,

        [EnumMember(Value = "ACCOUNT")]
        Account = 2,

        [EnumMember(Value = "BILLING")]
        Billing = 4,

        [EnumMember(Value = "CARD")]
        Card = 8
    }
}