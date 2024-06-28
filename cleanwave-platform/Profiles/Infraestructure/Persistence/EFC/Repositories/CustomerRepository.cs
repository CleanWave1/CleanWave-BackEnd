using cleanwave_platform.Profiles.Domain.Model.Aggregates;
using cleanwave_platform.Profiles.Domain.Repositories;
using cleanwave_platform.Shared.Infraestructure.Persistence.EFC.Configuration;
using cleanwave_platform.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace cleanwave_platform.Profiles.Infraestructure.Persistence.EFC.Repositories;

public class CustomerRepository(AppDbContext context):BaseRepository<Customer>(context), ICustomerRepository
{
    public Task<Customer?> FindCustomerByIdAsync(int customerId)
    {
        return Context.Set<Customer>().Where(c => c.Id == customerId)
            .FirstOrDefaultAsync();
    }

    public Task<Customer?> FindCustomerByEmailAsync(string email)
    {
        return Context.Set<Customer>().Where(c => c.Email == email)
            .FirstOrDefaultAsync();
    }
}