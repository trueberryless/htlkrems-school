using System.Linq.Expressions;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Configuration;

namespace Domain.Repositories.Implementations;

public abstract class ARepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected PlaybookDbContext Context;
    protected DbSet<TEntity> Table;

    public ARepository(PlaybookDbContext context)
    {
        Context = context;
        Table = context.Set<TEntity>();
    }

    public async Task<TEntity?> ReadAsync(int id) => await Table.FindAsync(id);

    public async Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> filter) => await Table.Where(filter).ToListAsync();

    public async Task<List<TEntity>> ReadAsync(int start, int count) =>
        await Table.Skip(start).Take(count).ToListAsync();

    public async Task<TEntity> CreateAsync(TEntity t)
    {
        Table.Add(t);
        await Context.SaveChangesAsync();
        return t;
    }

    public async Task<List<TEntity>> CreateRangeAsync(List<TEntity> list)
    {
        Table.AddRange(list);
        await Context.SaveChangesAsync();
        return list;
    }

    public async Task UpdateAsync(TEntity t)
    {
        Table.Update(t);
        await Context.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(List<TEntity> list)
    {
        Table.UpdateRange(list);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity t)
    {
        Table.Remove(t);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteRangeAsync(List<TEntity> list)
    {
        Table.RemoveRange(list);
        await Context.SaveChangesAsync();
    }
}