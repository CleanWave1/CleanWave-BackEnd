using cleanwave_platform.Shared.Domain.Repositories;
using cleanwave_platform.Shared.Infraestructure.Persistance.EFC.Configuration;

namespace cleanwave_platform.Shared.Infraestructure.Persistance.EFC.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public UnitOfWork(AppDbContext context) => _context = context;
    public async Task CompleteAsync() => await _context.SaveChangesAsync();
}