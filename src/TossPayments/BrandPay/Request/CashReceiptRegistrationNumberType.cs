using System.Runtime.Serialization;

namespace TossPayments.BrandPay.Request
{
    [DataContract]
    public enum CashReceiptRegistrationNumberType
    {
        [EnumMember(Value = "MOBILE")]
        Mobile,

        [EnumMember(Value = "BUSINESS_REGISTRATION")]
        BusinessRegistration,

        [EnumMember(Value = "CASH_RECEIPT_CARD")]
        CashReceiptCard
    }
}
