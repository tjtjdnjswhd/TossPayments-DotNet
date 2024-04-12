namespace TossPayments.BrandPay.Response
{
    public class BrandPayCardPromotion
    {
        /// <summary>
        /// 프로모션 종류입니다.
        /// </summary>
        public BrandPayCardPromotionType Type { get; set; }

        /// <summary>
        /// 카드사의 즉시 할인 정보입니다.
        /// </summary>
        public BrandPayCardPromotionDiscount? CardDiscount { get; set; }

        /// <summary>
        /// 카드 무이자 할부 정보입니다.
        /// </summary>
        public BrandPayCardPromotionInterestFee? CardInterestFee { get; set; }

        /// <summary>
        /// 카드 포인트 정보입니다.
        /// </summary>
        public BrandPayCardPromotionCardPoint? CardPoint { get; set; }
    }
}