using cleanwave_platform.Profiles.Domain.Model.Aggregates;
using cleanwave_platform.Profiles.Domain.Model.Entities;
using cleanwave_platform.Profiles.Domain.Repositories;
using cleanwave_platform.Profiles.Domain.Services;

namespace cleanwave_platform.Profiles.Application.Internal.QueryServices;

public class CleaningEntrepreneurQueryService(ICleaningEntrepreneurRepository repository) : ICleaningEntrepreneurQueryService
{
    public async Task<CleaningEntrepreneur?> Handle(GetCleaningEntrepreneurByIdQuery query)
    {
        return await repository.FindCleaningEntrepreneurByIdAsync(query.Id);
    }

    public async Task<CleaningEntrepreneur?> Handle(GetCleaningEntrepreneurByEmailQuery query)
    {
        return await repository.FindCleaningEntrepreneurByEmailAsync(query.Email);
    }
}