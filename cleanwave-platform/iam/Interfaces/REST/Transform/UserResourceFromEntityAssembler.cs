using cleanwave_platform.iam.Domain.Model.Aggregates;
using cleanwave_platform.iam.Interfaces.REST.Resources;

namespace cleanwave_platform.iam.Interfaces.REST.Transform;

public class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User user)
    {
        return new UserResource(user.Id, user.Username);
    }
}