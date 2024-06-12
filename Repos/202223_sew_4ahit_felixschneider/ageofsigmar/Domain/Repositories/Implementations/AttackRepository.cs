using Domain.Repositories.Interfaces;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Implementations;

public class AttackRepository : ARepository<Attack>, IRepository<Attack>
{
    public AttackRepository(AosDbContext context) : base(context)
    {
    }
}