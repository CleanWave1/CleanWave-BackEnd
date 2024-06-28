using cleanwave_platform.Profiles.Domain.Model.Aggregates;
using cleanwave_platform.Profiles.Domain.Repositories;
using cleanwave_platform.Shared.Infraestructure.Persistence.EFC.Configuration;
using cleanwave_platform.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace cleanwave_platform.Profiles.Infraestructure.Persistence.EFC.Repositories;

public class CleaningEntrepreneurRepository(AppDbContext context):BaseRepository<CleaningEntrepreneur>(context), ICleaningEntrepreneurRepository
{
    public Task<CleaningEntrepreneur?> FindCleaningEntrepreneurByIdAsync(int id)
    {
        return Context.Set<CleaningEntrepreneur>().Where(c => c.Id == id)
            .FirstOrDefaultAsync();
    }

    public Task<CleaningEntrepreneur?> FindCleaningEntrepreneurByEmailAsync(string email)
    {
        return Context.Set<CleaningEntrepreneur>().Where(c => c.Email == email)
            .FirstOrDefaultAsync();
    }
}