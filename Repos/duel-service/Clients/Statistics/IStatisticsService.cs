using DTOs.StatisticsService;

namespace Clients.Statistics;

public interface IStatisticsService
{
    Task<List<ReadStatisticsDto>?> GetStatistics();
    Task<ReadStatisticDto?> GetStatistic(int id);
    Task UpdateStatistics(PutStatisticsDto putStatisticsDto);

}