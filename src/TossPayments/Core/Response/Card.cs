namespace TossPayments.Core.Response;

public class Card
{
    /// <summary>
    /// 카드사에 결제 요청한 금액입니다. 즉시 할인 금액(discount.amount)이 포함됩니다.
    /// </summary>
    public required decimal Amount { get; set; }

    /// <summary>
    /// 카드 발급사 숫자 코드입니다. 카드사 코드를 참고하세요.
    /// </summary>
    public required string IssuerCode { get; set; }

    /// <summary>
    /// 카드 매입사 숫자 코드입니다. 카드사 코드를 참고하세요.
    /// </summary>
    public string? AcquirerCode { get; set; }

    /// <summary>
    /// 카드번호입니다. 번호의 일부는 마스킹 되어 있습니다. 최대 길이는 20자입니다.
    /// </summary>
    public required string Number { get; set; }

    /// <summary>
    /// 할부 개월 수입니다. 일시불이면 0입니다.
    /// </summary>
    public required int InstallmentPlanMonths { get; set; }

    /// <summary>
    /// 카드사 승인 번호입니다. 최대 길이는 8자입니다.
    /// </summary>
    public required string ApproveNo { get; set; }

    /// <summary>
    /// 카드사 포인트 사용 여부입니다.
    /// </summary>
    public required bool UseCardPoint { get; set; }

    /// <summary>
    /// 카드 종류입니다.
    /// </summary>
    public required CardType CardType { get; set; }

    /// <summary>
    /// 카드의 소유자 타입입니다.
    /// </summary>
    public required CardOwnerType OwnerType { get; set; }

    /// <summary>
    /// 카드 결제의 매입 상태입니다.
    /// </summary>
    public required AcquireStatus AcquireStatus { get; set; }

    /// <summary>
    /// 무이자 할부의 적용 여부입니다.
    /// </summary>
    public required bool IsInterestFree { get; set; }

    /// <summary>
    /// 할부가 적용된 결제에서 할부 수수료를 부담하는 주체입니다.
    /// </summary>
    public InterestPayer? InterestPayer { get; set; }
}
