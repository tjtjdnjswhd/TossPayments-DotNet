using Microsoft.Extensions.Options;

using System.Text.Encodings.Web;

using TossPayments.BrandPay.Request;
using TossPayments.BrandPay.Response;
using TossPayments.Core.Response;
using TossPayments.Extensions;

namespace TossPayments.BrandPay.Client
{
    public class TossPaymentsBrandPayClient(HttpClient httpClient, IOptionsSnapshot<TossPaymentsClientOptions> options) :
        TossPaymentsClientBase(httpClient, options.Get(IServiceCollectionExtensions.TossPaymentsBrandPayOptionsName)),
        ITossPaymentsBrandPayClient
    {
        /// <inheritdoc/>
        public async Task<IAsyncEnumerable<Terms>> GetTermsAsync(string customerKey, TermsScope scope, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/brandpay/terms?customerKey={0}";

            string encodedCustomerKey = UrlEncoder.Default.Encode(customerKey);
            string[] scopes = scope.ToString("G").Split(',', ' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            string urlWithQuery = string.Format(Url, encodedCustomerKey) + string.Join("&scope=", scopes);

            HttpRequestMessage request = CreateBasicRequestMessage(urlWithQuery, HttpMethod.Get);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            IAsyncEnumerable<Terms> terms = DeserializeContents<Terms>(response)!;
            return terms;
        }

        /// <inheritdoc/>
        public async Task<AuthorizationCodeResponse> GetAuthorizationCodeAsync(string customerKey, TermsScope scope, IEnumerable<int> termsId, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/brandpay/terms/agree";

            HttpRequestMessage request = CreateBasicRequestMessage(
                Url,
                HttpMethod.Post,
                new { customerKey, scope = scope.ToString("G").Split(',', ' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries), termsId },
                idempotencyKey);

            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            AuthorizationCodeResponse code = await DeserializeContentAsync<AuthorizationCodeResponse>(response);
            return code;
        }

        /// <inheritdoc/>
        public async Task<AccessTokenResponse> GetAccessTokenAsync(AccessTokenRequest accessTokenRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/brandpay/authorizations/access-token";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Post, accessTokenRequest, idempotencyKey);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            AccessTokenResponse accessTokenResponse = await DeserializeContentAsync<AccessTokenResponse>(response)!;
            return accessTokenResponse;
        }

        /// <inheritdoc/>
        public async Task<BrandPayMethod> GetBrandPayMethodByAccessTokenAsync(string accessToken, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/brandpay/payments/methods";

            HttpRequestMessage request = CreateBearerRequestMessage(Url, HttpMethod.Get, accessToken);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            BrandPayMethod brandPayMethod = await DeserializeContentAsync<BrandPayMethod>(response)!;
            return brandPayMethod;
        }

        /// <inheritdoc/>
        public async Task<BrandPayMethod> GetBrandPayMethodBySecretKeyAsync(string customerKey, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/brandpay/payments/methods/{0}";

            HttpRequestMessage request = CreateBasicRequestMessage(string.Format(Url, customerKey), HttpMethod.Get);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            BrandPayMethod brandPayMethod = await DeserializeContentAsync<BrandPayMethod>(response)!;
            return brandPayMethod;
        }

        /// <inheritdoc/>
        public async Task<BrandPayCard> RemoveBrandPayCardAsync(string accessToken, string methodKey, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/brandpay/payments/methods/card/remove";

            HttpRequestMessage request = CreateBearerRequestMessage(Url, HttpMethod.Post, new { methodKey }, accessToken);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            BrandPayCard brandPayCard = await DeserializeContentAsync<BrandPayCard>(response)!;
            return brandPayCard;
        }

        /// <inheritdoc/>
        public async Task<BrandPayBankAccount> RemoveBrandPayBankAccountAsync(string accessToken, string methodKey, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/brandpay/payments/methods/account/remove";

            HttpRequestMessage request = CreateBearerRequestMessage(Url, HttpMethod.Post, new { methodKey }, accessToken);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            BrandPayBankAccount brandPayBankAccount = await DeserializeContentAsync<BrandPayBankAccount>(response)!;
            return brandPayBankAccount;
        }

        /// <inheritdoc/>
        public async Task<Payment> ConfirmPaymentAsync(string paymentKey, int amount, string customerKey, string orderId, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/brandpay/payments/confirm";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Post, new { paymentKey, amount, customerKey, orderId }, idempotencyKey);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            Payment payment = await DeserializeContentAsync<Payment>(response)!;
            return payment;
        }

        /// <inheritdoc/>
        public async Task<Payment> ExecuteAutoPaymentAsync(ExecuteAutoPaymentRequest executeAutoPaymentRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/brandpay/payments";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Post, executeAutoPaymentRequest, idempotencyKey);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            Payment payment = await DeserializeContentAsync<Payment>(response);
            return payment;
        }

        /// <inheritdoc/>
        public async Task<RemoveCustomerResponse> RemoveCustomerAsync(string accessToken, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/brandpay/customers/remove";

            HttpRequestMessage request = CreateBearerRequestMessage(Url, HttpMethod.Post, accessToken, idempotencyKey);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            RemoveCustomerResponse result = await DeserializeContentAsync<RemoveCustomerResponse>(response);
            return result;
        }

        /// <inheritdoc/>
        public async Task<BrandPayCardPromotions> GetCardPromotionsAsync(CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/brandpay/promotions/card";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Get);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            BrandPayCardPromotions brandPayCardPromotions = await DeserializeContentAsync<BrandPayCardPromotions>(response)!;
            return brandPayCardPromotions;
        }

        /// <inheritdoc/>
        public async Task<BrandPayBankPromotions> GetBankPromotionsAsync(CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/brandpay/promotions/bank";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Get);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            BrandPayBankPromotions brandPayBankPromotions = await DeserializeContentAsync<BrandPayBankPromotions>(response)!;
            return brandPayBankPromotions;
        }
    }
}