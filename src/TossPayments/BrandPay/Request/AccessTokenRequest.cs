namespace TossPayments.BrandPay.Request
{
    public class AccessTokenRequest
    {
        /// <summary>
        /// 구매자 ID입니다. 다른 사용자가 이 값을 알게 되면 악의적으로 사용될 수 있습니다. 자동 증가하는 숫자 또는 이메일・전화번호・사용자 아이디와 같이 유추가 가능한 값은 안전하지 않습니다. UUID와 같이 충분히 무작위적인 고유 값으로 생성해주세요. 영문 대소문자, 숫자, 특수문자 -, _, =, ., @ 를 최소 1개 이상 포함한 최소 2자 이상 최대 50자 이하의 문자열이어야 합니다.
        /// </summary>
        public required string CustomerKey { get; set; }

        /// <summary>
        /// 요청 타입입니다
        /// </summary>
        public required string GrantType { get; set; }

        /// <summary>
        /// 약관 동의 API의 응답 또는 리다이렉트 URL의 쿼리 파라미터로 돌아온 code를 넣어줍니다. grantType이 AuthorizationCode이면 필수입니다.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Access Token 발급 API로 돌아온 refreshToken을 넣어줍니다. grantType이 RefreshToken이면 필수입니다
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// 인증에 필요한 고객 정보입니다. 
        /// 상점에서 가지고 있는 고객 정보를 사용해서 값을 채워주세요. 
        /// 이 정보를 보내면 휴대폰 본인 인증 과정에서 입력해야 하는 정보가 미리 채워집니다. 
        /// 상점에 가입한 고객과 브랜드페이 서비스에 가입한 고객이 같은지 인증하고 이 정보와 본인 인증 결과로 받은 고객 정보가 일치하는지 비교합니다.
        /// </summary>
        public CustomerIdentity CustomerIdentity { get; set; }
    }

    public enum AccessTokenRequestGrantType
    {
        /// <summary>
        /// 신규 고객이면 Access Token을 처음 발급합니다. 기존 고객이면 Access Token 유효기간을 연장합니다.
        /// </summary>
        AuthorizationCode,

        /// <summary>
        /// 기존 고객의 Access Token을 새로 발급합니다. 새로운 Access Token, Refresh Token을 발급합니다.
        /// </summary>
        RefreshToken
    }
}