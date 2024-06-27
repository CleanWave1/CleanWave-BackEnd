using cleanwave_platform.Shared.Domain.Repositories;

namespace cleanwave_platform.Accounts;

public interface IAccountRepository : IBaseRepository<Account>
{
    Task<Account> FindAccountByEmailAsync(EmailAdress email);
}