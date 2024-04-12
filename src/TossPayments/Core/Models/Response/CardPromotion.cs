namespace TossPayments.Core.Models.Response
{
    public class CardPromotion
    {
        /// <summary>
        /// 카드사의 즉시 할인 정보입니다.
        /// </summary>
        public PromotionsCardDiscount[] DiscountCards { get; set; }

        /// <summary>
        /// 카드사의 무이자 할부 정보입니다.
        /// </summary>
        public PromotionsCardInterestFree[] InterestFreeCards { get; set; }
    }
}