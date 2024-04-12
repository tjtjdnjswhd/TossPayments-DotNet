using System.Runtime.Serialization;

namespace TossPayments.Core.Models.Response
{
    [DataContract]
    public enum PromotionsType
    {
        [EnumMember(Value = "CARD_DISCOUNT")]
        CardDiscount,

        [EnumMember(Value = "CARD_INTEREST_FREE")]
        CardInterestFree,

        [EnumMember(Value = "CARD_POINT")]
        CardPoint,

        [EnumMember(Value = "BANK_DISCOUNT")]
        BankDiscount
    }
}
