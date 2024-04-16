namespace TossPayments.Core.Response;

public class Transfer
{
    /// <summary>
    /// 은행 숫자 코드입니다. 은행 코드와 증권사 코드를 참고하세요.
    /// </summary>
    public required string BankCode { get; set; }

    /// <summary>
    /// 정산 상태입니다.
    /// </summary>
    public required SettlementStatus SettlementStatus { get; set; }
}