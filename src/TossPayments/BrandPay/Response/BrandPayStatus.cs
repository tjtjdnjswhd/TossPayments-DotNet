using System.Runtime.Serialization;

namespace TossPayments.BrandPay.Response
{
    [DataContract]
    public enum BrandPayStatus
    {
        /// <summary>
        /// 결제수단이 등록되어 사용할 수 있는 상태
        /// </summary>
        [EnumMember(Value = "ENABLED")]
        Enabled,

        /// <summary>
        /// 결제수단이 삭제되어 사용할 수 없는 상태
        /// </summary>
        [EnumMember(Value = "DISABLED")]
        Disabled
    }
}