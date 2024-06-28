using cleanwave_platform.iam.Domain.Model.Commands;
using cleanwave_platform.iam.Interfaces.REST.Resources;

namespace cleanwave_platform.iam.Interfaces.REST.Transform;

public class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password);
    }
}