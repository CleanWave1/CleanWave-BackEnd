using cleanwave_platform.Accounts;
using cleanwave_platform.Profiles.Domain.Model.Aggregates;
using cleanwave_platform.Profiles.Interfaces.REST.Resources;

namespace cleanwave_platform.Profiles.Interfaces.REST.Transform;

public class CustomerResourceFromEntityAssembler
{
    public static CustomerResource ToResourceFromEntity(Customer entity)
    {
        return new CustomerResource(entity.Id, entity.Name, entity.LastName, entity.Email, entity.Phone, entity.Space);
    }
}