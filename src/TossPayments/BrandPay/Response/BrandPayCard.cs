namespace TossPayments.BrandPay.Response
{
    public class BrandPayCard
    {
        /// <summary>
        /// 결제수단의 아이디입니다.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 결제수단을 특정하는 키입니다. 자동결제 API, 결제수단 삭제 API 등 API를 사용할 때 고객이 등록해 둔 결제수단을 특정합니다.
        /// 브랜드페이 구매자가 탈퇴하면 methodKey도 더 이상 사용할 수 없습니다.
        /// CUSTOMER_STATUS_CHANGED 웹훅으로 탈퇴한 구매자를 확인하세요.
        /// </summary>
        public string MethodKey { get; set; }

        /// <summary>
        /// 고객이 직접 설정한 해당 결제수단의 별명입니다.
        /// 결제수단의 별명 설정 및 변경은 SDK에서 제공하는 결제 관리 UI의 결제수단 관리에서 할 수 있습니다.
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// 카드 이름입니다.
        /// </summary>
        public string CardName { get; set; }

        /// <summary>
        /// 카드 번호입니다.
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// 카드 발급사 숫자 코드입니다. 카드사 코드를 참고하세요.
        /// </summary>
        public string IssuerCode { get; set; }

        /// <summary>
        /// 카드 매입사 숫자 코드입니다. 카드사 코드를 참고하세요.
        /// </summary>
        public string AcquirerCode { get; set; }

        /// <summary>
        /// 카드의 소유자 타입입니다.
        /// </summary>
        public CardOwnerType OwnerType { get; set; }

        /// <summary>
        /// 카드 종류입니다.
        /// </summary>
        public CardType CardType { get; set; }

        /// <summary>
        /// issuerCode에 해당하는 카드에서 할부가 가능한 최소 금액 정보입니다. 이 금액과 고객이 결제할 금액을 비교해서 할부 선택 UI를 보여줄지 결정할 수 있습니다.
        /// </summary>
        public int InstallmentMinimumAmount { get; set; }

        /// <summary>
        /// 결제수단을 등록한 날짜와 시간 정보입니다.
        /// </summary>
        public DateTimeOffset RegisteredAt { get; set; }

        /// <summary>
        /// 결제수단 활성화 여부를 나타냅니다. 결제수단을 조회할 때는 이 값이 ENABLED인 결제수단만 돌아옵니다. 결제수단을 삭제하면 이 값이 DISABLED로 변경됩니다.
        /// </summary>
        public BrandPayStatus Status { get; set; }

        /// <summary>
        /// 카드사 아이콘입니다. 예를 들어 icn-bank-square-hyundaicard는 현대카드 아이콘 코드입니다.
        /// icn-bank-square-에 카드사 이름이 조합되어 있습니다.
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 카드사 아이콘 이미지 URL입니다. 이 값을 이미지 주소로 사용하면 화면에 카드사 아이콘을 보여줄 수 있습니다.
        /// </summary>
        public Uri IconUrl { get; set; }

        /// <summary>
        /// 카드 실물 이미지 URL입니다. 이 값을 이미지 주소로 사용하면 화면에 카드 실물 이미지를 보여줄 수 있습니다.
        /// </summary>
        public Uri CardImgUrl { get; set; }

        /// <summary>
        /// 카드사 아이콘의 색상입니다. 아이콘 이미지와 함께 카드 결제수단 UI를 직접 만들 때 사용할 수 있습니다.
        /// </summary>
        public BrandPayColor Color { get; set; }

        /// <summary>
        /// 카드사 프로모션 정보가 담기는 배열입니다.
        /// </summary>
        public BrandPayCardPromotion[] Promotions { get; set; }
    }
}