namespace TossPayments.Core.Request
{
    public class SubmallAccount
    {
        /// <summary>
        /// 지급받을 계좌의 은행 코드입니다.은행 코드와 증권사 코드를 참고하세요.
        /// </summary>
        public string Bank { get; set; }

        /// <summary>
        /// 계좌번호입니다. - 없이 숫자만 넣어야 합니다. 최대 길이는 20자입니다.
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// 지급받을 계좌의 예금주입니다. 최대 길이는 공백을 포함한 한글 30자, 영문 60자입니다.
        /// </summary>
        public string HolderName { get; set; }
    }
}