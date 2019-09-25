using APIGateway.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Domain
{
    public interface IBankRequest
    {
         PaymentRequest request { get; set; }
         long timestamp { get; }
    }
}
