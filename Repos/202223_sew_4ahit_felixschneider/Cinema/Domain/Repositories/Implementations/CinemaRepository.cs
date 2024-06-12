using Microsoft.EntityFrameworkCore;
using Model.Configuration;
using Model.Entities;

namespace Domain.Repositories.Implementations;

public class CinemaRepository : ARepository<Cinema>
{
    public CinemaRepository(CinemaDbContext context) : base(context)
    {
        
    }
}