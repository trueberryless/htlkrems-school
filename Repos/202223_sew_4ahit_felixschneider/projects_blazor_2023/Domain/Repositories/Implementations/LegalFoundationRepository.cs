using Domain.Repositories.Interfaces;
using Model.Configurations;
using Model.Entities.Projects;

namespace Domain.Repositories.Implementations;

public class LegalFoundationRepository : ARepository<LegalFoundation>
{
    public LegalFoundationRepository(ProjectDbContext context) : base(context)
    {
    }
}