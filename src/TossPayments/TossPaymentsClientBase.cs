using Microsoft.Extensions.Options;

using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace TossPayments
{
    public abstract class TossPaymentsClientBase(IOptions<TossPaymentsClientOptions> options)
    {
        protected TossPaymentsClientOptions Options => options.Value;

        public event EventHandler<RequestEventArgs>? OnRequest;

        public event EventHandler<ResponseEventArgs>? OnResponse;

        protected HttpRequestMessage CreateBasicRequestMessage(string url, HttpMethod method, string? idempotencyKey = null)
        {
            HttpRequestMessage httpRequestMessage = new(method, url);
            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", Options.Base64Key);
            ApplyOptions(httpRequestMessage);
            AddIdempotencyKey(httpRequestMessage, idempotencyKey);
            HandleRequestMessage(httpRequestMessage);

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
            HandleRequestMessage(httpRequestMessage);

            return httpRequestMessage;
        }

        protected HttpRequestMessage CreateBearerRequestMessage(string url, HttpMethod method, string accessToken, string? idempotencyKey = null)
        {
            HttpRequestMessage httpRequestMessage = new(method, url);

            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            ApplyOptions(httpRequestMessage);
            AddIdempotencyKey(httpRequestMessage, idempotencyKey);
            HandleRequestMessage(httpRequestMessage);

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
            HandleRequestMessage(httpRequestMessage);

            return httpRequestMessage;
        }

        protected void HandleRequestMessage(HttpRequestMessage requestMessage)
        {
            OnRequest?.Invoke(this, new RequestEventArgs(requestMessage));
        }

        protected void HandleResponseMessage(HttpResponseMessage responseMessage)
        {
            OnResponse?.Invoke(this, new ResponseEventArgs(responseMessage));
            if (!responseMessage.IsSuccessStatusCode)
            {
                TossPaymentsError error = responseMessage.Content.ReadFromJsonAsync<TossPaymentsError>().Result!;
                throw new TossPaymentsErrorException(error, (int)responseMessage.StatusCode);
            }
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