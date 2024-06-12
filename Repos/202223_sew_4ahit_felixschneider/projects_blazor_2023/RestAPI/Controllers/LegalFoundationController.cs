using Domain.Repositories.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.Projects;
using RestAPI.Dtos;

namespace RestAPI.Controllers;

[ApiController]
[Route("legalfoundations")]
public class LegalFoundationController : ControllerBase
{
    private readonly IRepository<LegalFoundation> _repository;

    public LegalFoundationController(IRepository<LegalFoundation> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<List<ReadLegalFoundationDto>>> ReadAllAsync()
        => Ok((await _repository.ReadAllAsync()).Select(i => i.Adapt<ReadLegalFoundationDto>()).ToList());
}