namespace TossPayments.Core.Response;

public class MobilePhone
{
    /// <summary>
    /// 결제에 사용한 휴대폰 번호입니다.
    /// </summary>
    public required string CustomerMobilePhone { get; set; }

    /// <summary>
    /// 정산 상태입니다.
    /// </summary>
    public required SettlementStatus SettlementStatus { get; set; }

    /// <summary>
    /// 휴대폰 결제 내역 영수증을 확인할 수 있는 주소입니다.
    /// </summary>
    public required string ReceiptUrl { get; set; }
}