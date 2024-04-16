using Microsoft.Extensions.Options;

using System.Net.Http.Json;
using System.Text;
using System.Text.Encodings.Web;

using TossPayments.Core.Request;
using TossPayments.Core.Response;

using TossPayments.Extensions;

namespace TossPayments.Core.Client
{
    public class TossPaymentsCoreClient(HttpClient httpClient, IOptionsSnapshot<TossPaymentsClientOptions> options) :
        TossPaymentsClientBase(httpClient, options.Get(IServiceCollectionExtensions.TossPaymentsCoreOptionsName)),
        ITossPaymentsCoreClient
    {

        /// <inheritdoc/>
        public async Task<Payment> ConfirmPaymentAsync(string paymentKey, string orderId, decimal amount, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/payments/confirm";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Post, JsonContent.Create(new { paymentKey, orderId, amount }));
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            Payment payment = await DeserializeContentAsync<Payment>(response);
            return payment;
        }

        /// <inheritdoc/>
        public async Task<Payment> GetPaymentByPaymentKeyAsync(string paymentKey, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/payments/{0}";

            HttpRequestMessage request = CreateBasicRequestMessage(string.Format(Url, paymentKey), HttpMethod.Get, null);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            Payment payment = await DeserializeContentAsync<Payment>(response);
            return payment;
        }

        /// <inheritdoc/>
        public async Task<Payment> GetPaymentByOrderIdAsync(string orderId, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/payments/orders/{0}";

            HttpRequestMessage request = CreateBasicRequestMessage(string.Format(Url, orderId), HttpMethod.Get, null);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            Payment payment = await DeserializeContentAsync<Payment>(response);
            return payment;
        }

        /// <inheritdoc/>
        public async Task<Payment> CancelPaymentAsync(string paymentKey, CancelRequest cancelRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/payments/{0}/cancel";

            HttpRequestMessage request = CreateBasicRequestMessage(string.Format(Url, paymentKey), HttpMethod.Post, JsonContent.Create(cancelRequest), idempotencyKey);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            Payment payment = await DeserializeContentAsync<Payment>(response);
            return payment;
        }

        /// <inheritdoc/>
        public async Task<Payment> CreateVirtualAccountAsync(CreateVirtualAccountRequest createRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/virtual-accounts";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Post, JsonContent.Create(createRequest), idempotencyKey);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            Payment payment = await DeserializeContentAsync<Payment>(response);
            return payment;
        }

        /// <inheritdoc/>
        public async Task<Billing> CreateBillingKeyByCustomKeyAsync(CreateBillingKeyRequest billingRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/billing/authorizations/card";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Post, JsonContent.Create(billingRequest), idempotencyKey);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            Billing billing = await DeserializeContentAsync<Billing>(response);
            return billing;
        }

        /// <inheritdoc/>
        public async Task<Billing> CreateBillingKeyByAuthKeyAsync(string authKey, string customKey, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/billing/authorizations/issue";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Post, JsonContent.Create(new { authKey, customKey }), idempotencyKey);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            Billing billing = await DeserializeContentAsync<Billing>(response);
            return billing;
        }

        /// <inheritdoc/>
        public async Task<Billing> ConfirmBillingAsync(string billingKey, ConfirmBillingRequest confirmBillingRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/billing/{0}";

            HttpRequestMessage request = CreateBasicRequestMessage(string.Format(Url, billingKey), HttpMethod.Post, JsonContent.Create(confirmBillingRequest), idempotencyKey);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            Billing billing = await DeserializeContentAsync<Billing>(response);
            return billing;
        }

        /// <inheritdoc/>
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
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            IAsyncEnumerable<Transaction> transaction = DeserializeContents<Transaction>(response);
            return transaction;
        }

        /// <inheritdoc/>
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
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            IAsyncEnumerable<Settlement> settlements = DeserializeContents<Settlement>(response);
            return settlements;
        }

        /// <inheritdoc/>
        public async Task<bool> RequestManualSettlementAsync(string paymentKey, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/settlements";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Post, JsonContent.Create(new { paymentKey }), idempotencyKey);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            ManualSettlementResponse result = await DeserializeContentAsync<ManualSettlementResponse>(response);
            return result.Result;
        }

        /// <inheritdoc/>
        public async Task<CashReceipt> CreateCashReceiptAsync(CreateCashReceiptRequest createCashReceiptRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/cash-receipts";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Post, JsonContent.Create(createCashReceiptRequest), idempotencyKey);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            CashReceipt cashReceipt = await DeserializeContentAsync<CashReceipt>(response);
            return cashReceipt;
        }

        /// <inheritdoc/>
        public async Task<CashReceipt> CancelCashReceiptAsync(string receiptKey, int amount, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/cash-receipts/{0}/cancel";

            HttpRequestMessage request = CreateBasicRequestMessage(string.Format(Url, receiptKey), HttpMethod.Post, JsonContent.Create(new { amount }), idempotencyKey);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            CashReceipt cashReceipt = await DeserializeContentAsync<CashReceipt>(response);
            return cashReceipt;
        }

        /// <inheritdoc/>
        public async Task<GetCashReceiptsResponse> GetCashReceiptsAsync(DateOnly requestDate, int cursor, int limit, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/cash-receipts";

            StringBuilder sb = new(Url);
            sb.Append($"?requestDate={UrlEncoder.Default.Encode(requestDate.ToString("yyyy-MM-dd"))}");
            sb.Append($"&cursor={cursor}");
            sb.Append($"&limit={limit}");

            HttpRequestMessage request = CreateBasicRequestMessage(sb.ToString(), HttpMethod.Get, null);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            GetCashReceiptsResponse cashReceipts = await DeserializeContentAsync<GetCashReceiptsResponse>(response);
            return cashReceipts;
        }

        /// <inheritdoc/>
        public async Task<Submall> CreateSubmallAsync(CreateSubmallRequest createSubmallRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/payouts/sub-malls";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Post, JsonContent.Create(createSubmallRequest), idempotencyKey);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            Submall submall = await DeserializeContentAsync<Submall>(response);
            return submall;
        }

        /// <inheritdoc/>
        public async Task<IAsyncEnumerable<Submall>> GetSubmallsAsync(CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/payouts/sub-malls";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Get, null);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            IAsyncEnumerable<Submall> submalls = DeserializeContents<Submall>(response);
            return submalls;
        }

        /// <inheritdoc/>
        public async Task<Submall> UpdateSubmallAsync(string submallId, UpdateSubmallRequest updateSubmallRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/payouts/sub-malls/{0}";

            HttpRequestMessage request = CreateBasicRequestMessage(string.Format(Url, submallId), HttpMethod.Post, JsonContent.Create(updateSubmallRequest), idempotencyKey);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            Submall submall = await DeserializeContentAsync<Submall>(response);
            return submall;
        }

        /// <inheritdoc/>
        public async Task<string> DeleteSubmallAsync(string submallId, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/payouts/sub-malls/{0}/delete";

            HttpRequestMessage request = CreateBasicRequestMessage(string.Format(Url, submallId), HttpMethod.Post, idempotencyKey);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            string deletedSubmallId = await response.Content.ReadAsStringAsync();
            return deletedSubmallId;
        }

        /// <inheritdoc/>
        public async Task<int> GetSubmallSettlementsBalanceAsync(CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/payouts/sub-malls/settlements/balance";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Get, null);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            SubmallSettlementsBalanceResponse result = await DeserializeContentAsync<SubmallSettlementsBalanceResponse>(response);
            return result.Balance;
        }

        /// <inheritdoc/>
        public async Task<IAsyncEnumerable<Payout>> RequestPayoutAsync(RequestPayoutRequest requestPayoutRequest, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/payouts/sub-malls/settlements";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Post, JsonContent.Create(requestPayoutRequest), idempotencyKey);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            IAsyncEnumerable<Payout> payouts = DeserializeContents<Payout>(response);
            return payouts;
        }

        /// <inheritdoc/>
        public async Task<Payout> CancelRequestedPayoutAsync(string payoutKey, string? idempotencyKey = null, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/payouts/sub-malls/settlements/{0}/cancel";

            HttpRequestMessage request = CreateBasicRequestMessage(string.Format(Url, payoutKey), HttpMethod.Post, idempotencyKey);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            Payout payout = await DeserializeContentAsync<Payout>(response);
            return payout;
        }

        /// <inheritdoc/>
        public async Task<Payout> GetPayoutAsync(string payoutKey, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/payouts/sub-malls/settlements/{0}";

            HttpRequestMessage request = CreateBasicRequestMessage(string.Format(Url, payoutKey), HttpMethod.Get, null);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            Payout payout = await DeserializeContentAsync<Payout>(response);
            return payout;
        }

        /// <inheritdoc/>
        public async Task<IAsyncEnumerable<Payout>> GetPayoutsAsync(DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/payouts/sub-malls/settlements";

            StringBuilder sb = new(Url);
            sb.Append($"?startDate={UrlEncoder.Default.Encode(startDate.ToString("yyyy-MM-dd"))}");
            sb.Append($"&endDate={UrlEncoder.Default.Encode(endDate.ToString("yyyy-MM-dd"))}");

            HttpRequestMessage request = CreateBasicRequestMessage(sb.ToString(), HttpMethod.Get, null);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            IAsyncEnumerable<Payout> payouts = DeserializeContents<Payout>(response);
            return payouts;
        }

        /// <inheritdoc/>
        public async Task<IAsyncEnumerable<Promotions>> GetPromotionsAsync(CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/promotions";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Get, null);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            IAsyncEnumerable<Promotions> promotions = DeserializeContents<Promotions>(response);
            return promotions;
        }

        /// <inheritdoc/>
        public async Task<CardPromotion> GetCardPromotionAsync(CancellationToken cancellationToken = default)
        {
            const string Url = "/v1/promotions/card";

            HttpRequestMessage request = CreateBasicRequestMessage(Url, HttpMethod.Get, null);
            HttpResponseMessage response = await SendRequestAsync(request, cancellationToken);

            CardPromotion cardPromotion = await DeserializeContentAsync<CardPromotion>(response);
            return cardPromotion;
        }
    }
}