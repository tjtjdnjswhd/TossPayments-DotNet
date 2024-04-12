using System.Runtime.Serialization;

namespace TossPayments.BrandPay.Request
{
    [DataContract]
    public enum CashReceiptType
    {
        /// <summary>
        ///  소득공제
        /// </summary>
        [EnumMember(Value = "소득공제")]
        IncomeDeduction,

        /// <summary>
        /// 지출증빙
        /// </summary>
        [EnumMember(Value = "지출증빙")]
        ExpenseProof,

        /// <summary>
        /// 미발행
        /// </summary>
        [EnumMember(Value = "미발행")]
        Unissued
    }
}
