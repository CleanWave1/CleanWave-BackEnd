using cleanwave_platform.Profiles.Domain.Model.Aggregates;
using cleanwave_platform.Profiles.Interfaces.REST.Resources;

namespace cleanwave_platform.Profiles.Interfaces.REST.Transform;

public class CleaningEntrepreneurResourceFromEntityAssembler
{
    public static CleaningEntrepreneurResource ToResourceFromEntity(CleaningEntrepreneur entity)
    {
        return new CleaningEntrepreneurResource(entity.Id, entity.Name, entity.Email, entity.Username);
    }
}