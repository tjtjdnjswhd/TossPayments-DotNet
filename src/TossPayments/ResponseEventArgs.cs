namespace TossPayments
{
    public class ResponseEventArgs(HttpResponseMessage responseMessage) : EventArgs
    {
        public HttpResponseMessage ResponseMessage { get; } = responseMessage;
    }
}