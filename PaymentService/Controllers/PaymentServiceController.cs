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
        private readonly IAccountCreator _accountCreator;

        public PaymentServiceController(ILogger<PaymentServiceController> logger, IAccountCreator accountCreator)
        {
            _logger = logger;
            _accountCreator = accountCreator;
        }


        [Route("RegisterAccount")]
        [HttpPost]
        public IActionResult RegisterAccount([FromBody] RegistrationRequest request)
        {
            try
            {
                _logger.LogInformation($"Payment beginning");

                var validatorResponse = _accountCreator.CreateAccount(request);

                JsonResult result = new JsonResult(validatorResponse);
                return result;
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