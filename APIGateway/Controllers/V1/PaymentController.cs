using APIGateway.Contracts;
using APIGateway.Contracts.V1;
using APIGateway.Domain;
using APIGateway.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace APIGateway.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> logger;

        public PaymentController(ILogger<PaymentController> logger)
        {
            this.logger = logger;
        }

        public static List<IPaymentResponse> _payments = new List<IPaymentResponse>();

        /// <summary>
        /// Retrieve details of a payment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            foreach(IPaymentResponse payment in _payments)
            {
                if(payment.Id.Equals(id))
                {
                    return new OkObjectResult(payment);
                }
            }
            return NotFound();
        }

        /// <summary>
        /// Creates a payment request
        /// </summary>
        /// <param name="paymentDetails"></param>
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public IActionResult Post([FromBody] PaymentRequest paymentDetails, [FromServices] IBankRequest bank_request, [FromServices] IApiClient client, [FromServices] IPaymentResponse res, [FromServices] IHttpContextAccessor context)
        {

            this.logger.LogDebug("POST request : {PaymentRequest}", paymentDetails);

            /*
             * Step 1 - Make a POST request to the acquring Bank to valid the payment 
             */
            string bank_response_json = null;
            bank_request.request = paymentDetails;
            try
            {
                bank_response_json = client.Post("https://httpbin.org/post", JsonConvert.SerializeObject(bank_request), "application/json");

            }
            catch (Exception ex)
            {
                this.logger.LogError("Could not send the post.Details : {Exception}" , ex);
            }


            /*
             * Step 2 - Deserialize the response from bank 
             */
            var bank_response =  JsonConvert.DeserializeObject<BankResponse>(bank_response_json);
            var bank_response_data = JsonConvert.DeserializeObject<BankResponseData>(bank_response.Data);

            this.logger.LogDebug("bank_response : {BankResponse}", bank_response);

            this.logger.LogDebug("bank_response_data : {BankResponseData}", bank_response_data);


            /*
             * Step 3 - Create the response
             */
            res.Id = Guid.NewGuid().ToString();
            res.cardNo = bank_response_data.Request.CardNo;
            res.expiry = bank_response_data.Request.Expiry;
            res.amount = bank_response_data.Request.Amount;
            res.currency = bank_response_data.Request.Currency;
            res.cvv = bank_response_data.Request.Cvv;
            res.response_code = 201;
            /*
             * Add to payments collections
             */
            _payments.Add(res);

            /*
             * Send created response
             */
            string baseurl = $"{context.HttpContext.Request.Scheme}://{context.HttpContext.Request.Host.ToUriComponent()}";
            string locationUri = baseurl + '/' + "api/v1/Payment" + '/' + res.Id;
            return Created(locationUri, res);

        }
    }
}
