using CadeOErro.Domain.Interfaces.Repositories;

namespace CadeOErro.Server.Util.Validatons
{
    public class EmailValidation
    {
        private readonly IUserRepository _repository;
        public EmailValidation(IUserRepository repository)
        {
            this._repository = repository;
        }

        public bool IsUnique(string email)
        {
            var entity = _repository.FindByEmail(email);

            if (entity != null) return false;
            return true;
        }
    }
}
