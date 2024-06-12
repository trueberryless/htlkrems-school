using Domain.Repositories.Interfaces;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Implementations;

public class SkillItemRepository :  ARepository<SkillItem>, IRepository<SkillItem>
{
    public SkillItemRepository(AosDbContext context) : base(context)
    {
    }
}