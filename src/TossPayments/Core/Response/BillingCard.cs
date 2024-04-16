namespace TossPayments.Core.Response
{
    public class BillingCard
    {
        /// <summary>
        /// 카드 발급사 숫자 코드입니다.
        /// </summary>
        public required string IssuerCode { get; set; }

        /// <summary>
        /// 카드 매입사 숫자 코드입니다.
        /// </summary>
        public required string AcquirerCode { get; set; }

        /// <summary>
        /// 카드 번호입니다. 번호의 일부는 마스킹 되어 있습니다. 최대 길이는 20자입니다.
        /// </summary>
        public required string Number { get; set; }

        /// <summary>
        /// </summary>
        public required CardType CardType { get; set; }

        /// <summary>
        /// </summary>
        public required CardOwnerType OwnerType { get; set; }
    }
}