using cleanwave_platform.iam.Domain.Model.Aggregates;
using cleanwave_platform.iam.Interfaces.REST.Resources;

namespace cleanwave_platform.iam.Interfaces.REST.Transform;

public class AuthenticatedUserResourceFromEntotyAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(User user, string token)
    {
        return new AuthenticatedUserResource(user.Id, user.Username, token);
    }
}