namespace TossPayments.Core.Models.Response;

public class RefundReceiveAccount
{
    /// <summary>
    /// 은행 코드입니다.
    /// </summary>
    public required string BankCode { get; set; }

    /// <summary>
    /// 계좌번호입니다.
    /// </summary>
    public required string AccountNumber { get; set; }

    /// <summary>
    /// 예금주 정보입니다.
    /// </summary>
    public required string HolderName { get; set; }
}