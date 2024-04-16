namespace TossPayments.Core.Response
{
    /// <summary>
    /// <see href="https://docs.tosspayments.com/reference#billing-%EA%B0%9D%EC%B2%B4">문서 참조</see>    
    /// </summary>
    public class Billing
    {
        /// <summary>
        /// 상점아이디(MID)입니다. 토스페이먼츠에서 발급합니다. 최대 길이는 14자입니다.
        /// </summary>
        public required string MId { get; set; }

        /// <summary>
        /// 구매자 ID입니다. 빌링키와 연결됩니다. 다른 사용자가 이 값을 알게 되면 악의적으로 사용될 수 있습니다. 자동 증가하는 숫자 또는 이메일・전화번호・사용자 아이디와 같이 유추가 가능한 값은 안전하지 않습니다. UUID와 같이 충분히 무작위적인 고유 값으로 생성해주세요. 영문 대소문자, 숫자, 특수문자 -, _, =, ., @ 를 최소 1개 이상 포함한 최소 2자 이상 최대 300자 이하의 문자열이어야 합니다.
        /// </summary>
        public required string CustomerKey { get; set; }

        /// <summary>
        /// 결제수단이 인증된 시점의 날짜와 시간 정보입니다.
        /// </summary>
        public required DateTimeOffset AuthenticatedAt { get; set; }

        /// <summary>
        /// 결제수단입니다. 현재 자동결제는 카드만 지원하기 때문에 카드로 값이 고정되어 돌아옵니다.
        /// </summary>
        public required string Method { get; set; }

        /// <summary>
        /// 자동결제에서 카드 정보 대신 사용되는 값입니다. customerKey와 연결됩니다. 최대 길이는 200자입니다.
        /// </summary>
        public required string BillingKey { get; set; }

        /// <summary>
        /// 발급된 빌링키와 연결된 카드 정보입니다.
        /// </summary>
        public required BillingCard Card { get; set; }
    }
}