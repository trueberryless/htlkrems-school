using Domain.Repositories.Interfaces;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Implementations;

public class TraitItemRepository : ARepository<TraitItem>, IRepository<TraitItem>
{
    public TraitItemRepository(AosDbContext context) : base(context)
    {
    }
}