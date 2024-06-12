using StatisticsService.Model;

namespace Clients.Statistics;

public class StatisticsMock
{
    public static List<Player> GetStatisticsMock()
    {
        return new List<Player>
        {
            new Player(
                1,
                1500,
                10, // Number of duels won
                5, // Number of duels lost
                2, // Number of duels draw
                17, // Number of duels played
                5.6, // Average duel duration
                DateTime.Parse("2024-01-12T14:30:00")), // Last duel played at

            new Player(
                2,
                1600,
                8,
                3,
                1,
                12,
                4.2,
                DateTime.Parse("2024-01-11T20:45:00")),

            new Player(
                3,
                1450,
                12,
                6,
                3,
                21,
                6.8,
                DateTime.Parse("2024-01-13T10:15:00")),

            new Player(
                4,
                1750,
                9,
                4,
                0,
                13,
                3.9,
                DateTime.Parse("2024-01-10T18:20:00")),

            new Player(
                5,
                1400,
                7,
                8,
                2,
                17,
                4.5,
                DateTime.Parse("2024-01-14T08:00:00")),

            // Add more statistics for other players as needed
        };
    }
}