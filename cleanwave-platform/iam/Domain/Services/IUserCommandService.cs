using cleanwave_platform.iam.Domain.Model.Aggregates;
using cleanwave_platform.iam.Domain.Model.Commands;

namespace cleanwave_platform.iam.Domain.Services;

public interface IUserCommandService
{
    Task<(User user, string token)> Handle(SignInCommand command);

    Task Handle(SignUpCommand command);
}