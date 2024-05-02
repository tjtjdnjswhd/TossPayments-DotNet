using TossPayments.Core.Response;

namespace TossPayments.WebHookBody
{
    public class DespositCallback
    {
        /// <summary>
        /// 웹훅이 생성된 시간입니다.
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// 가상계좌 웹훅 요청이 정상적인 요청인지 검증하는 값입니다. 결제 승인 API의 응답으로 돌아온 secret과 같으면 정상적인 요청입니다.
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// 결제 상태입니다.
        /// </summary>
        public PaymentStatus Status { get; set; }

        /// <summary>
        /// 상태가 변경된 가상계좌 거래를 특정하는 키입니다.
        /// </summary>
        public string TransactionKey { get; set; }

        /// <summary>
        /// 주문번호입니다.
        /// </summary>
        public string OrderId { get; set; }
    }
}
