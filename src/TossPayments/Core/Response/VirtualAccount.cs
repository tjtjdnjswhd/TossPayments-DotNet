namespace TossPayments.Core.Response;

public class VirtualAccount
{
    /// <summary>
    /// 가상계좌 타입을 나타냅니다.
    /// </summary>
    public required VirtualAccountType AccountType { get; set; }

    /// <summary>
    /// 발급된 계좌번호입니다. 최대 길이는 20자입니다.
    /// </summary>
    public required string AccountNumber { get; set; }

    /// <summary>
    /// 가상계좌 은행 숫자 코드입니다. 은행 코드와 증권사 코드를 참고하세요.
    /// </summary>
    public required string BankCode { get; set; }

    /// <summary>
    /// 가상계좌를 발급한 구매자명입니다. 최대 길이는 100자입니다.
    /// </summary>
    public required string CustomerName { get; set; }

    /// <summary>
    /// 입금 기한입니다.
    /// </summary>
    public required DateTime DueDate { get; set; }

    /// <summary>
    /// 환불 처리 상태입니다.
    /// </summary>
    public required RefundStatus RefundStatus { get; set; }

    /// <summary>
    /// 가상계좌의 만료 여부입니다.
    /// </summary>
    public required bool Expired { get; set; }

    /// <summary>
    /// 정산 상태입니다.
    /// </summary>
    public required SettlementStatus SettlementStatus { get; set; }

    /// <summary>
    /// 결제위젯 가상계좌 환불 정보 입력 기능으로 받은 고객의 환불 계좌 정보입니다.
    /// </summary>
    public required RefundReceiveAccount RefundReceiveAccount { get; set; }
}