using Microsoft.Extensions.Configuration;
using Neo4jClient.Serialization;
using RestSharp;
using System.Text.Json;

namespace _0_Framework.Utilities.ZarinPal
{
    public class ZarinPalFactory : IZarinPalFactory
    {
        private readonly IConfiguration _configuration;

        public string Prefix { get; set; }
        private string MerchantId { get; }

        public ZarinPalFactory(IConfiguration configuration)
        {
            _configuration = configuration;
            Prefix = _configuration.GetSection("payment")["method"];
            MerchantId = _configuration.GetSection("payment")["merchant"];
        }

        public PaymentResponse CreatePaymentRequest(long amount, string mobile, string description,
             long walletOperationId)
        {
            var siteUrl = _configuration.GetSection("payment")["siteUrl"];

            var client = new RestClient($"https://{Prefix}.zarinpal.com/pg/rest/WebGate/PaymentRequest.json");
            var request = new RestRequest($"https://{Prefix}.zarinpal.com/pg/rest/WebGate/PaymentRequest.json",Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = new PaymentRequest
            {
                Mobile = mobile,
                CallbackURL = $"{siteUrl}/payment/callback&woId={walletOperationId}",
                Description = description,
                Amount = amount,
                MerchantID = MerchantId
            };
            request.AddJsonBody(body);
            var response = client.ExecuteAsync(request);
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true
            };
            return JsonSerializer.Deserialize<PaymentResponse>(response.ToString(), options);
        }

        public VerificationResponse CreateVerificationRequest(string authority, string amount)
        {
            var client = new RestClient($"https://{Prefix}.zarinpal.com/pg/rest/WebGate/PaymentVerification.json");
            var request = new RestRequest($"https://{Prefix}.zarinpal.com/pg/rest/WebGate/PaymentVerification.json",Method.Post);
            request.AddHeader("Content-Type", "application/json");

            amount = amount.Replace(",", "");
            var finalAmount = int.Parse(amount);

            request.AddJsonBody(new VerificationRequest
            {
                Amount = finalAmount,
                MerchantID = MerchantId,
                Authority = authority
            });
            var response = client.ExecuteAsync(request).ToString();
            var jsonSerializer = new CustomJsonSerializer();
            return jsonSerializer.Deserialize<VerificationResponse>(response);
        }

        
    }
}