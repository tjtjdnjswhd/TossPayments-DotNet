namespace TossPayments.Core.Response;

public class CancelHistory
{
    /// <summary>
    /// 결제를 취소한 금액입니다.
    /// </summary>
    public required decimal CancelAmount { get; set; }

    /// <summary>
    /// 결제를 취소한 이유입니다.
    /// 최대 길이는 200자입니다.
    /// </summary>
    public required string CancelReason { get; set; }

    /// <summary>
    /// 취소된 금액 중 면세 금액입니다.
    /// </summary>
    public required decimal TaxFreeAmount { get; set; }

    /// <summary>
    /// 취소된 금액 중 과세 제외 금액(컵 보증금 등)입니다.
    /// </summary>
    public required int TaxExemptionAmount { get; set; }

    /// <summary>
    /// 결제 취소 후 환불 가능한 잔액입니다.
    /// </summary>
    public required decimal RefundableAmount { get; set; }

    /// <summary>
    /// 간편결제 서비스의 포인트, 쿠폰, 즉시할인과 같은 적립식 결제수단에서 취소된 금액입니다.
    /// </summary>
    public required decimal EasyPayDiscountAmount { get; set; }

    /// <summary>
    /// 결제 취소가 일어난 날짜와 시간 정보입니다.
    /// </summary>
    public required DateTime CanceledAt { get; set; }

    /// <summary>
    /// 취소 건의 키 값입니다. 여러 건의 취소 거래를 구분하는 데 사용됩니다.
    /// 최대 길이는 64자입니다.
    /// </summary>
    public required string TransactionKey { get; set; }

    /// <summary>
    /// 취소 건의 현금영수증 키 값입니다.
    /// 최대 길이는 200자입니다.
    /// </summary>
    public string? ReceiptKey { get; set; }

    /// <summary>
    /// 취소 상태입니다. DONE이면 결제가 성공적으로 취소된 상태입니다.
    /// </summary>
    public required string CancelStatus { get; set; }

    /// <summary>
    /// 취소 요청 ID입니다. 비동기 결제에만 적용되는 특수 값입니다.
    /// 일반결제, 자동결제(빌링), 페이팔 해외결제에서는 항상 null입니다.
    /// </summary>
    public string? CancelRequestId { get; set; }
}