using System.Runtime.Serialization;

namespace TossPayments.Core.Response;

[DataContract]
public enum InterestPayer
{
    [EnumMember(Value = "BUYER")]
    Buyer,

    [EnumMember(Value = "CARD_COMPANY")]
    CardCompany,

    [EnumMember(Value = "MERCHANT")]
    Merchant
}