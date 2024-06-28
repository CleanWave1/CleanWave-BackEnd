using cleanwave_platform.iam.Domain.Model.Aggregates;
using cleanwave_platform.iam.Domain.Model.Queries;
using cleanwave_platform.iam.Domain.Repositories;
using cleanwave_platform.iam.Domain.Services;

namespace cleanwave_platform.iam.Application.QueryServices;

public class UserQueryServices(IUserRepository userRepository) : IUserQueryServices
{
    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.ListAsync();
    }

    public async Task<User?> Handle(GetUserByUsernameQuery query)
    {
        return await userRepository.FindByUsernameAsync(query.Username);
    }
}