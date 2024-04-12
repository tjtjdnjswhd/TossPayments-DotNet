namespace TossPayments.BrandPay.Response
{
    public class BankDiscount
    {
        /// <summary>
        /// 프로모션을 진행하는 은행 숫자 코드입니다. 은행 코드를 참고하세요.
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        /// 할인 금액입니다.
        /// </summary>
        public decimal DiscountAmount { get; set; }

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

        /// <summary>
        /// 남은 프로모션 예산입니다. 값이 '0'이면 즉시 할인을 적용할 수 없습니다.
        /// </summary>
        public decimal Balance { get; set; }
    }
}