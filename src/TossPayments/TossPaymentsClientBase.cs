using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace TossPayments
{
    public abstract class TossPaymentsClientBase(HttpClient httpClient, TossPaymentsClientOptions options) : ITossPaymentsClientBase
    {
        public event EventHandler<RequestEventArgs>? OnRequest;

        public event EventHandler<ResponseEventArgs>? OnResponse;

        protected HttpClient HttpClient { get; } = httpClient;

        protected TossPaymentsClientOptions Options { get; } = options;

        protected HttpRequestMessage CreateBasicRequestMessage(string url, HttpMethod method, string? idempotencyKey = null)
        {
            HttpRequestMessage httpRequestMessage = new(method, url);
            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", Options.Base64Key);
            ApplyOptions(httpRequestMessage);
            AddIdempotencyKey(httpRequestMessage, idempotencyKey);

            return httpRequestMessage;
        }

        protected HttpRequestMessage CreateBasicRequestMessage<T>(string url, HttpMethod method, T content, string? idempotencyKey = null)
        {
            HttpRequestMessage httpRequestMessage = new(method, url)
            {
                Content = JsonContent.Create(content, options: Options.JsonSerializerOptions)
            };

            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", Options.Base64Key);
            ApplyOptions(httpRequestMessage);
            AddIdempotencyKey(httpRequestMessage, idempotencyKey);

            return httpRequestMessage;
        }

        protected HttpRequestMessage CreateBearerRequestMessage(string url, HttpMethod method, string accessToken, string? idempotencyKey = null)
        {
            HttpRequestMessage httpRequestMessage = new(method, url);

            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            ApplyOptions(httpRequestMessage);
            AddIdempotencyKey(httpRequestMessage, idempotencyKey);

            return httpRequestMessage;
        }

        protected HttpRequestMessage CreateBearerRequestMessage<T>(string url, HttpMethod method, T content, string accessToken, string? idempotencyKey = null)
        {
            HttpRequestMessage httpRequestMessage = new(method, url)
            {
                Content = JsonContent.Create(content, options: Options.JsonSerializerOptions)
            };

            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            ApplyOptions(httpRequestMessage);
            AddIdempotencyKey(httpRequestMessage, idempotencyKey);

            return httpRequestMessage;
        }

        protected async Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage requestMessage, CancellationToken cancellationToken)
        {
            OnRequest?.Invoke(this, new RequestEventArgs(requestMessage));
            HttpResponseMessage responseMessage = await HttpClient.SendAsync(requestMessage, cancellationToken);
            OnResponse?.Invoke(this, new ResponseEventArgs(responseMessage));

            if (!responseMessage.IsSuccessStatusCode)
            {
                TossPaymentsError error = await DeserializeContentAsync<TossPaymentsError>(responseMessage);
                throw new TossPaymentsErrorException(error, (int)responseMessage.StatusCode);
            }
            return responseMessage;
        }

        protected async Task<T> DeserializeContentAsync<T>(HttpResponseMessage responseMessage)
        {
            T? result = await responseMessage.Content.ReadFromJsonAsync<T>(Options.JsonSerializerOptions);
            Debug.Assert(result is not null);
            return result;
        }

        protected IAsyncEnumerable<T> DeserializeContents<T>(HttpResponseMessage responseMessage)
        {
            IAsyncEnumerable<T?> result = responseMessage.Content.ReadFromJsonAsAsyncEnumerable<T>(Options.JsonSerializerOptions);
            Debug.Assert(result.ToBlockingEnumerable().All(t => t is not null));
            return result!;
        }

        private void ApplyOptions(HttpRequestMessage request)
        {
            if (Options.ResponseLanguage is TossPaymentsResponseLanguage.EN)
            {
                request.Headers.AcceptLanguage.Add(new StringWithQualityHeaderValue("en-US"));
            }

            if (Options.TestCode is not null)
            {
                request.Headers.Add("TossPayments-Test-Code", Options.TestCode);
            }
        }

        private static void AddIdempotencyKey(HttpRequestMessage requestMessage, string? idempotencyKey)
        {
            if (idempotencyKey is not null)
            {
                requestMessage.Headers.Add("Idempotency-Key", idempotencyKey);
            }
        }
    }
}