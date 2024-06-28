using cleanwave_platform.Profiles.Domain.Model.Aggregates;
using cleanwave_platform.Shared.Domain.Repositories;

namespace cleanwave_platform.Profiles.Domain.Repositories;

public interface ICustomerRepository: IBaseRepository<Customer>
{
    Task<Customer> FindCustomerByIdAsync(int customerId);
    Task<Customer> FindCustomerByEmailAsync(string email);
}