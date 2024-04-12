namespace TossPayments.BrandPay.Response
{
    public class BrandPayBankAccount
    {
        /// <summary>
        /// 결제수단의 ID입니다. SDK를 사용해서 결제할 때 이 값을 사용합니다.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 결제수단을 특정하는 키입니다. 
        /// 자동결제 API, 결제수단 삭제 API 등 API를 사용할 때 고객이 등록해 둔 결제수단을 특정합니다. 
        /// 브랜드페이 구매자가 탈퇴하면 methodKey도 더 이상 사용할 수 없습니다. 
        /// CUSTOMER_STATUS_CHANGED 웹훅으로 탈퇴한 구매자를 확인하세요.
        /// </summary>
        public string MethodKey { get; set; }

        /// <summary>
        /// 계좌 이름입니다.
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// 계좌번호입니다.
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// 고객이 직접 설정한 해당 결제수단의 별명입니다.
        /// 결제수단의 별명 설정 및 변경은 SDK에서 제공하는 결제 관리 UI의 결제수단 관리에서 할 수 있습니다.
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// 은행 숫자 코드입니다. 은행 코드를 참고하세요.
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        /// 은행 아이콘입니다. 예를 들어 icn-bank-kb는 KB국민은행 아이콘 코드입니다.
        /// - NORMAL: 정사각형 형태의 은행 아이콘입니다.(96x96)
        /// - SQUARE: 직사각형 형태의 은행 아이콘입니다. (160x256)
        /// </summary>
        public BrandPayBankAccountIcon Icon { get; set; }

        /// <summary>
        /// 은행 아이콘 이미지 URL입니다. 이 값을 이미지 주소로 사용해서 화면에 은행 아이콘을 보여줄 수 있습니다.
        /// </summary>
        public Uri IconUrl { get; set; }

        /// <summary>
        /// 결제수단을 등록한 날짜와 시간 정보입니다. yyyy-MM-dd'T'HH:mm:ss±hh:mm ISO 8601 형식입니다. (e.g. 2022-01-01T00:00:00+09:00)
        /// </summary>
        public DateTimeOffset RegisteredAt { get; set; }

        /// <summary>
        /// 결제수단 활성화 여부를 나타냅니다. 결제수단을 조회할 때는 이 값이 ENABLED인 결제수단만 돌아옵니다. 결제수단을 삭제하면 이 값이 DISABLED로 변경됩니다.
        /// </summary>
        public BrandPayStatus Status { get; set; }

        public BrandPayColor Color { get; set; }

        public BrandPayBankAccountPromotion[] Promotions { get; set; }
    }
}