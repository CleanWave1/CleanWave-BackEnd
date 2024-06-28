using cleanwave_platform.Profiles.Domain.Model.Aggregates;
using cleanwave_platform.Profiles.Domain.Model.Entities;

namespace cleanwave_platform.Profiles.Domain.Services;

public interface ICustomerQueryService
{
    Task<Customer?> Handle(GetCustomerByIdQuery query);
    Task<Customer?> Handle(GetCustomerByEmailQuery query);
}