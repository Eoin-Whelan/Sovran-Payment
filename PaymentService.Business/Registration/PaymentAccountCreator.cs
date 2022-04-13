using PaymentService.Model.Accounts;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Business
{
    
    public class PaymentAccountCreator : IPaymentAccountCreator
    {
        public PaymentAccountCreator()
        {

        }

        /// <summary>
        /// CreateAccount generates a Stripe Express account to associate with a merchant in the process
        /// of registering for an account.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PaymentRegistrationResponse CreateAccount(PaymentRegistrationRequest request)
        {
            StripeConfiguration.ApiKey = "sk_test_51K9bu8Dj019cdYs2M7Hi1N5YKVoh6uBQDkuP60ujyvytf6SOZ5D79TJy5vc7M3A5EcmJh6FJJEKHJtcIC5voKCOK00wn6z7kcj";
            StripeConfiguration.ClientId = "ca_KyWpw9XDq3mgjG2vRNzuYGEQFuBzqd98";
            try
            {
                var accountOptions = new AccountCreateOptions
                {
                    Type = "standard",
                    Country = "IE",
                    Email = request.EmailAddress,
                    BusinessType = "individual"
                };

                var accountService = new AccountService();
                var result = accountService.Create(accountOptions);


                var options = new AccountLinkCreateOptions
                {
                    Account = result.Id,
                    RefreshUrl = "https://example.com/reauth",
                    ReturnUrl = "https://example.com/return",
                    Type = "account_onboarding",
                };
                var service = new AccountLinkService();
                var newAccount = service.Create(options);

                PaymentRegistrationResponse response = new PaymentRegistrationResponse
                {
                    OnboardingUrl = newAccount.Url,
                    StripeAccountNo = result.Id
                };

                return response;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
