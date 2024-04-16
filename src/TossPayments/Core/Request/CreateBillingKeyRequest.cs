namespace TossPayments.Core.Request
{
    public class CreateBillingKeyRequest
    {
        /// <summary>
        /// 구매자 ID입니다. 빌링키와 연결됩니다. 
        /// 다른 사용자가 이 값을 알게 되면 악의적으로 사용될 수 있습니다. 
        /// 자동 증가하는 숫자 또는 이메일・전화번호・사용자 아이디와 같이 유추가 가능한 값은 안전하지 않습니다. 
        /// UUID와 같이 충분히 무작위적인 고유 값으로 생성해주세요. 영문 대소문자, 숫자, 특수문자 -, _, =, ., @ 를 최소 1개 이상 포함한 최소 2자 이상 최대 300자 이하의 문자열이어야 합니다.
        /// </summary>
        public required string CustomerKey { get; set; }

        /// <summary>
        /// 카드 번호입니다. 최대 길이는 20자입니다.
        /// </summary>
        public required string CardNumber { get; set; }

        /// <summary>
        /// 카드 유효 연도입니다.
        /// </summary>
        public required string CardExpirationYear { get; set; }

        /// <summary>
        /// 카드 유효 월입니다.
        /// </summary>
        public required string CardExpirationMonth { get; set; }

        /// <summary>
        /// 카드 소유자 정보입니다. 생년월일 6자리(YYMMDD) 혹은 사업자등록번호 10자리가 들어갑니다.
        /// </summary>
        public required string CustomerIdentityNumber { get; set; }

        /// <summary>
        /// 카드 비밀번호 앞 두 자리입니다.
        /// </summary>
        public required string CardPassword { get; set; }

        /// <summary>
        /// 구매자명입니다. 최대 길이는 100자입니다.
        /// </summary>
        public required string CustomerName { get; set; }

        /// <summary>
        /// 구매자의 이메일 주소입니다. 결제 상태가 바뀌면 이메일 주소로 결제내역이 전송됩니다. 최대 길이는 100자입니다.
        /// </summary>
        public required string CustomerEmail { get; set; }

        /// <summary>
        /// 해외 카드 결제의 3DS 인증에 사용합니다. 3DS 인증 결과를 전송해야 되면 필수입니다.
        /// </summary>
        public required ThreeDomainSecure Vbv { get; set; }
    }
}