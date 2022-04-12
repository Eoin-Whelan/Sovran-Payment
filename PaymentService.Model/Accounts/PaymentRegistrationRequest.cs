using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Model.Accounts
{
    public class PaymentRegistrationRequest
    {
        [Required(ErrorMessage = "Missing Info : EmailAddress")]
        public string EmailAddress { get; set; }
    }
}
