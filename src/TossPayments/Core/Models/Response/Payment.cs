namespace TossPayments.Core.Models.Response;

/// <summary>
/// <see href="https://docs.tosspayments.com/reference#payment-%EA%B0%9D%EC%B2%B4">문서 참조</see>
/// </summary>
public class Payment
{
    /// <summary>
    /// 결제의 키 값입니다.
    /// 최대 길이는 200자입니다.
    /// 결제를 식별하는 역할로, 중복되지 않는 고유한 값입니다.
    /// 결제 데이터 관리를 위해 반드시 저장해야 합니다.
    /// 결제 상태가 변해도 값이 유지됩니다.
    /// 결제 승인, 결제 조회, 결제 취소 API에 사용합니다.
    /// </summary>
    public required string PaymentKey { get; set; }

    /// <summary>
    /// 결제 타입 정보입니다.
    /// NORMAL(일반결제), BILLING(자동결제), BRANDPAY(브랜드페이) 중 하나입니다.
    /// </summary>
    public required string Type { get; set; }

    /// <summary>
    /// 주문번호입니다.
    /// 최소 길이는 6자, 최대 길이는 64자입니다.
    /// 주문한 결제를 식별하는 역할로, 결제를 요청할 때 가맹점에서 만들어서 사용한 값입니다.
    /// 결제 데이터 관리를 위해 반드시 저장해야 합니다.
    /// 중복되지 않는 고유한 값을 발급해야 합니다.
    /// 결제 상태가 변해도 값이 유지됩니다.
    /// </summary>
    public required string OrderId { get; set; }

    /// <summary>
    /// 구매상품입니다.
    /// 예를 들면 생수 외 1건 같은 형식입니다.
    /// 최대 길이는 100자입니다.
    /// </summary>
    public required string OrderName { get; set; }

    /// <summary>
    /// 상점아이디(MID)입니다.
    /// 토스페이먼츠에서 발급합니다.
    /// 최대 길이는 14자입니다.
    /// </summary>
    public required string MId { get; set; }

    /// <summary>
    /// 결제할 때 사용한 통화입니다.
    /// </summary>
    public required string Currency { get; set; }

    /// <summary>
    /// 결제수단입니다.
    /// 카드, 가상계좌, 간편결제, 휴대폰, 계좌이체, 문화상품권, 도서문화상품권, 게임문화상품권 중 하나입니다.
    /// </summary>
    public required string Method { get; set; }

    /// <summary>
    /// 총 결제 금액입니다.
    /// 결제가 취소되는 등 결제 상태가 변해도 최초에 결제된 결제 금액으로 유지됩니다.
    /// </summary>
    public required decimal TotalAmount { get; set; }

    /// <summary>
    /// 취소할 수 있는 금액(잔고)입니다.
    /// 이 값은 결제 취소나 부분 취소가 되고 나서 남은 값입니다.
    /// 결제 상태 변화에 따라 vat, suppliedAmount, taxFreeAmount, taxExemptionAmount와 함께 값이 변합니다.
    /// </summary>
    public required decimal BalanceAmount { get; set; }

    /// <summary>
    /// 결제 처리 상태입니다.
    /// READY, IN_PROGRESS, WAITING_FOR_DEPOSIT, DONE, CANCELED, PARTIAL_CANCELED, ABORTED, EXPIRED 값을 가질 수 있습니다.
    /// </summary>
    public required string Status { get; set; }

    /// <summary>
    /// 결제가 일어난 날짜와 시간 정보입니다.
    /// yyyy-MM-dd'T'HH:mm:ss±hh:mm ISO 8601 형식입니다.
    /// </summary>
    public required DateTimeOffset RequestedAt { get; set; }

    /// <summary>
    /// 결제 승인이 일어난 날짜와 시간 정보입니다.
    /// yyyy-MM-dd'T'HH:mm:ss±hh:mm ISO 8601 형식입니다.
    /// </summary>
    public required DateTimeOffset ApprovedAt { get; set; }

    /// <summary>
    /// 에스크로 사용 여부입니다.
    /// </summary>
    public required bool UseEscrow { get; set; }

    /// <summary>
    /// 마지막 거래의 키 값입니다.
    /// 한 결제 건의 승인 거래와 취소 거래를 구분하는 데 사용됩니다.
    /// 최대 길이는 64자입니다.
    /// </summary>
    public required string LastTransactionKey { get; set; }

    /// <summary>
    /// 공급가액입니다.
    /// 결제 취소 및 부분 취소가 되면 공급가액도 일부 취소되어 값이 바뀝니다.
    /// </summary>
    public required decimal SuppliedAmount { get; set; }

    /// <summary>
    /// 부가세입니다.
    /// 결제 취소 및 부분 취소가 되면 부가세도 일부 취소되어 값이 바뀝니다.
    /// </summary>
    public required decimal VAT { get; set; }

    /// <summary>
    /// 문화비(도서, 공연 티켓, 박물관·미술관 입장권 등) 지출 여부입니다.
    /// 계좌이체, 가상계좌 결제에만 적용됩니다.
    /// </summary>
    public required bool CultureExpense { get; set; }

    /// <summary>
    /// 결제 금액 중 면세 금액입니다.
    /// 결제 취소 및 부분 취소가 되면 면세 금액도 일부 취소되어 값이 바뀝니다.
    /// </summary>
    public required decimal TaxFreeAmount { get; set; }

    /// <summary>
    /// 과세를 제외한 결제 금액(컵 보증금 등)입니다.
    /// 이 값은 결제 취소 및 부분 취소가 되면 과세 제외
    //금액도 일부 취소되어 값이 바뀝니다.
    /// </summary>
    public required int TaxExemptionAmount { get; set; }

    /// <summary>
    /// 결제 취소 이력입니다.
    /// </summary>
    public CancelHistory[]? Cancels { get; set; }

    /// <summary>
    /// 부분 취소 가능 여부입니다. 이 값이 false이면 전액 취소만 가능합니다.
    /// </summary>
    public required bool IsPartialCancelable { get; set; }

    /// <summary>
    /// 카드로 결제하면 제공되는 카드 관련 정보입니다.
    /// </summary>
    public Card? Card { get; set; }

    /// <summary>
    /// 가상계좌로 결제하면 제공되는 가상계좌 관련 정보입니다.
    /// </summary>
    public VirtualAccount? VirtualAccount { get; set; }

    /// <summary>
    /// 가상계좌 웹훅이 정상적인 요청인지 검증하는 값입니다. 이 값이 가상계좌 웹훅 이벤트 본문으로 돌아온 secret과 같으면 정상적인 요청입니다. 최대 길이는 50자입니다.
    /// </summary>
    public string? Secret { get; set; }

    /// <summary>
    /// 휴대폰으로 결제하면 제공되는 휴대폰 결제 관련 정보입니다.
    /// </summary>
    public MobilePhone? MobilePhone { get; set; }

    /// <summary>
    /// 상품권으로 결제하면 제공되는 휴대폰 결제 관련 정보입니다.
    /// </summary>
    public GiftCertification? GiftCertification { get; set; }

    /// <summary>
    /// 계좌이체로 결제했을 때 이체 정보가 담기는 객체입니다.
    /// </summary>
    public Transfer? Transfer { get; set; }

    /// <summary>
    /// 발행된 영수증 정보입니다.
    /// </summary>
    public Receipt? Receipt { get; set; }

    /// <summary>
    /// 결제창 정보입니다.
    /// </summary>
    public Checkout? Checkout { get; set; }

    /// <summary>
    /// 간편결제 정보입니다. 고객이 선택한 결제수단에 따라 amount, discountAmount가 달라집니다. 간편결제 응답 확인 가이드를 참고하세요.
    /// </summary>
    public EasyPay? EasyPay { get; set; }

    /// <summary>
    /// 결제한 국가입니다. ISO-3166의 두 자리 국가 코드 형식입니다.
    /// </summary>
    public required string Country { get; set; }

    /// <summary>
    /// 결제 승인에 실패하면 응답으로 받는 에러 객체입니다. 실패한 결제를 조회할 때 확인할 수 있습니다.
    /// </summary>
    public Failure? Failure { get; set; }

    /// <summary>
    /// 현금영수증 정보입니다.
    /// </summary>
    public PaymentCashReceipt? CashReceipt { get; set; }

    /// <summary>
    /// 현금영수증 발행 및 취소 이력이 담기는 배열입니다. 순서는 보장되지 않습니다. 예를 들어 결제 후 부분 취소가 여러 번 일어나면 모든 결제 및 부분 취소 건에 대한 현금영수증 정보를 담고 있습니다.
    /// 계좌이체는 결제 즉시 현금영수증 정보를 확인할 수 있습니다. 가상계좌는 고객이 입금을 완료하면 현금영수증 정보를 확인할 수 있습니다.
    /// </summary>
    public CashReceipt[]? CashReceipts { get; set; }

    /// <summary>
    /// 카드사의 즉시 할인 프로모션 정보입니다. 즉시 할인 프로모션이 적용됐을 때만 생성됩니다.
    /// </summary>
    public Discount? Discount { get; set; }
}