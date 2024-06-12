using System.Diagnostics.CodeAnalysis;
using Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.Projects;

namespace RestAPI.Controllers;

[ApiController]
[Route("projects")]
public class ProjectController : ControllerBase {
    /*
      Attribute -> zählt zur deklerativen Programmierung
                -> vergibt Eigenschaften zu Klassen, Methoden, Feldern ...
                -> Anstoßung von PreCompilern - Logik in ApiController enthalten, 
                   die Teile zu meiner Klasse hinzufügen.
    */

    private readonly IProjectRepository _projectRepository;

    public ProjectController(IProjectRepository projectRepository) {
        _projectRepository = projectRepository;
    }

    [HttpGet("ping")]
    public string Ping() {
        return "pong";
    }

    /*[HttpGet]
    public async Task<ActionResult<AProject>> ReadAllAsync() {
        var projects = await _projectRepository.ReadAllAsync();
        
        return Ok(projects);
    }*/

    [HttpGet]
    public async Task<ActionResult<AProject>> ReadAllAsync() =>
        Ok(await _projectRepository.ReadAllAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<AProject?>> ReadAsync(int id) {
        var project = await _projectRepository.ReadAsync(id);
        
        if (project is null) return NotFound();
        
        return Ok(project);
    }

    
    [HttpPost]
    public async Task<ActionResult<AProject>> CreateAsync([NotNull] AProject project) =>
        Ok(await _projectRepository.CreateAsync(project));

    
    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateAsync([NotNull] AProject project, int id) {
        
        var data = await _projectRepository.ReadAsync(id);
        if (project.Id != id || data is null) {
            return NotFound();
        }
        
        await _projectRepository.UpdateAsync(project);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAsync(int id) {
        var data = await _projectRepository.ReadAsync(id);
        if (data is null) return NotFound();

        await _projectRepository.DeleteAsync(data);
        return NoContent();
    }



}