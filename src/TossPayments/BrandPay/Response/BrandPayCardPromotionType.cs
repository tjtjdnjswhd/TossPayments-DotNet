using System.Runtime.Serialization;

namespace TossPayments.BrandPay.Response
{
    public enum BrandPayCardPromotionType
    {
        /// <summary>
        /// 카드 즉시 할인입니다. cardDiscount 객체에 관련 정보가 돌아옵니다.
        /// </summary>
        [EnumMember(Value = "CARD_DISCOUNT")]
        CardDiscount,

        /// <summary>
        /// 카드 무이자 할부입니다. cardInterestFree 객체에 관련 정보가 돌아옵니다.
        /// </summary>
        [EnumMember(Value = "CARD_INTEREST_FREE")]
        CardInterestFree,

        /// <summary>
        /// 카드 포인트 할인입니다. cardPoint 객체에 관련 정보가 돌아옵니다.
        /// </summary>
        [EnumMember(Value = "CARD_POINT")]
        CardPoint,
    }
}