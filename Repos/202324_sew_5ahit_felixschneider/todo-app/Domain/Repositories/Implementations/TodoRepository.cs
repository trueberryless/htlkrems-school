using Model.Entities.Todos;

namespace Domain.Repositories.Implementations;

public class TodoRepository : ARepository<Todo>, ITodoRepository
{
    public TodoRepository(ModelDbContext context) : base(context)
    {
    }
}