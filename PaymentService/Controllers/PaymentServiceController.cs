using Microsoft.AspNetCore.Mvc;
using PaymentService.Business;
using PaymentService.Model.Accounts;

namespace PaymentService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentServiceController : ControllerBase
    {
        private readonly ILogger<PaymentServiceController> _logger;
        private readonly IPaymentAccountCreator _accountCreator;

        public PaymentServiceController(ILogger<PaymentServiceController> logger, IPaymentAccountCreator accountCreator)
        {
            _logger = logger;
            _accountCreator = accountCreator;
        }


        [Route("RegisterAccount")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaymentRegistrationResponse))]
        [HttpPost]
        public ActionResult<PaymentRegistrationResponse> RegisterAccount([FromBody] PaymentRegistrationRequest request)
        {
            try
            {
                _logger.LogInformation($"Payment beginning");

                var validatorResponse = _accountCreator.CreateAccount(request);

                PaymentRegistrationResponse response = new PaymentRegistrationResponse
                {
                    OnboardingUrl = validatorResponse
                };
                return Ok(validatorResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError("Payment validation threw an exception : ", ex);

                JsonResult result = new JsonResult("Error:" + ex.Message);
                return (result);
            }
        }
    }
}