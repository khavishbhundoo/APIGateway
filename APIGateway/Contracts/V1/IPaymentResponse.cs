namespace APIGateway.Contracts.V1
{
    public interface IPaymentResponse
    {
        string Id { get; set; }

        string cardNo { get; set; }

        string expiry { get; set; }

        int amount { get; set; }

        string currency { get; set; }

        int cvv { get; set; }

        int response_code { get; set; }

        string markCardNumber(string cardNumber);

    }
}
