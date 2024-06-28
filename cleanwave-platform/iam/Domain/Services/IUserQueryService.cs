using cleanwave_platform.iam.Domain.Model.Aggregates;
using cleanwave_platform.iam.Domain.Model.Queries;

namespace cleanwave_platform.iam.Domain.Services;

public interface IUserQueryServices
{
    Task<User?> Handle(GetUserByIdQuery query);
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    Task<User?> Handle(GetUserByUsernameQuery query);
}