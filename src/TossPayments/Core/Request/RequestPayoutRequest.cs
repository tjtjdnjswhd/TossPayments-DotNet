namespace TossPayments.Core.Request
{
    public class RequestPayoutRequest
    {
        /// <summary>
        /// 서브몰의 ID입니다. 최대 길이는 20자입니다.
        /// </summary>
        public required string SubMallId { get; set; }

        /// <summary>
        /// 정산한 금액을 지급할 날짜 정보입니다.
        /// </summary>
        public required DateOnly PayoutDate { get; set; }

        /// <summary>
        /// 정산할 금액입니다.
        /// </summary>
        public required int PayoutAmount { get; set; }

        /// <summary>
        /// 지급대행으로 입금된 금액의 세부 내용(적요)입니다. 서브몰 통장에 표기되는 정보입니다. 최대 길이는 7자입니다.
        /// </summary>
        public string TransferSummary { get; set; }

        /// <summary>
        /// 서브몰과 관련된 추가 정보를 key-value 쌍으로 담고 있는 객체입니다. 최대 50개의 key-value 쌍을 포함할 수 있으며 전체 크기는 4kB 이하여야 합니다. key와 value 모두 문자열 형식이어야 합니다.
        /// </summary>
        public Dictionary<string, string>? Metadata { get; set; }
    }
}