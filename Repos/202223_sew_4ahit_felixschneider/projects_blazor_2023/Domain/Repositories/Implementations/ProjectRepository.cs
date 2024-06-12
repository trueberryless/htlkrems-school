using Domain.Repositories.Interfaces;
using Model.Configurations;
using Model.Entities.Projects;

namespace Domain.Repositories.Implementations; 

public class ProjectRepository : ARepository<AProject>, IProjectRepository {
    public ProjectRepository(ProjectDbContext context) : base(context) {
    }
}