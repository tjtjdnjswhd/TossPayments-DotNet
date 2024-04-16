using TossPayments.Core.Response;

namespace TossPayments.Core.Request
{
    public class CreateCashReceiptRequest
    {
        /// <summary>
        /// 현금영수증을 발급할 금액입니다.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 주문번호입니다. 주문한 결제를 식별합니다. 충분히 무작위한 값을 생성해서 각 주문마다 고유한 값을 넣어주세요. 영문 대소문자, 숫자, 특수문자 -, _로 이루어진 6자 이상 64자 이하의 문자열이어야 합니다. 결제 데이터 관리를 위해 반드시 저장해야 합니다.
        /// </summary>
        public required string OrderId { get; set; }

        /// <summary>
        /// 구매상품입니다. 예를 들면 생수 외 1건 같은 형식입니다. 최대 길이는 100자입니다.
        /// </summary>
        public required string OrderName { get; set; }

        /// <summary>
        /// 현금영수증의 종류입니다. 소득공제, 지출증빙 중 하나입니다. 소득 공제용 현금영수증을 발급받을 때는 소비자 인증수단으로 휴대폰 번호나 현금영수증 카드 번호가 필요하고, 지출 증빙용 현금영수증을 발급받을 때는 사업자 등록번호를 입력해야 합니다.
        /// </summary>
        public CashReceiptType Type { get; set; }

        /// <summary>
        /// 현금영수증 발급에 필요한 소비자 인증수단입니다. 현금영수증을 발급한 주체를 식별합니다. 최대 길이는 30자입니다. 현금영수증 종류에 따라 휴대폰 번호, 사업자등록번호, 현금영수증 카드 번호 등을 입력할 수 있습니다.
        /// 결제 고객의 정보가 없어도 상점에서 발급할 때 사용할 수 있는 국세청 지정 코드(010-000-1234)를 활용해 현금영수증을 발급할 수 있습니다.
        /// </summary>
        public required string CustomerIdentityNumber { get; set; }

        /// <summary>
        /// 면세 금액입니다. 값을 넣지 않으면 기본값인 0으로 설정됩니다. 하나의 결제에 과세 상품과 면세 상품이 섞여있다면 이 파라미터로 면세 상품 금액을 보내주세요. 보낸 금액 만큼 현금영수증이 발급됩니다.
        /// 면세 상점 혹은 복합 과세 상점일 때만 설정한 금액이 적용되고, 일반 과세 상점에는 적용되지 않습니다. 더 자세한 내용은 세금 처리하기에서 살펴보세요.
        /// </summary>
        public int TaxFreeAmount { get; set; }
    }
}
