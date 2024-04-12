using Microsoft.Extensions.Options;

using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json.Nodes;

using TossPayments.BrandPay.Request;
using TossPayments.BrandPay.Response;
using TossPayments.Core.Models.Response;

namespace TossPayments.BrandPay.Client
{
    public class TossPaymentsBrandPayClient(HttpClient httpClient, IOptions<TossPaymentsClientOptions> options) : TossPaymentsClientBase(options)
    {
        private readonly HttpClient _httpClient = httpClient;

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference/brandpay#%EB%AF%B8%EB%8F%99%EC%9D%98-%EC%95%BD%EA%B4%80-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="customerKey"></param>
        /// <param name="scope"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IAsyncEnumerable<Terms>> GetTermsAsync(string customerKey, TermsScope scope, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/brandpay/terms?customerKey={0}";

            string encodedCustomerKey = UrlEncoder.Default.Encode(customerKey);
            string[] scopes = scope.ToString("G").Split(',', ' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            string urlWithQuery = string.Format(Url, encodedCustomerKey) + string.Join("&scope=", scopes);

            HttpRequestMessage request = CreateBasicRequestMessage(urlWithQuery, HttpMethod.Get);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            IAsyncEnumerable<Terms> terms = response.Content.ReadFromJsonAsAsyncEnumerable<Terms>()!;

            return terms;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference/brandpay#%EC%95%BD%EA%B4%80-%EB%8F%99%EC%9D%98">문서 참조</see>
        /// </summary>
        /// <param name="customerKey"></param>
        /// <param name="scope"></param>
        /// <param name="termsId"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string> GetAuthorizationCodeAsync(string customerKey, TermsScope scope, IEnumerable<int> termsId, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/brandpay/terms/agree";

            HttpRequestMessage request = CreateBasicRequestMessage(
                Url,
                HttpMethod.Post,
                new { customerKey, scope = scope.ToString("G").Split(',', ' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries), termsId },
                idempotencyKey);

            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            JsonNode? node = await JsonNode.ParseAsync(await response.Content.ReadAsStreamAsync());
            Debug.Assert(node is not null);

            return node["code"]!.GetValue<string>();
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference/brandpay#access-token-%EB%B0%9C%EA%B8%89">문서 참조</see>
        /// </summary>
        /// <param name="accessTokenRequest"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<AccessTokenResponse> GetAccessTokenAsync(AccessTokenRequest accessTokenRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/brandpay/authorizations/access-token";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Post, accessTokenRequest, idempotencyKey);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            AccessTokenResponse? accessTokenResponse = await response.Content.ReadFromJsonAsync<AccessTokenResponse>()!;
            Debug.Assert(accessTokenResponse is not null);

            return accessTokenResponse;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference/brandpay#accesstoken%EC%9C%BC%EB%A1%9C-%EA%B2%B0%EC%A0%9C%EC%88%98%EB%8B%A8-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BrandPayMethod> GetBrandPayMethodByAccessTokenAsync(string accessToken, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/brandpay/payments/methods";

            HttpRequestMessage request = CreateBearerRequestMessage(Url, HttpMethod.Get, accessToken);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            BrandPayMethod? brandPayMethod = await response.Content.ReadFromJsonAsync<BrandPayMethod>()!;
            Debug.Assert(brandPayMethod is not null);

            return brandPayMethod;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference/brandpay#secretkey%EB%A1%9C-%EA%B2%B0%EC%A0%9C%EC%88%98%EB%8B%A8-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="customerKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BrandPayMethod> GetBrandPayMethodBySecretKeyAsync(string customerKey, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/brandpay/payments/methods/{0}";

            HttpRequestMessage request = CreateBasicRequestMessage(string.Format(Url, customerKey), HttpMethod.Get);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            BrandPayMethod? brandPayMethod = await response.Content.ReadFromJsonAsync<BrandPayMethod>()!;
            Debug.Assert(brandPayMethod is not null);

            return brandPayMethod;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference/brandpay#%EC%B9%B4%EB%93%9C-%EA%B2%B0%EC%A0%9C%EC%88%98%EB%8B%A8-%EC%82%AD%EC%A0%9C">문서 참조</see>
        /// </summary>
        /// <param name="methodKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BrandPayCard> RemoveBrandPayCardAsync(string accessToken, string methodKey, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/brandpay/payments/methods/card/remove";

            HttpRequestMessage request = CreateBearerRequestMessage(Url, HttpMethod.Post, new { methodKey }, accessToken);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            BrandPayCard? brandPayCard = await response.Content.ReadFromJsonAsync<BrandPayCard>()!;
            Debug.Assert(brandPayCard is not null);

            return brandPayCard;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference/brandpay#%EA%B3%84%EC%A2%8C-%EA%B2%B0%EC%A0%9C%EC%88%98%EB%8B%A8-%EC%82%AD%EC%A0%9C">문서 참조</see>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="methodKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BrandPayBankAccount> RemoveBrandPayBankAccountAsync(string accessToken, string methodKey, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/brandpay/payments/methods/account/remove";

            HttpRequestMessage request = CreateBearerRequestMessage(Url, HttpMethod.Post, new { methodKey }, accessToken);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            BrandPayBankAccount? brandPayBankAccount = await response.Content.ReadFromJsonAsync<BrandPayBankAccount>()!;
            Debug.Assert(brandPayBankAccount is not null);

            return brandPayBankAccount;
        }

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
        public async Task<Payment> ConfirmPaymentAsync(string paymentKey, int amount, string customerKey, string orderId, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/brandpay/payments/confirm";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Post, new { paymentKey, amount, customerKey, orderId }, idempotencyKey);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            Payment? payment = await response.Content.ReadFromJsonAsync<Payment>()!;
            Debug.Assert(payment is not null);

            return payment;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference/brandpay#%EC%9E%90%EB%8F%99%EA%B2%B0%EC%A0%9C-%EC%8B%A4%ED%96%89">문서 참조</see>
        /// </summary>
        /// <param name="executeAutoPaymentRequest"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Payment> ExecuteAutoPaymentAsync(ExecuteAutoPaymentRequest executeAutoPaymentRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/brandpay/payments";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Post, executeAutoPaymentRequest, idempotencyKey);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            Payment? payment = await response.Content.ReadFromJsonAsync<Payment>();
            Debug.Assert(payment is not null);

            return payment;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference/brandpay#%ED%9A%8C%EC%9B%90-%ED%83%88%ED%87%B4-%EC%B2%98%EB%A6%AC">문서 참조</see>
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> RemoveCustomerAsync(string accessToken, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/brandpay/customers/remove";

            HttpRequestMessage request = CreateBearerRequestMessage(Url, HttpMethod.Post, accessToken, idempotencyKey);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            JsonNode? node = await JsonNode.ParseAsync(await response.Content.ReadAsStreamAsync());
            Debug.Assert(node is not null);

            return node["success"]!.GetValue<bool>();
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference/brandpay#%EC%B9%B4%EB%93%9C-%ED%94%84%EB%A1%9C%EB%AA%A8%EC%85%98-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BrandPayCardPromotions> GetCardPromotionsAsync(CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/brandpay/promotions/card";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Get);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            BrandPayCardPromotions? brandPayCardPromotions = await response.Content.ReadFromJsonAsync<BrandPayCardPromotions>()!;
            Debug.Assert(brandPayCardPromotions is not null);

            return brandPayCardPromotions;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference/brandpay#%EA%B3%84%EC%A2%8C-%ED%94%84%EB%A1%9C%EB%AA%A8%EC%85%98-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BrandPayBankPromotions> GetBankPromotionsAsync(CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/brandpay/promotions/bank";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Get);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            BrandPayBankPromotions? brandPayBankPromotions = await response.Content.ReadFromJsonAsync<BrandPayBankPromotions>()!;
            Debug.Assert(brandPayBankPromotions is not null);

            return brandPayBankPromotions;
        }
    }
}