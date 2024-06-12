using StatisticsService.MyDbContext;
using StatisticsService.Model;

namespace StatisticsService.Repositories;

public class StatisticRepository : ARepository<Player>, IStatisticRepository
{
    public StatisticRepository(StatisticsServiceContext context) : base(context)
    {
    }
}