namespace _0_Framework.Utilities.ZarinPal
{
    public interface IZarinPalFactory
    {
        string Prefix { get; set; }

        PaymentResponse CreatePaymentRequest(long amount, string mobile, string description,
             long walletOperationId);

        VerificationResponse CreateVerificationRequest(string authority, string price);
    }
}