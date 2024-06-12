using DTOs.StatisticsService;
using Mapster;

namespace Clients.Statistics;

public class StatisticsServiceMock : IStatisticsService
{
    public Task<List<ReadStatisticsDto>?> GetStatistics()
    {
        // Create example data
        var statistics = StatisticsMock.GetStatisticsMock().Select(e => e.Adapt<ReadStatisticsDto>()).ToList();

        // Wrap it in a completed Task (since Task.FromResult is not available here)
        return Task.FromResult<List<ReadStatisticsDto>?>(statistics);
    }

    public Task<ReadStatisticDto?> GetStatistic(int id)
    {
        // Create example data
        var statistics = StatisticsMock.GetStatisticsMock().First(e => e.Id == id).Adapt<ReadStatisticDto>();

        // Wrap it in a completed Task (since Task.FromResult is not available here)
        return Task.FromResult<ReadStatisticDto?>(statistics);
    }

    public Task UpdateStatistics(PutStatisticsDto putStatisticsDto)
    {
        return Task.CompletedTask;
    }
}