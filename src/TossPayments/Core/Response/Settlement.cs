namespace TossPayments.Core.Response
{
    /// <summary>
    /// <see href="https://docs.tosspayments.com/reference#settlement-%EA%B0%9D%EC%B2%B4">문서 참조</see>    
    /// </summary>
    public class Settlement
    {
        /// <summary>
        /// 상점아이디(MID)입니다. 토스페이먼츠에서 발급합니다. 최대 길이는 14자입니다.
        /// </summary>
        public required string MId { get; set; }

        /// <summary>
        /// 결제의 키 값입니다. 최대 길이는 200자입니다. 결제를 식별하는 역할로, 중복되지 않는 고유한 값입니다. 결제 데이터 관리를 위해 반드시 저장해야 합니다. 결제 상태가 변해도 값이 유지됩니다.
        /// </summary>
        public required string PaymentKey { get; set; }

        /// <summary>
        /// 거래의 키 값입니다. 한 결제 건의 승인 거래와 취소 거래를 구분하는 데 사용됩니다. 최대 길이는 64자입니다.
        /// </summary>
        public required string TransactionKey { get; set; }

        /// <summary>
        /// 주문번호입니다. 최소 길이는 6자, 최대 길이는 64자입니다. 주문한 결제를 식별하는 역할로, 결제를 요청할 때 가맹점에서 만들어서 사용합니다. 결제 상태가 변해도 값이 유지됩니다.
        /// </summary>
        public required string OrderId { get; set; }

        /// <summary>
        /// 결제할 때 사용한 통화입니다.
        /// </summary>
        public required string Currency { get; set; }

        /// <summary>
        /// 결제수단입니다. 카드, 가상계좌, 간편결제, 휴대폰, 계좌이체, 문화상품권, 도서문화상품권, 게임문화상품권 중 하나입니다.
        /// </summary>
        public required PaymentMethod Method { get; set; }

        /// <summary>
        /// 결제한 금액입니다.
        /// </summary>
        public required decimal Amount { get; set; }

        /// <summary>
        /// 할부 수수료 금액입니다.
        /// </summary>
        public required decimal InterestFee { get; set; }

        /// <summary>
        /// 결제 수수료의 상세 정보입니다. 수수료 상세 정보가 담긴 객체가 배열로 들어옵니다.
        /// </summary>
        public required FeeDetail[] Fees { get; set; }

        /// <summary>
        /// 지급 금액입니다. 결제 금액 amount에서 수수료인 fee를 제외한 금액입니다.
        /// </summary>
        public required decimal PayOutAmount { get; set; }

        /// <summary>
        /// 거래가 승인된 시점의 날짜와 시간 정보입니다.
        /// </summary>
        public required DateTimeOffset ApprovedAt { get; set; }

        /// <summary>
        /// 지급 금액의 정산 기준이 되는 정산 매출일입니다. 상점의 정산 주기에 따라 달라집니다.
        /// </summary>
        public required DateTime SoldDate { get; set; }

        /// <summary>
        /// 지급 금액을 상점에 지급할 정산 지급일입니다. 상점의 정산 기준일과 정산 주기에 따라 달라집니다.
        /// </summary>
        public required DateTime PaidOutDate { get; set; }

        public Card? Card { get; set; }

        public EasyPay? EasyPay { get; set; }

        public GiftCertification? GiftCertification { get; set; }

        public MobilePhone? MobilePhone { get; set; }

        public Transfer? Transfer { get; set; }

        public VirtualAccount? VirtualAccount { get; set; }

        public CancelHistory? Cancel { get; set; }
    }
}
