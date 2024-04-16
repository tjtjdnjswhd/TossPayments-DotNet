using System.Runtime.Serialization;

namespace TossPayments.Core.Response
{
    [DataContract]
    public enum PaymentMethod
    {
        [EnumMember(Value = "카드")]
        Card,

        [EnumMember(Value = "가상계좌")]
        VirtualAccount,

        [EnumMember(Value = "간편결제")]
        EasyPay,

        [EnumMember(Value = "휴대폰")]
        Mobile,

        [EnumMember(Value = "계좌이체")]
        BankTransfer,

        [EnumMember(Value = "문화상품권")]
        CultureVoucher,

        [EnumMember(Value = "도서문화상품권")]
        BookCultureVoucher,

        [EnumMember(Value = "게임문화상품권")]
        GameCultureVoucher
    }
}