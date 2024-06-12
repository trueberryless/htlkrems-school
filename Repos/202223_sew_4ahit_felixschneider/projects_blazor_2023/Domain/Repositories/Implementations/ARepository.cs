using System.Linq.Expressions;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;

namespace Domain.Repositories.Implementations; 

public class ARepository<TEntity> : IRepository<TEntity> where TEntity : class {
    protected readonly ProjectDbContext Context;
    protected readonly DbSet<TEntity> Table;

    public ARepository(ProjectDbContext context) {
        Context = context;
        Table = context.Set<TEntity>();
    }

    public async Task<TEntity> CreateAsync(TEntity t) {
        await Table.AddAsync(t);
        await Context.SaveChangesAsync();
        return t;
    }

    public async Task<List<TEntity>> CreateRangeAsync(List<TEntity> list) {
        await Table.AddRangeAsync(list);
        await Context.SaveChangesAsync();
        return list;
    }

    public async Task<TEntity?> ReadAsync(int id) => await Table.FindAsync(id);

    public async Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> filter) =>
        await Table.Where(filter).ToListAsync();

    public async Task<List<TEntity>> ReadAsync(int start, int count) =>
        await Table.Skip(start)
            .Take(count)
            .ToListAsync();

    public async Task<List<TEntity>> ReadAllAsync() => await Table.ToListAsync();

    public async Task UpdateAsync(TEntity t) {
        Context.ChangeTracker.Clear();          // beim Test nicht
        Table.Update(t);
        await Context.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(List<TEntity> list) {
        Context.ChangeTracker.Clear();      //beim Test nicht
        Table.UpdateRange(list);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity t) {
        Table.Remove(t);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteRangeAsync(List<TEntity> list) {
        Table.RemoveRange(list);
        await Context.SaveChangesAsync();
    }
}