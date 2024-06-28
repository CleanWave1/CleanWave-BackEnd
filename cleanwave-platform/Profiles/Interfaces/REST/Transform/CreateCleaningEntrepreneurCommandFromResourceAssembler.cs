using cleanwave_platform.Profiles.Domain.Model.Commands;
using cleanwave_platform.Profiles.Interfaces.REST.Resources;

namespace cleanwave_platform.Profiles.Interfaces.REST.Transform;

public class CreateCleaningEntrepreneurCommandFromResourceAssembler
{
    public static CreateCleaningEntrepreneurCommand ToCommandFromResource(CreateCleaningEntrepreneurResource resource)
    {
        return new CreateCleaningEntrepreneurCommand(resource.Name, resource.Email, resource.Username);
    }
}