namespace TossPayments.BrandPay.Request
{
    public class ExecuteAutoPaymentRequest
    {
        /// <summary>
        /// 구매자 ID입니다. 빌링키와 연결됩니다. 다른 사용자가 이 값을 알게 되면 악의적으로 사용될 수 있습니다. 자동 증가하는 숫자 또는 이메일・전화번호・사용자 아이디와 같이 유추가 가능한 값은 안전하지 않습니다. UUID와 같이 충분히 무작위적인 고유 값으로 생성해주세요. 영문 대소문자, 숫자, 특수문자 -, _, =, ., @ 를 최소 1개 이상 포함한 최소 2자 이상 최대 50자 이하의 문자열이어야 합니다.
        /// </summary>
        public required string CustomerKey { get; set; }

        /// <summary>
        /// 결제수단을 특정하는 키입니다.
        /// </summary>
        public required string MethodKey { get; set; }

        /// <summary>
        /// 결제할 금액입니다.
        /// </summary>
        public required int Amount { get; set; }

        /// <summary>
        /// 주문번호입니다. 주문을 구분하는 ID입니다. 충분히 무작위한 값을 생성해서 각 주문마다 고유한 값을 넣어주세요. 영문 대소문자, 숫자, 특수문자 -, _, =로 이루어진 6자 이상 64자 이하의 문자열이어야 합니다.
        /// </summary>
        public required string OrderId { get; set; }

        /// <summary>
        /// 구매상품입니다. 예를 들면 생수 외 1건 같은 형식입니다. 최소 1글자 이상 100글자 이하여야 합니다.
        /// </summary>
        public required string OrderName { get; set; }

        /// <summary>
        /// 신용 카드의 할부 개월 수입니다. 값을 넣으면 해당 할부 개월 수로 결제가 진행됩니다. 2부터 12사이의 값을 사용할 수 있고, 0이 들어가면 할부가 아닌 일시불로 결제됩니다. 결제 금액이 5만원 이상일 때만 할부가 적용됩니다.
        /// </summary>
        public int CardInstallmentPlan { get; set; }

        /// <summary>
        /// 현금영수증 정보입니다.
        /// </summary>
        public ExecuteAutoPaymentRequestCashReceipt CashReceipt { get; set; }

        /// <summary>
        /// 문화비(도서, 공연 티켓, 박물관·미술관 입장권 등) 지출 여부입니다. 결제수단이 계좌일 때만 설정하세요.
        /// * 카드 결제는 항상 false로 돌아옵니다.카드 결제 문화비는 카드사에 문화비 소득공제 전용 가맹점번호를 설정하면 자동으로 처리됩니다.
        /// </summary>
        public bool CultureExpense { get; set; }

        /// <summary>
        /// 구매자의 이메일 주소입니다. 결제 상태가 바뀌면 이메일 주소로 결제내역이 전송됩니다.
        /// </summary>
        public string CustomerEmail { get; set; }

        /// <summary>
        /// 즉시 할인 코드(카드사 고유 번호)로 결제할 때 함께 넘겨야 하는 값입니다.
        /// </summary>
        public string DiscountCode { get; set; }

        /// <summary>
        /// 고객의 배송지 주소입니다. 부정거래탐지시스템(FDS, Fraud Detection System, 거래 정보와 고객 정보, 평소 거래 패턴 등을 분석해서 의심되는 전자금융거래를 탐지하고 차단하는 기술)에 사용할 수 있습니다.
        /// </summary>
        public string ShippingAddress { get; set; }

        /// <summary>
        /// 전체 결제 금액 중 면세 금액입니다. 값이 0으로 돌아왔다면 전체 결제 금액이 과세 대상입니다.
        /// </summary>
        public int TaxFreeAmount { get; set; }

        /// <summary>
        /// 카드로 결제할 때 설정하는 카드사 포인트 사용 여부입니다. 값을 주지 않거나 값이 false라면 사용자가 카드사 포인트 사용 여부를 결정할 수 있습니다. 이 값을 true로 주면 카드사 포인트 사용이 체크된 상태로 결제창이 열립니다.
        /// </summary>
        public bool UseCardPoint { get; set; }
    }
}
