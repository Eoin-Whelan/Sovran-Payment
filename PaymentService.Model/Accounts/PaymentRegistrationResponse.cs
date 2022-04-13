using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Model.Accounts
{
    public class PaymentRegistrationResponse
    {
        public string? OnboardingUrl { get; set; }
        public string? StripeAccountNo { get; set; }
    }
}
