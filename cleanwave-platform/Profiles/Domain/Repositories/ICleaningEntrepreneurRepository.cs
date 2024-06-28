using cleanwave_platform.Profiles.Domain.Model.Aggregates;
using cleanwave_platform.Shared.Domain.Repositories;

namespace cleanwave_platform.Profiles.Domain.Repositories;

public interface ICleaningEntrepreneurRepository : IBaseRepository<CleaningEntrepreneur>
{
    Task<CleaningEntrepreneur> FindCleaningEntrepreneurByIdAsync(int id);
    Task<CleaningEntrepreneur> FindCleaningEntrepreneurByEmailAsync(string email);
}