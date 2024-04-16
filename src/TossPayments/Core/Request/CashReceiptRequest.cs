namespace TossPayments.Core.Request
{
    /// <summary>
    /// 현금영수증 발급 정보를 담는 객체입니다.
    /// </summary>
    public class CashReceiptRequest
    {
        /// <summary>
        /// 현금영수증 발급 용도입니다.
        /// </summary>
        public required string Type { get; set; }

        /// <summary>
        /// 현금영수증 발급에 필요한 개인 식별 번호입니다.
        /// 최대 길이는 30자입니다.
        /// 현금영수증 종류에 따라 휴대폰 번호, 사업자등록번호, 현금영수증 카드 번호 등을 입력할 수 있습니다.
        /// </summary>
        public required string RegistrationNumber { get; set; }
    }
}
