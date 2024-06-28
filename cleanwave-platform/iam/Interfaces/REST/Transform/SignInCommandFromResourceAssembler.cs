using cleanwave_platform.iam.Domain.Model.Commands;
using cleanwave_platform.iam.Interfaces.REST.Resources;

namespace cleanwave_platform.iam.Interfaces.REST.Transform;

public class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}