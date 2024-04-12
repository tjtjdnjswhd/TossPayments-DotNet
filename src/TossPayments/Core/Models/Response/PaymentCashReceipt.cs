namespace TossPayments.Core.Models.Response;

public class PaymentCashReceipt
{
    /// <summary>
    /// 현금영수증의 종류입니다
    /// </summary>
    public required CashReceiptType Type { get; set; }

    /// <summary>
    /// 현금영수증의 키 값입니다. 최대 길이는 200자입니다.
    /// </summary>
    public required string ReceiptKey { get; set; }

    /// <summary>
    /// 현금영수증 발급 번호입니다. 최대 길이는 9자입니다.
    /// </summary>
    public required string IssueNumber { get; set; }

    /// <summary>
    /// 발행된 현금영수증을 확인할 수 있는 주소입니다.
    /// </summary>
    public required string ReceiptUrl { get; set; }

    /// <summary>
    /// 현금영수증 처리된 금액입니다.
    /// </summary>
    public required decimal Amount { get; set; }

    /// <summary>
    /// 면세 처리된 금액입니다.
    /// </summary>
    public required decimal TaxFreeAmount { get; set; }
}