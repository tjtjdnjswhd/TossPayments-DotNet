namespace TossPayments.Core.Response;

public class CustomerIdentityNumber
{
    /// <summary>
    /// 현금영수증 종류에 따라 휴대폰 번호, 사업자등록번호, 현금영수증 카드 번호 등을 입력할 수 있습니다.
    /// </summary>
    public required string Value { get; set; }
}