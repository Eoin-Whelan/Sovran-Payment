using PaymentService.Model.Accounts;

namespace PaymentService.Business
{
    public interface IPaymentAccountCreator
    {
        public PaymentRegistrationResponse CreateAccount(PaymentRegistrationRequest email);
    }
}
