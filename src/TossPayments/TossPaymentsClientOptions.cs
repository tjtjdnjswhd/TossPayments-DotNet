using System.Text;
using System.Text.Json;

namespace TossPayments
{
    public class TossPaymentsClientOptions
    {
        /// <summary>
        /// 콜론이 포함되지 않은 API Key.
        /// <see href="https://docs.tosspayments.com/reference/using-api/authorization#%EC%9D%B8%EC%A6%9D-%ED%97%A4%EB%8D%94">문서 참조</see>
        /// </summary>
        public required string SecretKey { get; set; }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference/using-api/authorization#%EC%98%81%EB%AC%B8%EC%9C%BC%EB%A1%9C-%EC%9D%91%EB%8B%B5%EB%B0%9B%EA%B8%B0">문서 참조</see>
        /// </summary>
        public required TossPaymentsResponseLanguage ResponseLanguage { get; set; }

        /// <summary>
        /// <see href="https://docs.tosspayments.com/reference/using-api/authorization#%ED%85%8C%EC%8A%A4%ED%8A%B8-%ED%99%98%EA%B2%BD%EC%97%90%EC%84%9C-%EC%97%90%EB%9F%AC-%EC%9E%AC%ED%98%84%ED%95%98%EA%B8%B0">문서 참조</see>
        /// </summary>
        public string? TestCode { get; set; }

        public JsonSerializerOptions? JsonSerializerOptions { get; set; }

        internal string Base64Key => Convert.ToBase64String(Encoding.UTF8.GetBytes($"{SecretKey}:"));
    }
}