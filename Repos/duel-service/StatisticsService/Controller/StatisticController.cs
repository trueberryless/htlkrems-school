using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DTOs.StatisticsService;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StatisticsService.Model;
using StatisticsService.Repositories;

namespace StatisticsService.Controller;

[ApiController]
[Route("api/statistics")]
public class StatisticController : ControllerBase
{
    protected IStatisticRepository _statisticRepository;

    public StatisticController(IStatisticRepository statisticRepository)
    {
        _statisticRepository = statisticRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<ReadStatisticsDto>>> GetStatistics()
    {
        var statistics = await _statisticRepository.ReadAsync();
        statistics.ForEach(s => s.Href = Url.ActionLink(nameof(GetStatistic), "Statistic", new { id = s.Id }, Request.Scheme));
        var statisticsDto = statistics.Select(s => s.Adapt<ReadStatisticsDto>()).ToList();
        return Ok(statisticsDto);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<ReadStatisticDto>> GetStatistic(int id)
    {
        var statistic = await _statisticRepository.ReadAsync(id);
        if (statistic == null) return NoContent();
        
        statistic.Href = Url.ActionLink(nameof(GetStatistic), "Statistic", new { id = statistic.Id }, Request.Scheme);
        var statisticDto = statistic?.Adapt<ReadStatisticDto>();
        Console.WriteLine(Url.ActionLink(nameof(GetStatistic), "Statistic", Request.Scheme));
        Url.ActionLink(nameof(GetStatistics), "User", Request.Scheme);
        return Ok(statisticDto);
    }   

    [HttpPost]
    public async Task<ActionResult> PostStatistic([FromBody] PostStatisticsDto statisticsDto)
    {
        var statistic = statisticsDto.Adapt<Player>();
        await _statisticRepository.CreateAsync(statistic);
        return Ok();
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult> PutStatistic(int id, [FromBody] PutStatisticsDto statisticsDto)
    {
        var statistic = statisticsDto.Adapt<Player>();
        await _statisticRepository.UpdateAsync(statistic);
        return Ok();
    }
    
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult> DeleteStatistic(int id)
    {
        var player = await _statisticRepository.ReadAsync(id);
        if (player == null) return NoContent();
        await _statisticRepository.DeleteAsync(player);
        return Ok();
    }
    
}