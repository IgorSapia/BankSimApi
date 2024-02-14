using BankSimApi.Business.Models;

namespace BankSimApi.Business.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task Create(User user);
        Task Update(User user);
        Task Delete(Guid id);
    }
}
