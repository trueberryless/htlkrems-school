using System.Linq.Expressions;

namespace Domain.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity?> ReadAsync(int id);

    Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> filter);

    Task<List<TEntity>> ReadAsync(int start, int count);

    Task<TEntity> CreateAsync(TEntity t);

    Task<List<TEntity>> CreateRangeAsync(List<TEntity> list);

    Task UpdateAsync(TEntity t);

    Task UpdateRangeAsync(List<TEntity> list);

    Task DeleteAsync(TEntity t);

    Task DeleteRangeAsync(List<TEntity> list);
}