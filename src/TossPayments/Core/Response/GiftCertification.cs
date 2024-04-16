namespace TossPayments.Core.Response;

public class GiftCertification
{
    /// <summary>
    /// 결제 승인번호입니다.최대 길이는 8자입니다.
    /// </summary>
    public required string ApproveNo { get; set; }

    /// <summary>
    /// 정산 상태입니다.
    /// </summary>
    public required SettlementStatus SettlementStatus { get; set; }
}