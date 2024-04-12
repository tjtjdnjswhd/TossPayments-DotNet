namespace TossPayments.Core.Models.Request
{
    public class ConfirmBillingRequest
    {
        /// <summary>
        /// 결제할 금액입니다.
        /// </summary>
        public required int Amount { get; set; }

        /// <summary>
        /// 구매자 ID입니다. 빌링키와 연결됩니다. 다른 사용자가 이 값을 알게 되면 악의적으로 사용될 수 있습니다. 자동 증가하는 숫자 또는 이메일・전화번호・사용자 아이디와 같이 유추가 가능한 값은 안전하지 않습니다. UUID와 같이 충분히 무작위적인 고유 값으로 생성해주세요. 영문 대소문자, 숫자, 특수문자 -, _, =, ., @ 를 최소 1개 이상 포함한 최소 2자 이상 최대 300자 이하의 문자열이어야 합니다.
        /// </summary>
        public required string CustomerKey { get; set; }

        /// <summary>
        /// 주문번호입니다. 주문한 결제를 식별합니다. 충분히 무작위한 값을 생성해서 각 주문마다 고유한 값을 넣어주세요. 영문 대소문자, 숫자, 특수문자 -, _로 이루어진 6자 이상 64자 이하의 문자열이어야 합니다. 결제 데이터 관리를 위해 반드시 저장해야 합니다.
        /// </summary>
        public required string OrderId { get; set; }

        /// <summary>
        /// 구매상품입니다. 예를 들면 생수 외 1건 같은 형식입니다. 최대 길이는 100자입니다.
        /// </summary>
        public required string OrderName { get; set; }

        /// <summary>
        /// 신용 카드의 할부 개월 수입니다. 값을 넣으면 해당 할부 개월 수로 결제가 진행됩니다. 2부터 12사이의 값을 사용할 수 있고, 0이 들어가거나 값을 넣지 않으면 할부가 아닌 일시불로 결제됩니다.
        /// </summary>
        public int CardInstallmentPlan { get; set; }

        /// <summary>
        /// 구매자의 이메일 주소입니다. 결제 상태가 바뀌면 이메일 주소로 결제내역이 전송됩니다. 최대 길이는 100자입니다.
        /// </summary>
        public required string CustomerEmail { get; set; }

        /// <summary>
        /// 구매자명입니다. 최대 길이는 100자입니다.
        /// </summary>
        public required string CustomerName { get; set; }

        /// <summary>
        /// 면세 금액입니다. 값을 넣지 않으면 기본값인 0으로 설정됩니다.
        /// </summary>
        public int TaxFreeAmount { get; set; }

        /// <summary>
        /// 과세를 제외한 결제 금액(컵 보증금 등)입니다.
        /// </summary>
        public int TaxExemptionAmount { get; set; }
    }
}
