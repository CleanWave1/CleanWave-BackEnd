using cleanwave_platform.Profiles.Domain.Model.Aggregates;
using cleanwave_platform.Profiles.Domain.Model.Commands;

namespace cleanwave_platform.Profiles.Domain.Services;

public interface ICleaningEntrepreneurCommandService
{
    Task<CleaningEntrepreneur> Handle(CreateCleaningEntrepreneurCommand command);
}