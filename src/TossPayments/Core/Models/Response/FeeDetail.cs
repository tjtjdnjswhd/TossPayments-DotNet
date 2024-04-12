namespace TossPayments.Core.Models.Response
{
    public class FeeDetail
    {
        /// <summary>
        /// 수수료의 세부 타입입니다.
        /// </summary>
        public required FeeType Type { get; set; }

        /// <summary>
        /// 수수료 금액입니다.
        /// </summary>
        public required decimal Fee { get; set; }

        /// <summary>
        /// 결제 수수료의 공급가액입니다.
        /// </summary>
        public required decimal SupplyAmount { get; set; }

        /// <summary>
        /// 결제 수수료 부가세입니다.
        /// </summary>
        public required decimal Vat { get; set; }
    }
}
