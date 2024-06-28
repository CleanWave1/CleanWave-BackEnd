using cleanwave_platform.Profiles.Domain.Model.Aggregates;
using cleanwave_platform.Profiles.Domain.Model.Entities;
using cleanwave_platform.Profiles.Domain.Repositories;
using cleanwave_platform.Profiles.Domain.Services;

namespace cleanwave_platform.Profiles.Application.Internal.QueryServices;

public class CustomerQueryService(ICustomerRepository repository): ICustomerQueryService
{
    public async Task<Customer?> Handle(GetCustomerByIdQuery query)
    {
        return await repository.FindCustomerByIdAsync(query.CustomerId);
    }

    public async Task<Customer?> Handle(GetCustomerByEmailQuery query)
    {
        return await repository.FindCustomerByEmailAsync(query.Email);
    }
}