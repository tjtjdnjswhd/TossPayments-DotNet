namespace TossPayments.Core.Models.Response
{
    public class Account
    {
        public required string BankCode { get; set; }

        public required string AccountCode { get; set; }

        public string? HolderName { get; set; }
    }
}
