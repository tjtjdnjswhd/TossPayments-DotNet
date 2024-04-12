namespace TossPayments.BrandPay.Response
{
    /// <summary>
    /// <see href="https://docs.tosspayments.com/reference/brandpay#terms-%EA%B0%9D%EC%B2%B4"/>
    /// </summary>
    public class Terms
    {
        /// <summary>
        /// 약관의 ID입니다.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 약관 제목입니다.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 약관 버전입니다.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 약관 전문이 들어있는 URL입니다.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 약관의 필수 동의 여부입니다.
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// 고객의 약관에 동의 여부입니다.
        /// </summary>
        public bool Agreed { get; set; }
    }
}