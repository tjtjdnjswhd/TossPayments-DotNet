namespace TossPayments.Core.Models.Response
{
    /// <summary>
    /// <see href="https://docs.tosspayments.com/reference#transaction-%EA%B0%9D%EC%B2%B4">문서 참조</see>    
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// 상점아이디(MID)입니다. 토스페이먼츠에서 발급합니다. 최대 길이는 14자입니다.
        /// </summary>
        public required string MId { get; set; }

        /// <summary>
        /// 거래의 키 값입니다. 한 결제 건의 승인 거래와 취소 거래를 구분하는 데 사용됩니다. 최대 길이는 64자입니다.
        /// </summary>
        public required string TransactionKey { get; set; }

        /// <summary>
        /// 결제의 키 값입니다. 최대 길이는 200자입니다. 결제를 식별하는 역할로, 중복되지 않는 고유한 값입니다. 결제 데이터 관리를 위해 반드시 저장해야 합니다. 결제 상태가 변해도 값이 유지됩니다.
        /// </summary>
        public required string PaymentKey { get; set; }

        /// <summary>
        /// 주문번호입니다. 최소 길이는 6자, 최대 길이는 64자입니다. 주문한 결제를 식별하는 역할로, 결제를 요청할 때 가맹점에서 만들어서 사용합니다. 결제 상태가 변해도 값이 유지됩니다.
        /// </summary>
        public required string OrderId { get; set; }

        /// <summary>
        /// 결제수단입니다.
        /// </summary>
        public required PaymentMethod Method { get; set; }

        /// <summary>
        /// 구매자 ID입니다. 빌링키와 연결됩니다. 다른 사용자가 이 값을 알게 되면 악의적으로 사용될 수 있습니다. 자동 증가하는 숫자 또는 이메일・전화번호・사용자 아이디와 같이 유추가 가능한 값은 안전하지 않습니다. UUID와 같이 충분히 무작위적인 고유 값으로 생성해주세요. 영문 대소문자, 숫자, 특수문자 -, _, =, ., @ 를 최소 1개 이상 포함한 최소 2자 이상 최대 300자 이하의 문자열이어야 합니다.
        /// </summary>
        public required string CustomerKey { get; set; }

        /// <summary>
        /// 에스크로 사용 여부입니다.
        /// </summary>
        public required bool UseEscrow { get; set; }

        /// <summary>
        /// 거래 영수증을 확인할 수 있는 주소입니다.
        /// </summary>
        public required string ReceiptUrl { get; set; }

        /// <summary>
        /// 결제 처리 상태입니다. 상태 변화 흐름이 궁금하다면 흐름도를 살펴보세요.
        /// </summary>
        public required PaymentStatus Status { get; set; }

        /// <summary>
        /// 거래가 처리된 시점의 날짜와 시간 정보입니다.
        /// </summary>
        public required DateTimeOffset TransactionAt { get; set; }

        /// <summary>
        /// 결제할 때 사용한 통화입니다.
        /// </summary>
        public required string Currency { get; set; }

        /// <summary>
        /// 결제한 금액입니다.
        /// </summary>
        public required decimal Amount { get; set; }
    }
}