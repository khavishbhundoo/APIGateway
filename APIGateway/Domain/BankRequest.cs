using APIGateway.Domain;
using System;

namespace APIGateway.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    public class BankRequest : IBankRequest
    {
        public long timestamp { get;  } = DateTimeOffset.Now.ToUnixTimeSeconds();

        public PaymentRequest request { get; set; }



    }
}
