using System.Runtime.Serialization;

namespace TossPayments.Core.Models.Response
{
    [DataContract]
    public enum PromotionsBankDiscountType
    {
        [EnumMember(Value = "FIXED_AMOUNT")]
        FixedAmount,

        [EnumMember(Value = "FIXED_RATE")]
        FixedRate
    }
}
