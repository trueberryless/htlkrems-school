using Domain.Repositories.Interfaces;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Implementations;

public class TraitRepository : ARepository<Trait>, IRepository<Trait>
{
    public TraitRepository(AosDbContext context) : base(context)
    {
    }
}