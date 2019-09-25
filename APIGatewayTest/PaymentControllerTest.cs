using APIGateway.Contracts;
using APIGateway.Contracts.V1;
using APIGateway.Controllers;
using APIGateway.Domain;
using APIGateway.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APIGatewayTest
{
    [TestClass]
    public class PaymentControllerTest
    {
        private readonly ILogger<PaymentController> logger;

        [TestMethod]
        public void Get_Success()
        {
            //Arrange
            Post();
            PaymentController controller = new PaymentController(logger);
            //Act
            var result = controller.Get(PaymentController._payments[0].Id);
            //Assert
            Assert.IsTrue(result is OkObjectResult);
        }

        [TestMethod]
        public void Get_NotFound()
        {
            //Arrange
            PaymentController controller = new PaymentController(logger);
            //Act
            var result = controller.Get("04402d75-bea0-459a-9c6b-123456789");
            //Assert
            Assert.IsTrue(result is NotFoundResult);
        }

        [TestMethod]
        public void Post()
        {
            //Arrange
            IBankRequest bank_request = new BankRequest();

            IApiClient client = new MockAPIClient();

            IPaymentResponse res = new PaymentResponse();

            IHttpContextAccessor context = MockHttpContext.GetHttpContext("/","localhost");
            PaymentRequest request = new PaymentRequest
            {
                cardNo = "5356492507012290",
                expiry = "03/18",
                amount = 50,
                currency = "USD",
                cvv = 987
            };
            PaymentController controller = new PaymentController(logger);
            //Act
            controller.Post(request, bank_request, client, res,context);
            //Assert
            Assert.IsTrue(PaymentController._payments.Count > 0);
        }

    }
}
