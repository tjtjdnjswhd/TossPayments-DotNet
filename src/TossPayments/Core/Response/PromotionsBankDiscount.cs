namespace TossPayments.Core.Response
{
    public class PromotionsBankDiscount
    {
        /// <summary>
        /// 계좌 할인 종류입니다.
        /// </summary>
        public PromotionsBankDiscountType Type { get; set; }

        /// <summary>
        /// 프로모션을 진행하는 은행 숫자 코드입니다. 은행 코드를 참고하세요.
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        /// 할인 금액입니다.
        /// </summary>
        public decimal? DiscountAmount { get; set; }

        /// <summary>
        /// 할인 비율입니다. 이 값은 0.01부터 0.3 까지의 소수입니다. 이 필드는 type이 FIXED_RATE일 때만 값이 있습니다. type이 FIXED_AMOUNT일 때는 null 입니다.
        /// </summary>
        public decimal? DiscountRate { get; set; }

        /// <summary>
        /// 계좌 할인을 적용할 수 있는 최소 결제 금액입니다.
        /// </summary>
        public decimal MinimumPaymentAmount { get; set; }

        /// <summary>
        /// 계좌 할인을 적용할 수 있는 최대 결제 금액입니다.
        /// </summary>
        public decimal MaximumPaymentAmount { get; set; }

        /// <summary>
        /// 통화 정보입니다.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// 계좌 할인 프로모션 코드입니다. 은행에서 만든 고유한 값으로 결제할 때 함께 넘겨야 하는 값입니다.
        /// </summary>
        public string DiscountCode { get; set; }

        /// <summary>
        /// 프로모션을 마치는 시점입니다. 종료일의 23:59:59까지 행사가 유효합니다.
        /// </summary>
        public DateOnly DueDate { get; set; }
    }
}
