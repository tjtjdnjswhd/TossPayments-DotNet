namespace TossPayments.Core.Response;

/// <summary>
/// <see href="https://docs.tosspayments.com/reference#cashreceipt-%EA%B0%9D%EC%B2%B4">문서 참조</see>
/// </summary>
public class CashReceipt
{
    /// <summary>
    /// 현금영수증의 키 값입니다. 최대 길이는 200자입니다.
    /// </summary>
    public required string ReceiptKey { get; set; }

    /// <summary>
    /// 주문번호입니다. 최소 길이는 6자, 최대 길이는 64자입니다. 주문한 결제를 식별하는 역할로, 결제를 요청할 때 가맹점에서 만들어서 사용합니다. 결제 데이터 관리를 위해 반드시 저장해야 합니다. 중복되지 않는 고유한 값을 발급해야 합니다. 결제 상태가 변해도 값이 유지됩니다.
    /// </summary>
    public required string OrderId { get; set; }

    /// <summary>
    /// 구매상품입니다. 최대 길이는 100자입니다.
    /// </summary>
    public required string OrderName { get; set; }

    /// <summary>
    /// 현금영수증의 종류입니다.
    /// </summary>
    public required CashReceiptType Type { get; set; }

    /// <summary>
    /// 현금영수증 발급 번호입니다. 최대 길이는 9자입니다.
    /// </summary>
    public required string IssueNumber { get; set; }

    /// <summary>
    /// 발행된 현금영수증을 확인할 수 있는 주소입니다.
    /// </summary>
    public required string ReceiptUrl { get; set; }

    /// <summary>
    /// 현금영수증을 발급한 사업자등록번호입니다. 길이는 10자입니다.
    /// </summary>
    public required string BusinessNumber { get; set; }

    /// <summary>
    /// 현금영수증 발급 종류입니다..
    /// </summary>
    public required CashReceiptTransactionType TransactionType { get; set; }

    /// <summary>
    /// 현금영수증 처리된 금액입니다.
    /// </summary>
    public required int Amount { get; set; }

    /// <summary>
    /// 면세 처리된 금액입니다.
    /// </summary>
    public required int TaxFreeAmount { get; set; }

    /// <summary>
    /// 현금영수증 발급 상태입니다.
    /// </summary>
    public required CashReceiptStatus IssueStatus { get; set; }

    /// <summary>
    /// 결제 실패 객체입니다.
    /// </summary>
    public Failure? Failure { get; set; }

    /// <summary>
    /// 현금영수증 발급에 필요한 소비자 인증수단입니다. 최대 길이는 30자입니다.
    /// </summary>
    public required CustomerIdentityNumber CustomerIdentityNumber { get; set; }

    /// <summary>
    /// 현금영수증 발급 혹은 취소를 요청한 날짜와 시간 정보입니다.
    /// </summary>
    public required DateTime RequestedAt { get; set; }
}