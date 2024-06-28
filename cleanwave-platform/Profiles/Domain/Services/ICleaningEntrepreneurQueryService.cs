using cleanwave_platform.Profiles.Domain.Model.Aggregates;
using cleanwave_platform.Profiles.Domain.Model.Entities;

namespace cleanwave_platform.Profiles.Domain.Services;

public interface ICleaningEntrepreneurQueryService
{
    Task<CleaningEntrepreneur?> Handle(GetCleaningEntrepreneurByIdQuery query);
    Task<CleaningEntrepreneur?> Handle(GetCleaningEntrepreneurByEmailQuery query);
}