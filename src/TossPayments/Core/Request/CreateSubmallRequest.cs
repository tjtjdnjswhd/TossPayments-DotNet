namespace TossPayments.Core.Request
{
    public class CreateSubmallRequest
    {
        /// <summary>
        /// 서브몰의 ID입니다. 최대 길이는 20자입니다.
        /// </summary>
        public required string SubMallId { get; set; }

        /// <summary>
        /// 서브몰에서 정산 금액을 지급받을 계좌 정보를 담은 객체입니다.
        /// </summary>
        public required SubmallAccount Account { get; set; }

        /// <summary>
        /// 지급받을 계좌의 은행 코드입니다. 은행 코드와 증권사 코드를 참고하세요.
        /// </summary>
        public required string Bank { get; set; }

        /// <summary>
        /// 계좌번호입니다. - 없이 숫자만 넣어야 합니다. 최대 길이는 20자입니다.
        /// </summary>
        public required string AccountNumber { get; set; }

        /// <summary>
        /// 지급받을 계좌의 예금주입니다. 최대 길이는 공백을 포함한 한글 30자, 영문 60자입니다.
        /// </summary>
        public string HolderName { get; set; }

        /// <summary>
        /// 서브몰의 타입입니다. CORPORATE(법인), INDIVIDUAL(개인) 중 하나의 값을 넣어주세요.
        /// </summary>
        public required SubmallType Type { get; set; }

        /// <summary>
        /// 서브몰 이메일 주소입니다.
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// 서브몰 연락처입니다. - 없이 숫자만 넣어야 합니다.
        /// </summary>
        public required string PhoneNumber { get; set; }

        /// <summary>
        /// 서브몰의 상호명입니다. 서브몰의 type이 CORPORATE일 때 필수로 보내야 하는 파라미터입니다. 최대 길이는 공백을 포함한 한글 30자, 영문 60자입니다.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 서브몰의 대표자명입니다. 서브몰의 type이 CORPORATE일 때 필수로 보내야 하는 파라미터입니다. 최대 길이는 공백을 포함한 한글 20자, 영문 40자입니다.
        /// </summary>
        public string RepresentativeName { get; set; }

        /// <summary>
        /// 서브몰의 사업자등록번호 입니다. 서브몰의 type이 CORPORATE일 때 필수로 보내야 하는 파라미터입니다. 길이는 10자입니다.
        /// </summary>
        public string BusinessNumber { get; set; }

        /// <summary>
        /// 서브몰과 관련된 추가 정보를 key-value 쌍으로 담고 있는 객체입니다. 최대 50개의 key-value 쌍을 포함할 수 있으며 전체 크기는 4kB 이하여야 합니다. key와 value 모두 문자열 형식이어야 합니다.
        /// </summary>
        public Dictionary<string, string>? Metadata { get; set; }
    }
}