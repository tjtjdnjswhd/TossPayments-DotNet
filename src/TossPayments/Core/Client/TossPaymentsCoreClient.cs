using Microsoft.Extensions.Options;

using System.Diagnostics;
using System.Net.Http.Json;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json.Nodes;

using TossPayments.Core.Models.Request;
using TossPayments.Core.Models.Response;

namespace TossPayments.Core.Client
{
    public class TossPaymentsCoreClient(HttpClient httpClient, IOptions<TossPaymentsClientOptions> options) : TossPaymentsClientBase(options)
    {
        private readonly HttpClient _httpClient = httpClient;

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EA%B2%B0%EC%A0%9C-%EC%8A%B9%EC%9D%B8">문서 참조</see> 
        /// </summary>
        /// <param name="paymentKey"></param>
        /// <param name="orderId"></param>
        /// <param name="amount"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Payment> ConfirmPaymentAsync(string paymentKey, string orderId, decimal amount, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/payments/confirm";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Post, JsonContent.Create(new { paymentKey, orderId, amount }));
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            Payment? payment = await response.Content.ReadFromJsonAsync<Payment>();
            Debug.Assert(payment != null);

            return payment;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#paymentkey%EB%A1%9C-%EA%B2%B0%EC%A0%9C-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="paymentKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Payment> GetPaymentByPaymentKeyAsync(string paymentKey, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/payments/{0}";

            HttpRequestMessage request = CreateBasicRequestMessage(string.Format(Url, paymentKey), HttpMethod.Get, null);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            Payment? payment = await response.Content.ReadFromJsonAsync<Payment>();
            Debug.Assert(payment != null);

            return payment;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#orderid%EB%A1%9C-%EA%B2%B0%EC%A0%9C-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Payment> GetPaymentByOrderIdAsync(string orderId, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/payments/orders/{0}";

            HttpRequestMessage request = CreateBasicRequestMessage(string.Format(Url, orderId), HttpMethod.Get, null);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            Payment? payment = await response.Content.ReadFromJsonAsync<Payment>();
            Debug.Assert(payment != null);

            return payment;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EA%B2%B0%EC%A0%9C-%EC%B7%A8%EC%86%8C">문서 참조</see>
        /// </summary>
        /// <param name="paymentKey"></param>
        /// <param name="cancelRequest"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Payment> CancelPaymentAsync(string paymentKey, CancelRequest cancelRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/payments/{0}/cancel";

            HttpRequestMessage request = CreateBasicRequestMessage(string.Format(Url, paymentKey), HttpMethod.Post, JsonContent.Create(cancelRequest), idempotencyKey);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            Payment? payment = await response.Content.ReadFromJsonAsync<Payment>();
            Debug.Assert(payment != null);

            return payment;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EA%B0%80%EC%83%81%EA%B3%84%EC%A2%8C-%EB%B0%9C%EA%B8%89-%EC%9A%94%EC%B2%AD">문서 참조</see>
        /// </summary>
        /// <param name="createRequest"></param>
        /// <returns></returns>
        public async Task<Payment> CreateVirtualAccountAsync(CreateVirtualAccountRequest createRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/virtual-accounts";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Post, JsonContent.Create(createRequest), idempotencyKey);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            Payment? payment = await response.Content.ReadFromJsonAsync<Payment>();
            Debug.Assert(payment != null);

            return payment;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#customerkey%EB%A1%9C-%EC%B9%B4%EB%93%9C-%EB%B9%8C%EB%A7%81%ED%82%A4-%EB%B0%9C%EA%B8%89">문서 참조</see>
        /// </summary>
        /// <param name="billingRequest"></param>
        /// <returns></returns>
        public async Task<Billing> CreateBillingKeyByCustomKeyAsync(CreateBillingKeyRequest billingRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/billing/authorizations/card";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Post, JsonContent.Create(billingRequest), idempotencyKey);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            Billing? billing = await response.Content.ReadFromJsonAsync<Billing>();
            Debug.Assert(billing != null);

            return billing;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#authkey%EB%A1%9C-%EC%B9%B4%EB%93%9C-%EB%B9%8C%EB%A7%81%ED%82%A4-%EB%B0%9C%EA%B8%89">문서 참조</see>
        /// </summary>
        /// <param name="authKey"></param>
        /// <param name="customKey"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Billing> CreateBillingKeyByAuthKeyAsync(string authKey, string customKey, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/billing/authorizations/issue";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Post, JsonContent.Create(new { authKey, customKey }), idempotencyKey);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            Billing? billing = await response.Content.ReadFromJsonAsync<Billing>();
            Debug.Assert(billing != null);

            return billing;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EC%B9%B4%EB%93%9C-%EC%9E%90%EB%8F%99%EA%B2%B0%EC%A0%9C-%EC%8A%B9%EC%9D%B8">문서 참조</see>
        /// </summary>
        /// <param name="billingKey"></param>
        /// <param name="confirmBillingRequest"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Billing> ConfirmBillingAsync(string billingKey, ConfirmBillingRequest confirmBillingRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/billing/{0}";

            HttpRequestMessage request = CreateBasicRequestMessage(string.Format(Url, billingKey), HttpMethod.Post, JsonContent.Create(confirmBillingRequest), idempotencyKey);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            Billing? billing = await response.Content.ReadFromJsonAsync<Billing>();
            Debug.Assert(billing != null);

            return billing;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EA%B1%B0%EB%9E%98-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="startingAfter"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<IAsyncEnumerable<Transaction>> GetTransactionsAsync(DateTime startDate, DateTime endDate, string? startingAfter, int limit, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/transactions";

            StringBuilder sb = new(Url);
            sb.Append($"?startDate={UrlEncoder.Default.Encode(startDate.ToString())}");
            sb.Append($"&endDate={UrlEncoder.Default.Encode(endDate.ToString())}");
            sb.Append($"&limit={limit}");
            if (startingAfter is not null)
            {
                sb.Append($"&startingAfter={UrlEncoder.Default.Encode(startingAfter)}");
            }

            HttpRequestMessage request = CreateBasicRequestMessage(sb.ToString(), HttpMethod.Get, null);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            IAsyncEnumerable<Transaction> transaction = response.Content.ReadFromJsonAsAsyncEnumerable<Transaction>()!;

            return transaction;
        }

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
        public async Task<IAsyncEnumerable<Settlement>> GetSettlementsAsync(DateOnly startDate, DateTime endDate, SettlementDateType dateType, int page, int size, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/settlements";

            StringBuilder sb = new(Url);
            sb.Append($"?startDate={UrlEncoder.Default.Encode(startDate.ToString("yyyy-MM-dd"))}");
            sb.Append($"&endDate={UrlEncoder.Default.Encode(endDate.ToString("yyyy-MM-dd"))}");
            sb.Append($"&dateType={dateType}");
            sb.Append($"&page={page}");
            sb.Append($"&size={size}");

            HttpRequestMessage request = CreateBasicRequestMessage(sb.ToString(), HttpMethod.Get, null);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            IAsyncEnumerable<Settlement> settlements = response.Content.ReadFromJsonAsAsyncEnumerable<Settlement>()!;

            return settlements;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EC%88%98%EB%8F%99-%EC%A0%95%EC%82%B0-%EC%9A%94%EC%B2%AD">문서 참조</see>
        /// </summary>
        /// <param name="paymentKey"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> RequestManualSettlementAsync(string paymentKey, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/settlements";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Post, JsonContent.Create(new { paymentKey }), idempotencyKey);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            ManualSettlementResponse? result = await response.Content.ReadFromJsonAsync<ManualSettlementResponse>();
            Debug.Assert(result != null);

            return result.Result;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%ED%98%84%EA%B8%88%EC%98%81%EC%88%98%EC%A6%9D-%EB%B0%9C%EA%B8%89-%EC%9A%94%EC%B2%AD">문서 참조</see>
        /// </summary>
        /// <param name="createCashReceiptRequest"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CashReceipt> CreateCashReceiptAsync(CreateCashReceiptRequest createCashReceiptRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/cash-receipts";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Post, JsonContent.Create(createCashReceiptRequest), idempotencyKey);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            CashReceipt? cashReceipt = await response.Content.ReadFromJsonAsync<CashReceipt>();
            Debug.Assert(cashReceipt != null);

            return cashReceipt;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%ED%98%84%EA%B8%88%EC%98%81%EC%88%98%EC%A6%9D-%EB%B0%9C%EA%B8%89-%EC%B7%A8%EC%86%8C-%EC%9A%94%EC%B2%AD">문서 참조</see>
        /// </summary>
        /// <param name="receiptKey"></param>
        /// <param name="amount"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CashReceipt> CancelCashReceiptAsync(string receiptKey, int amount, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/cash-receipts/{0}/cancel";

            HttpRequestMessage request = CreateBasicRequestMessage(string.Format(Url, receiptKey), HttpMethod.Post, JsonContent.Create(new { amount }), idempotencyKey);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            CashReceipt? cashReceipt = await response.Content.ReadFromJsonAsync<CashReceipt>();
            Debug.Assert(cashReceipt != null);

            return cashReceipt;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%ED%98%84%EA%B8%88%EC%98%81%EC%88%98%EC%A6%9D-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="requestDate"></param>
        /// <param name="cursor"></param>
        /// <param name="limit"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetCashReceiptsResponse> GetCashReceiptsAsync(DateOnly requestDate, int cursor, int limit, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/cash-receipts";

            StringBuilder sb = new(Url);
            sb.Append($"?requestDate={UrlEncoder.Default.Encode(requestDate.ToString("yyyy-MM-dd"))}");
            sb.Append($"&cursor={cursor}");
            sb.Append($"&limit={limit}");

            HttpRequestMessage request = CreateBasicRequestMessage(sb.ToString(), HttpMethod.Get, null);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            GetCashReceiptsResponse? cashReceipts = await response.Content.ReadFromJsonAsync<GetCashReceiptsResponse>();
            Debug.Assert(cashReceipts is not null);

            return cashReceipts;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EC%84%9C%EB%B8%8C%EB%AA%B0-%EB%93%B1%EB%A1%9D">문서 참조</see>
        /// </summary>
        /// <param name="createSubmallRequest"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Submall> CreateSubmallAsync(CreateSubmallRequest createSubmallRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/payouts/sub-malls";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Post, JsonContent.Create(createSubmallRequest), idempotencyKey);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            Submall? submall = await response.Content.ReadFromJsonAsync<Submall>();
            Debug.Assert(submall != null);

            return submall;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EC%84%9C%EB%B8%8C%EB%AA%B0-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IAsyncEnumerable<Submall>> GetSubmallsAsync(CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/payouts/sub-malls";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Get, null);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            IAsyncEnumerable<Submall> submalls = response.Content.ReadFromJsonAsAsyncEnumerable<Submall>()!;

            return submalls;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EC%84%9C%EB%B8%8C%EB%AA%B0-%EC%88%98%EC%A0%95">문서 참조</see>
        /// </summary>
        /// <param name="submallId"></param>
        /// <param name="updateSubmallRequest"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Submall> UpdateSubmallAsync(string submallId, UpdateSubmallRequest updateSubmallRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/payouts/sub-malls/{0}";

            HttpRequestMessage request = CreateBasicRequestMessage(string.Format(Url, submallId), HttpMethod.Post, JsonContent.Create(updateSubmallRequest), idempotencyKey);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            Submall? submall = await response.Content.ReadFromJsonAsync<Submall>();
            Debug.Assert(submall != null);

            return submall;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EC%84%9C%EB%B8%8C%EB%AA%B0-%EC%82%AD%EC%A0%9C">문서 참조</see>
        /// </summary>
        /// <param name="submallId"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string> DeleteSubmallAsync(string submallId, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/payouts/sub-malls/{0}/delete";

            HttpRequestMessage request = CreateBasicRequestMessage(string.Format(Url, submallId), HttpMethod.Post, idempotencyKey);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            string? deletedSubmallId = await response.Content.ReadAsStringAsync();
            Debug.Assert(deletedSubmallId != null);

            return deletedSubmallId;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EC%A7%80%EA%B8%89-%EA%B0%80%EB%8A%A5%ED%95%9C-%EC%9E%94%EC%95%A1-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> GetSubmallSettlementsBalanceAsync(CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/payouts/sub-malls/settlements/balance";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Get, null);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            JsonNode? jsonNode = await JsonNode.ParseAsync(await response.Content.ReadAsStreamAsync());
            Debug.Assert(jsonNode is not null);
            int balance = jsonNode["balance"]!.GetValue<int>();

            return balance;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EC%A7%80%EA%B8%89%EB%8C%80%ED%96%89-%EC%9A%94%EC%B2%AD">문서 참조</see>
        /// </summary>
        /// <param name="requestPayoutRequest"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IAsyncEnumerable<Payout>> RequestPayoutAsync(RequestPayoutRequest requestPayoutRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/payouts/sub-malls/settlements";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Post, JsonContent.Create(requestPayoutRequest), idempotencyKey);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            IAsyncEnumerable<Payout> payouts = response.Content.ReadFromJsonAsAsyncEnumerable<Payout>()!;

            return payouts;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EC%A7%80%EA%B8%89%EB%8C%80%ED%96%89-%EC%9A%94%EC%B2%AD-%EC%B7%A8%EC%86%8C">문서 참조</see>
        /// </summary>
        /// <param name="payoutKey"></param>
        /// <param name="idempotencyKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Payout> CancelRequestedPayoutAsync(string payoutKey, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/payouts/sub-malls/settlements/{0}/cancel";

            HttpRequestMessage request = CreateBasicRequestMessage(string.Format(Url, payoutKey), HttpMethod.Post, idempotencyKey);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            Payout? payout = await response.Content.ReadFromJsonAsync<Payout>();
            Debug.Assert(payout != null);

            return payout;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EC%A7%80%EA%B8%89%EB%8C%80%ED%96%89-%EB%8B%A8%EA%B1%B4-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="payoutKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Payout> GetPayoutAsync(string payoutKey, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/payouts/sub-malls/settlements/{0}";

            HttpRequestMessage request = CreateBasicRequestMessage(string.Format(Url, payoutKey), HttpMethod.Get, null);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            Payout? payout = await response.Content.ReadFromJsonAsync<Payout>();
            Debug.Assert(payout != null);

            return payout;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EC%A7%80%EA%B8%89%EB%8C%80%ED%96%89-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IAsyncEnumerable<Payout>> GetPayoutsAsync(DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/payouts/sub-malls/settlements";

            StringBuilder sb = new(Url);
            sb.Append($"?startDate={UrlEncoder.Default.Encode(startDate.ToString("yyyy-MM-dd"))}");
            sb.Append($"&endDate={UrlEncoder.Default.Encode(endDate.ToString("yyyy-MM-dd"))}");

            HttpRequestMessage request = CreateBasicRequestMessage(sb.ToString(), HttpMethod.Get, null);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            IAsyncEnumerable<Payout> payouts = response.Content.ReadFromJsonAsAsyncEnumerable<Payout>()!;

            return payouts;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EC%A0%84%EC%B2%B4-%ED%94%84%EB%A1%9C%EB%AA%A8%EC%85%98-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IAsyncEnumerable<Promotions>> GetPromotionsAsync(CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/promotions";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Get, null);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            IAsyncEnumerable<Promotions> promotions = response.Content.ReadFromJsonAsAsyncEnumerable<Promotions>()!;

            return promotions;
        }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference#%EC%B9%B4%EB%93%9C-%ED%94%84%EB%A1%9C%EB%AA%A8%EC%85%98-%EC%A1%B0%ED%9A%8C">문서 참조</see>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CardPromotion> GetCardPromotionAsync(CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/promotions/card";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Get, null);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            HandleResponseMessage(response);

            CardPromotion? cardPromotion = await response.Content.ReadFromJsonAsync<CardPromotion>();
            Debug.Assert(cardPromotion != null);

            return cardPromotion;
        }
    }
}