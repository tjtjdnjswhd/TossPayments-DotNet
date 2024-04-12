namespace TossPayments.BrandPay.Response
{
    public class BrandPayMethod
    {
        /// <summary>
        /// 본인 인증 후 브랜드페이에 가입되어 있는지입니다.
        /// 브랜드페이 SDK로 본인 인증을 했거나, Access Token을 발급받을 때 개인 식별 정보(customerIdentity) 객체의 값을 모두 채워서 인증이 진행하면 true로 설정됩니다.
        /// </summary>
        public bool IsIdentified { get; set; }

        /// <summary>
        /// 가장 최근에 등록했거나 사용한 결제수단의 id 값입니다.
        /// 전체 결제수단의 등록 날짜와 최근 한 달 이내에 사용한 결제수단의 사용일을 비교해 가장 최근에 등록했거나 사용한 결제수단의 id가 내려갑니다. 등록한 결제수단이 없다면 null이 내려갑니다.
        /// </summary>
        public string? SelectedMethodId { get; set; }

        /// <summary>
        /// 브랜드페이에 고객이 등록한 카드 정보가 배열로 들어옵니다.
        /// </summary>
        public BrandPayCard[] Cards { get; set; }

        /// <summary>
        /// 브랜드페이에 고객이 등록한 계좌 정보가 배열로 들어옵니다.
        /// </summary>
        public BrandPayBankAccount[] Accounts { get; set; }
    }
}