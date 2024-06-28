using cleanwave_platform.Profiles.Domain.Model.Aggregates;
using cleanwave_platform.Profiles.Domain.Model.Commands;
using cleanwave_platform.Profiles.Domain.Repositories;
using cleanwave_platform.Profiles.Domain.Services;
using cleanwave_platform.Shared.Domain.Repositories;

namespace cleanwave_platform.Profiles.Application.Internal.CommandServices;

public class CleaningEntrepreneurCommandService(ICleaningEntrepreneurRepository repository, IUnitOfWork unitOfWork) : ICleaningEntrepreneurCommandService
{
    public async Task<CleaningEntrepreneur> Handle(CreateCleaningEntrepreneurCommand command)
    {
        var entrepreneur = new CleaningEntrepreneur(command);
        try
        {
            await repository.AddSync(entrepreneur);
            await unitOfWork.CompleteAsync();
            return entrepreneur;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occured while creating the entrepreneur:  {e.Message}");
            return null;
        }
    }
}