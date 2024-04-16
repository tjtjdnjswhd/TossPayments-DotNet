namespace TossPayments.Core.Request
{
    public class CancelRequest
    {
        /// <summary>
        /// 결제를 취소하는 이유입니다.최대 길이는 200자입니다.
        /// </summary>
        public required string CancelReason { get; set; }

        /// <summary>
        /// 취소할 금액입니다. 값이 없으면 전액 취소됩니다.
        /// </summary>
        public decimal CancelAmount { get; set; }

        /// <summary>
        /// 결제 취소 후 금액이 환불될 계좌의 정보입니다. 가상계좌 결제에만 필수입니다.
        /// 다른 결제수단으로 이루어진 결제를 취소할 때는 사용하지 않습니다.
        /// 보낸 계좌 정보는 유효성 검사가 이뤄집니다.
        /// 구매자가 가상계좌에 입금을 아직 안 했다면, 결제를 취소해도 환불해야 되는 금액이 없기 때문에 이 파라미터를 추가할 필요가 없습니다.
        /// 입금 전에는 부분 취소를 할 수 없고 전체 금액 취소만 할 수 있습니다.
        /// </summary>
        public required RefundReceiveAccount RefundReceiveAccount { get; set; }

        /// <summary>
        /// 취소할 금액 중 면세 금액입니다. 값을 넣지 않으면 기본값인 0으로 설정됩니다.
        /// </summary>
        public decimal TaxFreeAmount { get; set; }

        /// <summary>
        /// 취소 통화입니다.PayPal 해외간편결제 부분 취소에는 필수 값입니다. PayPal에서 사용할 수 있는 통화는 USD입니다.
        /// </summary>
        public required string Currency { get; set; }
    }
}