using Domain.Repositories.Interfaces;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Implementations;

public class CreatureRepository : ARepository<Creature>, IRepository<Creature>
{
    public CreatureRepository(AosDbContext context) : base(context)
    {
    }
}