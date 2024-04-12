namespace TossPayments.BrandPay.Response
{
    /// <summary>
    /// <see href="https://docs.tosspayments.com/reference/brandpay#brandpaycardpromotion-%EA%B0%9D%EC%B2%B4">문서 참조</see>
    /// </summary>
    public class BrandPayCardPromotions
    {
        /// <summary>
        /// 카드사의 즉시 할인 정보입니다.
        /// </summary>
        public BrandPayCardPromotionDiscount[] DiscountCards { get; set; }

        /// <summary>
        /// 카드사의 무이자 할부 정보입니다.
        /// </summary>
        public BrandPayCardPromotionInterestFee[] InterestFreeCards { get; set; }

        /// <summary>
        /// 카드 포인트 정보입니다.
        /// </summary>
        public BrandPayCardPromotionCardPoint[] PointCards { get; set; }
    }
}