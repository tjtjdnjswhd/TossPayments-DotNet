namespace TossPayments.BrandPay.Request
{
    public class ExecuteAutoPaymentRequestCashReceipt
    {
        /// <summary>
        /// 현금영수증의 종류입니다. 미발행을 선택하면 응답 객체의 cashReceipt 필드에는 null이 돌아옵니다.
        /// </summary>
        public required CashReceiptType Type { get; set; }

        /// <summary>
        /// 현금영수증 번호 타입입니다. 휴대폰 번호, 사업자등록번호, 현금영수증 카드 번호 중 하나를 선택할 수 있습니다.
        /// </summary>
        public CashReceiptRegistrationNumberType RegistrationNumberType { get; set; }

        /// <summary>
        /// 현금영수증 발급에 필요한 소비자 인증수단입니다. 현금영수증을 발급한 주체를 식별합니다.
        /// 현금영수증 종류에 따라 휴대폰 번호, 사업자등록번호, 현금영수증 카드 번호를 입력할 수 있습니다.
        /// </summary>
        public string RegistrationNumber { get; set; }
    }
}
