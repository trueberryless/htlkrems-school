using Mapster;
using Microsoft.AspNetCore.Mvc;
using DTOs.RegistrationService;
using RegistrationService.Services;
using RegistrationService.StateMachine;

namespace RegistrationService.Controllers;

[ApiController]
[Route("api")]
public class RegistrationController : ControllerBase
{
    protected IMongoService _mongoService;

    public RegistrationController(IMongoService mongo)
    {
        _mongoService = mongo;
    }
        
    [HttpGet("players")]
    public async Task<ActionResult<PlayersList>> GetPlayers()
    {
        var players = await _mongoService.GetPlayers();
        if (!players.Any())
            return NotFound();

        var playersdto = players.Select(p =>
        {
            p.Href = Url.ActionLink(nameof(GetPlayers),ControllerContext.ActionDescriptor.ControllerName, new {id = p.Id}, Request.Scheme)!;
            SetActions(p);
            return p.Adapt<Player>();
        }).ToList();

        return new PlayersList(Url.ActionLink(nameof(GetPlayers), ControllerContext.ActionDescriptor.ControllerName)!, playersdto);
    }

    [HttpPost("registration")]
    public async Task<ActionResult<Player>> CreatePlayers([FromBody] string name = "")
    {
        if (!name.Any())
            return NotFound();

        var result = await _mongoService.CreatePlayer(new Entities.Player() { Name = name });
        result.Href = Url.ActionLink(nameof(CreatePlayers),ControllerContext.ActionDescriptor.ControllerName, new {id = result.Id}, Request.Scheme)!;
        SetActions(result);
        return result.Adapt<Player>();
    }

    [HttpPut("registration/{id:int}")]
    public async Task<ActionResult<Player>> UpdatePlayer(int id, [FromBody] UpdatePlayerDTO? player)
    {
        if (player is null)
            return NotFound();

        var result = await _mongoService.UpdatePlayerElo(new Entities.Player(){Id = id, EloRating = player.EloRating});
        result.Href = Url.ActionLink(nameof(UpdatePlayer),ControllerContext.ActionDescriptor.ControllerName, new {id = result.Id}, Request.Scheme)!;
        SetActions(result);
        return result.Adapt<Player>();
    }
    
    [HttpDelete ("delete/{id:int}")]
    public async Task<ActionResult> DeletePlayer(int id) {
        var player = await _mongoService.GetPlayer(id);
        if(player is null) {
            return NotFound();
        }
        await _mongoService.DeletePlayer(player);
        return Ok();
    }
    
    [HttpPost("confirm/{id:int}")]
    public async Task<ActionResult<Player>> ConfirmPlayer(int id) {
        var player = await _mongoService.GetPlayer(id);
        if(!player.Name.Any()) {
            return NotFound();
        }
        
        player.State = EPlayerStates.REGISTERED;
        await _mongoService.UpdatePlayerState(player);
        SetActions(player);
        player.Href = Url.ActionLink(nameof(ConfirmPlayer),ControllerContext.ActionDescriptor.ControllerName, new {id = id}, Request.Scheme)!;
        return Ok(player.Adapt<Player>());
    }
    
    private void SetActions(Entities.Player player) {
        
        player.Actions = player.State
            switch {
                EPlayerStates.PENDING => new List<string> {Url.ActionLink(nameof(ConfirmPlayer), ControllerContext.ActionDescriptor.ControllerName, new { id = player.Id }, Request.Scheme)!, Url.ActionLink(nameof(DeletePlayer), ControllerContext.ActionDescriptor.ControllerName, new { id = player.Id }, Request.Scheme)!},
                EPlayerStates.REGISTERED => new List<string> {Url.ActionLink(nameof(DeletePlayer), ControllerContext.ActionDescriptor.ControllerName, new { id = player.Id }, Request.Scheme)!},
                _ => throw new ArgumentOutOfRangeException()
            };
    }
}