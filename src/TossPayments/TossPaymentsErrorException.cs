namespace TossPayments
{
    public class TossPaymentsErrorException(TossPaymentsError error, int statusCode) : Exception(error.Message)
    {
        public int StatusCode { get; } = statusCode;
        public string Code { get; } = error.Code;
    }
}