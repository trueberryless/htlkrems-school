using System.Diagnostics.CodeAnalysis;
using Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers; 

public class AController<TEntity> : ControllerBase where TEntity : class{
    
    private readonly IRepository<TEntity> _repository;

    public AController(IRepository<TEntity> repository) {
        _repository = repository;
    }
    
    [HttpPost]
    public async Task<ActionResult<TEntity>> CreateAsync([NotNull] TEntity entity) =>
        Ok(await _repository.CreateAsync(entity));
    
    
    [HttpGet]
    public async Task<ActionResult<TEntity>> ReadAllAsync() =>
        Ok(await _repository.ReadAllAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TEntity?>> ReadAsync(int id) {
        var entity = await _repository.ReadAsync(id);
        if (entity is null) return NotFound();
        
        return Ok(entity);
    }

    
    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateAsync([NotNull] TEntity entity, int id) {
        var data = await _repository.ReadAsync(id);
        if (data is null) return NotFound();
        
        await _repository.UpdateAsync(entity);
        return NoContent();
    }
    
    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAsync(int id) {
        var data = await _repository.ReadAsync(id);
        if (data is null) return NotFound();

        await _repository.DeleteAsync(data);
        return NoContent();
    }
}