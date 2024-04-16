namespace TossPayments.Core.Request
{
    public class EscrowProductRequest
    {
        /// <summary>
        /// 상품의 ID입니다. 이 값은 유니크해야 합니다.
        /// </summary>
        public required string Id { get; set; }

        /// <summary>
        /// 상품 이름입니다.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// 상점에서 사용하는 상품 관리 코드입니다.
        /// </summary>
        public required string Code { get; set; }

        /// <summary>
        /// 상품의 가격입니다. 전체를 합한 가격이 아닌 상품의 개당 가격입니다.
        /// </summary>
        public required int UnitPrice { get; set; }

        /// <summary>
        /// 상품 구매 수량입니다.
        /// </summary>
        public required int Quantity { get; set; }
    }
}