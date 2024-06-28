using cleanwave_platform.iam.Domain.Model.Aggregates;
using cleanwave_platform.Shared.Domain.Repositories;

namespace cleanwave_platform.iam.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);

    bool ExistsByUsername(string username);
}