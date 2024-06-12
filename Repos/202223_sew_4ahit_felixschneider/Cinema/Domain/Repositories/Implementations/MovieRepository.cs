using Model.Configuration;
using Model.Entities;

namespace Domain.Repositories.Implementations;

public class MovieRepository: ARepository<Movie>
{
    public MovieRepository(CinemaDbContext context) : base(context)
    {
        
    }
}