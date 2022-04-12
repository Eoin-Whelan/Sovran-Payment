using PaymentService.Model.Accounts;

namespace PaymentService.Business
{
    public interface IPaymentAccountCreator
    {
        public string CreateAccount(PaymentRegistrationRequest email);
    }
}
