using System.Runtime.Serialization;

namespace TossPayments.Core.Models.Response;

[DataContract]
public enum CashReceiptType
{
    /// <summary>
    /// 소득공제
    /// </summary>
    [EnumMember(Value = "소득공제")]
    IncomeDeduction,

    /// <summary>
    /// 지출증빙
    /// </summary>
    [EnumMember(Value = "지출증빙")]
    ExpenseProof
}