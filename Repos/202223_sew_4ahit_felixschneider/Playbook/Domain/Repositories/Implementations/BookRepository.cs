using Model.Configuration;
using Model.Entities;

namespace Domain.Repositories.Implementations;

public class BookRepository : ARepository<Book>
{
    public BookRepository(PlaybookDbContext context) : base(context)
    {
    }
}