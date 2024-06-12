using Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.Debitors;

namespace RestAPI.Controllers; 

[ApiController]
[Route("debitors")]
public class DebitorController : AController<Debitor> {
    public DebitorController(IRepository<Debitor> repository) : base(repository) {
    }
}