namespace _0_Framework.Utilities.ZarinPal
{
    public class PaymentRequest
    {
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string CallbackURL { get; set; }
        public string Description { get; set; }
        public long Amount { get; set; }
        public string MerchantID { get; set; }
    }
}
