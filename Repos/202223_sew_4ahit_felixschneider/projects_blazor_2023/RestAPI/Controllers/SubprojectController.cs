using Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.Projects;

namespace RestAPI.Controllers; 

[ApiController]
[Route("subprojects")]
public class SubprojectController : AController<Subproject> {
    public SubprojectController(IRepository<Subproject> repository) : base(repository) {
        
    }
}