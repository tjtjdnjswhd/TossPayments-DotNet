namespace TossPayments.Core.Response;

public class EasyPay
{
    /// <summary>
    /// 선택한 간편결제사 코드입니다.
    /// </summary>
    public required string Provider { get; set; }

    /// <summary>
    /// 간편결제 서비스에 등록된 계좌 혹은 현금성 포인트로 결제한 금액입니다.
    /// </summary>
    public required decimal Amount { get; set; }

    /// <summary>
    /// 간편결제 서비스의 적립 포인트나 쿠폰 등으로 즉시 할인된 금액입니다.
    /// </summary>
    public required decimal DiscountAmount { get; set; }
}