using Domain.Repositories.Interfaces;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Implementations;

public class SkillRepository : ARepository<Skill>, IRepository<Skill>
{
    public SkillRepository(AosDbContext context) : base(context)
    {
    }
}