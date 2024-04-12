namespace TossPayments.BrandPay.Response
{
    /// <summary>
    /// <see href="https://docs.tosspayments.com/reference/brandpay#accesstoken-%EA%B0%9D%EC%B2%B4">문서 참조</see>
    /// </summary>
    public class AccessTokenResponse
    {
        /// <summary>
        /// 사용자에 할당된 Access Token 입니다. customerKey와 연결되어 있는 값으로 고객이 탈퇴하거나 Refresh Token으로 새로 발급받지 않는 한 변하지 않습니다.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 브랜드페이 API를 요청할 때 쓰는 인증 방식인 bearer가 고정값으로 돌아옵니다.
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        /// Access Token을 새로 발급 받을 때 사용할 토큰입니다.
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// Access Token의 유효기간을 초 단위로 나타낸 값입니다. Access Token이 만료되면 Access Token 발급 API로 유효기간을 연장하거나 새로 발급받으세요.
        /// </summary>
        public int ExpiresIn { get; set; }
    }
}