using BankSimApi.Business.Interfaces;
using BankSimApi.Business.Models;
using BankSimApi.Business.Models.Validations;

namespace BankSimApi.Business.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, INotificator notificator) : base(notificator)
        {
            _userRepository = userRepository;
        }

        public async Task Create(User user)
        {
            if (!Validate(new UserValidation(), user)) return;

            if(_userRepository.Search(f => f.Email == user.Email).Result.Any())
            {
                Notificate("Email já utilizado.");
                return;
            }

            await _userRepository.Create(user);
        }

        public async Task Update(User user)
        {
            if (!Validate(new UserValidation(), user)) return;

            if (_userRepository.Search(f => f.Email == user.Email && f.Id != user.Id).Result.Any())
            {
                Notificate("Atualização de Email inválida. Email já utilizado.");
                return;
            }

            await _userRepository.Update(user);
        }

        public async Task Delete(Guid id)
        {
            var user = await _userRepository.GetById(id);
            if(user == null) 
            {
                Notificate("Usuário inexistente");
                return;

            }
            await _userRepository.Delete(id);
        }

        public void Dispose()
        {
            _userRepository.Dispose();
        }
    }
}
