using cleanwave_platform.Profiles.Domain.Model.Aggregates;
using cleanwave_platform.Profiles.Domain.Model.Commands;
using cleanwave_platform.Profiles.Domain.Repositories;
using cleanwave_platform.Profiles.Domain.Services;
using cleanwave_platform.Shared.Domain.Repositories;

namespace cleanwave_platform.Profiles.Application.Internal.CommandServices;

public class CustomerCommandService(ICustomerRepository repository, IUnitOfWork unitOfWork) : ICustomerCommandService
{
    public async Task<Customer> Handle(CreateCustomerCommand command)
    {
        var customer = new Customer(command);
        try
        {
            await repository.AddSync(customer);
            await unitOfWork.CompleteAsync();
            return customer;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occured while creating the customer:  {e.Message}");
            return null;
        }
    }
}