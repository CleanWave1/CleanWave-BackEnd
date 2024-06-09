namespace cleanwave_platform.Shared.Domain.Repositories;

public interface IBaseRepository<TEntity>
{
    //CRUD
    //Insert
    Task AddSync(TEntity entity);
    
    //Create - Read
    Task<TEntity?> FindByIdAsync(int id);
    Task<IEnumerable<TEntity>> ListAsync();
    
    //Update - Delete
    void Update(TEntity entity);
    void Remove(TEntity entity);
}