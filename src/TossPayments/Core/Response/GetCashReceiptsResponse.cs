namespace TossPayments.Core.Response
{
    public class GetCashReceiptsResponse
    {
        public required bool HasNext { get; set; }

        public required int LastCursor { get; set; }

        public required CashReceipt[] Data { get; set; }
    }
}