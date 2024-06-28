using cleanwave_platform.Profiles.Domain.Model.Aggregates;
using cleanwave_platform.Profiles.Domain.Model.Commands;

namespace cleanwave_platform.Profiles.Domain.Services;

public interface ICustomerCommandService
{
    Task<Customer> Handle(CreateCustomerCommand command);
}