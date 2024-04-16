namespace TossPayments.BrandPay.Response
{
    public class RemoveCustomerResponse
    {
        public required string CustomerKey { get; set; }

        public required bool Success { get; set; }
    }
}