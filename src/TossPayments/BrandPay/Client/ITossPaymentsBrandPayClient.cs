using TossPayments.BrandPay.Request;
using TossPayments.BrandPay.Response;
using TossPayments.Core.Response;

namespace TossPayments.BrandPay.Client
{
    public interface ITossPaymentsBrandPayClient : ITossPaymentsClientBase
    {
        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference/brandpay#%EB%AF%B8%EB%8F%99%EC%9D%98-%EC%95%BD%EA%B4%80-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="customerKey"></param>
        /// <param name="scope"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IAsyncEnumerable<Terms>> GetTermsAsync(string customerKey, TermsScope scope, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference/brandpay#%EC%95%BD%EA%B4%80-%EB%8F%99%EC%9D%98">문서 참조</see>
        /// </summary>
        /// <param name="customerKey"></param>
        /// <param name="scope"></param>
        /// <param name="termsId"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<AuthorizationCodeResponse> GetAuthorizationCodeAsync(string customerKey, TermsScope scope, IEnumerable<int> termsId, string? idempotencyKey = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference/brandpay#access-token-%EB%B0%9C%EA%B8%89">문서 참조</see>
        /// </summary>
        /// <param name="accessTokenRequest"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<AccessTokenResponse> GetAccessTokenAsync(AccessTokenRequest accessTokenRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference/brandpay#accesstoken%EC%9C%BC%EB%A1%9C-%EA%B2%B0%EC%A0%9C%EC%88%98%EB%8B%A8-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<BrandPayMethod> GetBrandPayMethodByAccessTokenAsync(string accessToken, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference/brandpay#secretkey%EB%A1%9C-%EA%B2%B0%EC%A0%9C%EC%88%98%EB%8B%A8-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="customerKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<BrandPayMethod> GetBrandPayMethodBySecretKeyAsync(string customerKey, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference/brandpay#%EC%B9%B4%EB%93%9C-%EA%B2%B0%EC%A0%9C%EC%88%98%EB%8B%A8-%EC%82%AD%EC%A0%9C">문서 참조</see>
        /// </summary>
        /// <param name="methodKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<BrandPayCard> RemoveBrandPayCardAsync(string accessToken, string methodKey, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference/brandpay#%EA%B3%84%EC%A2%8C-%EA%B2%B0%EC%A0%9C%EC%88%98%EB%8B%A8-%EC%82%AD%EC%A0%9C">문서 참조</see>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="methodKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<BrandPayBankAccount> RemoveBrandPayBankAccountAsync(string accessToken, string methodKey, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference/brandpay#%EA%B2%B0%EC%A0%9C-%EC%8A%B9%EC%9D%B8">문서 참조</see>
        /// </summary>
        /// <param name="paymentKey"></param>
        /// <param name="amount"></param>
        /// <param name="customerKey"></param>
        /// <param name="orderId"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Payment> ConfirmPaymentAsync(string paymentKey, int amount, string customerKey, string orderId, string? idempotencyKey = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference/brandpay#%EC%9E%90%EB%8F%99%EA%B2%B0%EC%A0%9C-%EC%8B%A4%ED%96%89">문서 참조</see>
        /// </summary>
        /// <param name="executeAutoPaymentRequest"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Payment> ExecuteAutoPaymentAsync(ExecuteAutoPaymentRequest executeAutoPaymentRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference/brandpay#%ED%9A%8C%EC%9B%90-%ED%83%88%ED%87%B4-%EC%B2%98%EB%A6%AC">문서 참조</see>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<RemoveCustomerResponse> RemoveCustomerAsync(string accessToken, string? idempotencyKey = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference/brandpay#%EC%B9%B4%EB%93%9C-%ED%94%84%EB%A1%9C%EB%AA%A8%EC%85%98-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<BrandPayCardPromotions> GetCardPromotionsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference/brandpay#%EA%B3%84%EC%A2%8C-%ED%94%84%EB%A1%9C%EB%AA%A8%EC%85%98-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<BrandPayBankPromotions> GetBankPromotionsAsync(CancellationToken cancellationToken = default);
    }
}