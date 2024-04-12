namespace TossPayments.Core.Models.Response
{
    public class Promotions
    {
        /// <summary>
        /// 결제 종류입니다.
        /// </summary>
        public PromotionsPayType PayType { get; set; }

        /// <summary>
        /// 프로모션 종류입니다. 아래 네 가지 값 중 하나가 돌아옵니다. 상세 정보는 type 이름과 같은 객체에 들어있습니다.
        /// </summary>
        public PromotionsType Type { get; set; }

        /// <summary>
        /// 카드사의 즉시 할인 정보입니다.
        /// </summary>
        public PromotionsCardDiscount? CardDiscount { get; set; }

        /// <summary>
        /// 카드 무이자 할부 정보입니다.
        /// </summary>
        public PromotionsCardInterestFree? CardInterestFree { get; set; }

        /// <summary>
        /// 카드 포인트 정보입니다.
        /// </summary>
        public PromotionsCardPoint? CardPoint { get; set; }

        /// <summary>
        /// 계좌 할인 정보입니다.
        /// </summary>
        public PromotionsBankDiscount? BankDiscount { get; set; }
    }
}