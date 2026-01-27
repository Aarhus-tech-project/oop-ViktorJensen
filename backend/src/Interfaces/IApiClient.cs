public interface IApiClient<TEntity, TId>
{
    Task<TEntity> GetByIdAsync(TId id);
    Task<TEntity> CreateAsync(TId entity);
    Task UpdateAsync(TId id, TEntity entity);
    Task UpdateAsync(TId id);
}