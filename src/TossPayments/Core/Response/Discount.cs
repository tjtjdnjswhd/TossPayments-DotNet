namespace TossPayments.Core.Response;

public class Discount
{
    /// <summary>
    /// 카드사의 즉시 할인 프로모션을 적용한 금액입니다.
    /// </summary>
    public required int Amount { get; set; }
}