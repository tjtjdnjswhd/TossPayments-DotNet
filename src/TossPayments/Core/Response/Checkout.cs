namespace TossPayments.Core.Response;

public class Checkout
{
    /// <summary>
    /// 결제창이 열리는 주소입니다.
    /// </summary>
    public required string Url { get; set; }
}