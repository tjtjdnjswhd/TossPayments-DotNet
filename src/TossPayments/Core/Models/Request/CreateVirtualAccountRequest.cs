namespace TossPayments.Core.Models.Request
{
    public class CreateVirtualAccountRequest
    {
        /// <summary>
        /// 결제할 금액입니다.
        /// </summary>
        public required int Amount { get; set; }

        /// <summary>
        /// 주문번호입니다. 
        /// 주문한 결제를 식별합니다. 
        /// 충분히 무작위한 값을 생성해서 각 주문마다 고유한 값을 넣어주세요. 
        /// 영문 대소문자, 숫자, 특수문자 -, _로 이루어진 6자 이상 64자 이하의 문자열이어야 합니다. 
        /// 결제 데이터 관리를 위해 반드시 저장해야 합니다.
        /// </summary>
        public required string OrderId { get; set; }

        /// <summary>
        /// 구매상품입니다. 예를 들면 생수 외 1건 같은 형식입니다. 최대 길이는 100자입니다. 최소 1글자 이상 100글자 이하여야 합니다.
        /// </summary>
        public required string OrderName { get; set; }

        /// <summary>
        /// 입금할 구매자명입니다. 최대 길이는 100자입니다.
        /// </summary>
        public required string CustomerName { get; set; }

        /// <summary>
        /// 가상계좌를 발급할 은행입니다. 가상계좌 발급이 가능한 은행을 참고하세요.
        /// </summary>
        public required string Bank { get; set; }

        /// <summary>
        /// 가상계좌 발급 시점으로부터 가상계좌가 유효한 시간입니다. 
        /// 설정한 validHours 안에 구매자가 입금을 하지 않으면 주문은 취소됩니다. 
        /// 설정할 수 있는 최대값은 2160시간(90일)입니다.
        /// 값을 넣지 않으면 기본값 168시간(7일)으로 설정됩니다.
        /// <see cref="ValidHours"/>와 <see cref="DueDate"/> 중 하나만 사용할 수 있습니다.
        /// </summary>
        public int ValidHours { get; set; }

        /// <summary>
        /// 가상계좌 입금 기한입니다. dueDate이 지난 시점에 입금을 시도하면 실패합니다. 
        /// 티켓 예매 등 주문 시간과 상관없이 정해진 시점까지 결제를 받아야 할 때도 사용할 수 있습니다. 
        /// 설정할 수 있는 최대값은 결제 요청일로부터 90일입니다.
        /// <see cref="ValidHours"/>와 <see cref="DueDate"/> 중 하나만 사용할 수 있습니다.
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// 구매자의 이메일 주소입니다. 결제 상태가 바뀌면 이메일 주소로 결제내역이 전송됩니다. 최대 길이는 100자입니다.
        /// </summary>
        public required string CustomerEmail { get; set; }

        /// <summary>
        /// 구매자의 휴대폰 번호입니다. 가상계좌 입금 안내가 전송되는 번호입니다.
        /// </summary>
        public required string CustomerMobilePhone { get; set; }

        /// <summary>
        /// 면세 금액입니다. 값을 넣지 않으면 기본값인 0으로 설정됩니다.
        /// </summary>
        public int TaxFreeAmount { get; set; }

        /// <summary>
        /// 에스크로 사용 여부입니다. 값을 넣지 않으면 기본값인 false로 설정되고 사용자가 에스크로 결제 여부를 선택합니다.
        /// </summary>
        public bool UseEscrow { get; set; }

        public required CashReceiptRequest CashReceipt { get; set; }

        /// <summary>
        /// 각 상품의 상세 정보를 담는 배열입니다. 예를 들어 사용자가 세 가지 종류의 상품을 구매했다면 길이가 3인 배열이어야 합니다. 에스크로 결제를 사용할 때만 필요한 파라미터입니다.
        /// </summary>
        public required EscrowProductRequest[] EscrowProducts { get; set; }
    }
}