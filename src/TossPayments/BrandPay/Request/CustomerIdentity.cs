namespace TossPayments.BrandPay.Request
{
    public class CustomerIdentity
    {
        /// <summary>
        /// 고객의 연계 정보(CI) 값입니다.
        /// </summary>
        public string CI { get; set; }

        /// <summary>
        /// 구매자의 휴대폰 번호입니다.
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// 구매자명입니다.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 고객의 주민번호 앞 7자리(생년월일+성별코드)입니다.
        /// </summary>
        public string RRN { get; set; }
    }
}