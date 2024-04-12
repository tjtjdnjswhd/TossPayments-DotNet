namespace TossPayments
{
    public class RequestEventArgs(HttpRequestMessage requestMessage) : EventArgs
    {
        public HttpRequestMessage RequestMessage { get; } = requestMessage;
    }
}