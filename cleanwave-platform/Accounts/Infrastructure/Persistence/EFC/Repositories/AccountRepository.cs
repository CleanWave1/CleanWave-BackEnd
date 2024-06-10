using cleanwave_platform.Shared.Infraestructure.Persistence.EFC.Configuration;
using cleanwave_platform.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace cleanwave_platform.Accounts;

public class AccountRepository(AppDbContext context) : BaseRepository<Account>(context), IAccountRepository
{
    public Task<Account?> FindAccountByEmailAsync(EmailAdress email)
    {
        return Context.Set<Account>().Where(a => a.Email == email)
            .FirstOrDefaultAsync();
    }
}   