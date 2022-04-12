using PaymentService.Model.Accounts;

namespace PaymentService.Business
{
    public interface IAccountCreator
    {
        public string CreateAccount(RegistrationRequest email);
    }
}
