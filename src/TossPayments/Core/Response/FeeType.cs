using System.Runtime.Serialization;

namespace TossPayments.Core.Response
{
    [DataContract]
    public enum FeeType
    {
        [EnumMember(Value = "BASE")]
        Base,

        [EnumMember(Value = "INSTALLMENT_DISCOUNT")]
        InstallmentDiscount,

        [EnumMember(Value = "INSTALLMENT")]
        Installment,

        [EnumMember(Value = "POINT_SAVING")]
        PointSaving,

        [EnumMember(Value = "ETC")]
        ETC
    }
}
