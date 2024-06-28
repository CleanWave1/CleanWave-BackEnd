using cleanwave_platform.iam.Domain.Model.Aggregates;
using cleanwave_platform.iam.Domain.Repositories;
using cleanwave_platform.Shared.Infraestructure.Persistance.EFC.Configuration;
using cleanwave_platform.Shared.Infraestructure.Persistance.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace cleanwave_platform.iam.Infrastructure.Persistence.EFC.Repositories;

public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
{
    public async Task<User?> FindByUsernameAsync(string username)
    {
        return await Context.Set<User>().FirstOrDefaultAsync(user => user.Username.Equals(username));
    }
    
    public bool ExistsByUsername(string username)
    {
        return Context.Set<User>().Any(user => user.Username.Equals(username));
    }
}