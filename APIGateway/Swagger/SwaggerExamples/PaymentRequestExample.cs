using APIGateway.Contracts;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Swagger.SwaggerExamples
{
    public class PaymentRequestExample : IExamplesProvider<PaymentRequest>
    {
        public PaymentRequest GetExamples()
        {
            return new PaymentRequest
            {
                cardNo = "5356492507012290",
                expiry = "03/18",
                amount = 50,
                currency = "USD",
                cvv = 987
            };

        }
    }
}
