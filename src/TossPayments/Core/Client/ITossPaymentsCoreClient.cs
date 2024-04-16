using TossPayments.Core.Request;
using TossPayments.Core.Response;

namespace TossPayments.Core.Client
{
    public interface ITossPaymentsCoreClient : ITossPaymentsClientBase
    {
        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EA%B2%B0%EC%A0%9C-%EC%8A%B9%EC%9D%B8">문서 참조</see> 
        /// </summary>
        /// <param name="paymentKey"></param>
        /// <param name="orderId"></param>
        /// <param name="amount"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Payment> ConfirmPaymentAsync(string paymentKey, string orderId, decimal amount, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#paymentkey%EB%A1%9C-%EA%B2%B0%EC%A0%9C-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="paymentKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Payment> GetPaymentByPaymentKeyAsync(string paymentKey, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#orderid%EB%A1%9C-%EA%B2%B0%EC%A0%9C-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Payment> GetPaymentByOrderIdAsync(string orderId, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EA%B2%B0%EC%A0%9C-%EC%B7%A8%EC%86%8C">문서 참조</see>
        /// </summary>
        /// <param name="paymentKey"></param>
        /// <param name="cancelRequest"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Payment> CancelPaymentAsync(string paymentKey, CancelRequest cancelRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EA%B0%80%EC%83%81%EA%B3%84%EC%A2%8C-%EB%B0%9C%EA%B8%89-%EC%9A%94%EC%B2%AD">문서 참조</see>
        /// </summary>
        /// <param name="createRequest"></param>
        /// <returns></returns>
        public Task<Payment> CreateVirtualAccountAsync(CreateVirtualAccountRequest createRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#customerkey%EB%A1%9C-%EC%B9%B4%EB%93%9C-%EB%B9%8C%EB%A7%81%ED%82%A4-%EB%B0%9C%EA%B8%89">문서 참조</see>
        /// </summary>
        /// <param name="billingRequest"></param>
        /// <returns></returns>
        public Task<Billing> CreateBillingKeyByCustomKeyAsync(CreateBillingKeyRequest billingRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#authkey%EB%A1%9C-%EC%B9%B4%EB%93%9C-%EB%B9%8C%EB%A7%81%ED%82%A4-%EB%B0%9C%EA%B8%89">문서 참조</see>
        /// </summary>
        /// <param name="authKey"></param>
        /// <param name="customKey"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Billing> CreateBillingKeyByAuthKeyAsync(string authKey, string customKey, string? idempotencyKey = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EC%B9%B4%EB%93%9C-%EC%9E%90%EB%8F%99%EA%B2%B0%EC%A0%9C-%EC%8A%B9%EC%9D%B8">문서 참조</see>
        /// </summary>
        /// <param name="billingKey"></param>
        /// <param name="confirmBillingRequest"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Billing> ConfirmBillingAsync(string billingKey, ConfirmBillingRequest confirmBillingRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EA%B1%B0%EB%9E%98-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="startingAfter"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public Task<IAsyncEnumerable<Transaction>> GetTransactionsAsync(DateTime startDate, DateTime endDate, string? startingAfter, int limit, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EC%A0%95%EC%82%B0-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="dateType"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IAsyncEnumerable<Settlement>> GetSettlementsAsync(DateOnly startDate, DateTime endDate, SettlementDateType dateType, int page, int size, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EC%88%98%EB%8F%99-%EC%A0%95%EC%82%B0-%EC%9A%94%EC%B2%AD">문서 참조</see>
        /// </summary>
        /// <param name="paymentKey"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<bool> RequestManualSettlementAsync(string paymentKey, string? idempotencyKey = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%ED%98%84%EA%B8%88%EC%98%81%EC%88%98%EC%A6%9D-%EB%B0%9C%EA%B8%89-%EC%9A%94%EC%B2%AD">문서 참조</see>
        /// </summary>
        /// <param name="createCashReceiptRequest"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<CashReceipt> CreateCashReceiptAsync(CreateCashReceiptRequest createCashReceiptRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%ED%98%84%EA%B8%88%EC%98%81%EC%88%98%EC%A6%9D-%EB%B0%9C%EA%B8%89-%EC%B7%A8%EC%86%8C-%EC%9A%94%EC%B2%AD">문서 참조</see>
        /// </summary>
        /// <param name="receiptKey"></param>
        /// <param name="amount"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<CashReceipt> CancelCashReceiptAsync(string receiptKey, int amount, string? idempotencyKey = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%ED%98%84%EA%B8%88%EC%98%81%EC%88%98%EC%A6%9D-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="requestDate"></param>
        /// <param name="cursor"></param>
        /// <param name="limit"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<GetCashReceiptsResponse> GetCashReceiptsAsync(DateOnly requestDate, int cursor, int limit, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EC%84%9C%EB%B8%8C%EB%AA%B0-%EB%93%B1%EB%A1%9D">문서 참조</see>
        /// </summary>
        /// <param name="createSubmallRequest"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Submall> CreateSubmallAsync(CreateSubmallRequest createSubmallRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EC%84%9C%EB%B8%8C%EB%AA%B0-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IAsyncEnumerable<Submall>> GetSubmallsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EC%84%9C%EB%B8%8C%EB%AA%B0-%EC%88%98%EC%A0%95">문서 참조</see>
        /// </summary>
        /// <param name="submallId"></param>
        /// <param name="updateSubmallRequest"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Submall> UpdateSubmallAsync(string submallId, UpdateSubmallRequest updateSubmallRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EC%84%9C%EB%B8%8C%EB%AA%B0-%EC%82%AD%EC%A0%9C">문서 참조</see>
        /// </summary>
        /// <param name="submallId"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<string> DeleteSubmallAsync(string submallId, string? idempotencyKey = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EC%A7%80%EA%B8%89-%EA%B0%80%EB%8A%A5%ED%95%9C-%EC%9E%94%EC%95%A1-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int> GetSubmallSettlementsBalanceAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EC%A7%80%EA%B8%89%EB%8C%80%ED%96%89-%EC%9A%94%EC%B2%AD">문서 참조</see>
        /// </summary>
        /// <param name="requestPayoutRequest"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IAsyncEnumerable<Payout>> RequestPayoutAsync(RequestPayoutRequest requestPayoutRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EC%A7%80%EA%B8%89%EB%8C%80%ED%96%89-%EC%9A%94%EC%B2%AD-%EC%B7%A8%EC%86%8C">문서 참조</see>
        /// </summary>
        /// <param name="payoutKey"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Payout> CancelRequestedPayoutAsync(string payoutKey, string? idempotencyKey = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EC%A7%80%EA%B8%89%EB%8C%80%ED%96%89-%EB%8B%A8%EA%B1%B4-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="payoutKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Payout> GetPayoutAsync(string payoutKey, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EC%A7%80%EA%B8%89%EB%8C%80%ED%96%89-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IAsyncEnumerable<Payout>> GetPayoutsAsync(DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken = default);


        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EC%A0%84%EC%B2%B4-%ED%94%84%EB%A1%9C%EB%AA%A8%EC%85%98-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IAsyncEnumerable<Promotions>> GetPromotionsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EC%B9%B4%EB%93%9C-%ED%94%84%EB%A1%9C%EB%AA%A8%EC%85%98-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<CardPromotion> GetCardPromotionAsync(CancellationToken cancellationToken = default);
    }
}