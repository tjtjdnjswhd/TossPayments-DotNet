namespace TossPayments.Core.Models.Response;

public class Receipt
{
    /// <summary>
    /// 고객에게 제공할 수 있는 결제수단별 영수증입니다. 카드 결제는 매출전표, 가상계좌는 무통장 거래 명세서, 계좌이체・휴대폰・상품권 결제는 결제 거래 내역 확인서가 제공됩니다.
    /// </summary>
    public required string Url { get; set; }
}