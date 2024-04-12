using System.ComponentModel;
using System.Text.Json.Serialization;
using TossPayments.Core.JsonConverters;

namespace TossPayments.Core.Models.Response
{
    public class Payout
    {
        /// <summary>
        /// 하나의 지급대행 건의 키입니다. 최대 길이는 24자입니다.
        /// </summary>
        public string PayoutKey { get; set; }

        /// <summary>
        /// 서브몰의 ID입니다. 최대 길이는 20자입니다.
        /// </summary>
        public string? SubMallId { get; set; }

        /// <summary>
        /// 금액이 지급될 날짜와 시간 정보입니다.
        /// </summary>
        [TypeConverter(typeof(yyyyMMddConverter))]
        public DateOnly PayoutDate { get; set; }

        /// <summary>
        /// 지급할 금액입니다.
        /// </summary>
        public decimal PayoutAmount { get; set; }

        /// <summary>
        /// 정산 금액을 지급받을 계좌 정보를 담은 객체입니다.
        /// </summary>
        public Account? Account { get; set; }

        /// <summary>
        /// 은행 숫자 코드입니다. 은행 코드와 증권사 코드를 참고하세요.
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        /// 지급받을 계좌번호입니다.
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// 지급받을 계좌의 예금주입니다. 최대 길이는 60자입니다.
        /// </summary>
        public string? HolderName { get; set; }

        /// <summary>
        /// 지급대행을 요청한 날짜와 시간 정보입니다.
        /// </summary>
        [JsonConverter(typeof(yyyyMMddHHmmSSConverter))]
        public DateTime RequestedAt { get; set; }

        /// <summary>
        /// 지급대행 상태입니다.
        /// </summary>
        public PayoutStatus Status { get; set; }

        /// <summary>
        /// 지급대행 요청이 실패하면 보내주는 정보입니다. status 필드가 FAILED 일 때만 정보를 보여줍니다.
        /// </summary>
        public Failure? Failure { get; set; }

        /// <summary>
        /// 지급대행으로 입금된 금액의 세부 내용(적요)입니다. 서브몰 통장에 표기되는 정보입니다. 최대 길이는 7자입니다.
        /// </summary>
        public string TransferSummary { get; set; }

        /// <summary>
        /// 서브몰과 관련된 추가 정보를 key-value 쌍으로 담고 있는 객체입니다. 최대 50개의 key-value 쌍을 포함할 수 있으며 전체 크기는 4kB 이하입니다.
        /// </summary>
        public Dictionary<string, string>? Metadata { get; set; }
    }
}