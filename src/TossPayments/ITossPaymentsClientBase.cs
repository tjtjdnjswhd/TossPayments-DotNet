namespace TossPayments
{
    public interface ITossPaymentsClientBase
    {
        public event EventHandler<RequestEventArgs>? OnRequest;
        public event EventHandler<ResponseEventArgs>? OnResponse;
    }
}