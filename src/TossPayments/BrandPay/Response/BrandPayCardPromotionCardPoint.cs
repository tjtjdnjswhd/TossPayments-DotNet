namespace TossPayments.BrandPay.Response
{
    public class BrandPayCardPromotionCardPoint
    {
        /// <summary>
        /// 프로모션을 진행하는 카드 발급사 숫자 코드입니다. 카드사 코드를 참고하세요.
        /// </summary>
        public string IssuerCode { get; set; }

        /// <summary>
        /// 무이자 할부를 적용할 수 있는 최소 결제 금액입니다.
        /// </summary>
        public int MinimumPaymentAmount { get; set; }

        /// <summary>
        /// 통화 정보입니다.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// 프로모션을 마치는 시점입니다. 종료일의 23:59:59까지 행사가 유효합니다.
        /// </summary>
        public DateOnly DueDate { get; set; }
    }
}