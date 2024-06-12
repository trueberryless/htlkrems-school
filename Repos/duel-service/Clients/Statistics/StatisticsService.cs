using System.Net.Http.Json;
using System.Text.Json;
using DTOs.StatisticsService;
using Microsoft.Extensions.Options;

namespace Clients.Statistics;

public class StatisticsService: AClientService, IStatisticsService
{
    public StatisticsService(HttpClient httpClient, IOptions<StatisticsServiceOptions> options) : base(httpClient,options){ }

    public async Task<List<ReadStatisticsDto>?> GetStatistics()
    {
        var httpResponseMessage = await _httpClient.GetAsync("/api/statistics");
        var body = await httpResponseMessage.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<ReadStatisticsDto>>(body);
    }
    
    public async Task<ReadStatisticDto?> GetStatistic(int id)
    {
        var httpResponseMessage = await _httpClient.GetAsync($"/api/statistics/{id}");
        var body = await httpResponseMessage.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<ReadStatisticDto>(body);
    }
    
    public async Task UpdateStatistics(PutStatisticsDto putStatisticsDto)
    {
        var content = JsonContent.Create(putStatisticsDto); 
        var httpResponseMessage = await _httpClient.PutAsync($"/api/statistics/{putStatisticsDto.Id}", content);
        if (!httpResponseMessage.IsSuccessStatusCode)
            throw new StatisticsUpdateServiceException();
    }
}

public class StatisticsUpdateServiceException : Exception { }