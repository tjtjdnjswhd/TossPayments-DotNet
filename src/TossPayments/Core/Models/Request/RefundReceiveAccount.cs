namespace TossPayments.Core.Models.Request
{
    public class RefundReceiveAccount
    {
        /// <summary>
        /// 취소 금액을 환불받을 계좌의 은행 코드입니다. 은행 코드와 증권사 코드를 참고하세요.
        /// </summary>
        public required string Bank { get; set; }

        /// <summary>
        /// 취소 금액을 환불받을 계좌의 계좌번호입니다. - 없이 숫자만 넣어야 합니다. 최대 길이는 20자입니다.
        /// </summary>
        public required string AccountNumber { get; set; }

        /// <summary>
        /// 취소 금액을 환불받을 계좌의 예금주입니다. 최대 길이는 60자입니다.
        /// </summary>
        public required string HolderName { get; set; }
    }
}