namespace TossPayments.BrandPay.Response
{
    public class BrandPayBankAccountPromotion
    {
        /// <summary>
        /// 프로모션 종류입니다. 항상 BANK_DISCOUNT입니다.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 계좌 할인 정보입니다.
        /// </summary>
        public BankDiscount? BankDiscount { get; set; }
    }
}