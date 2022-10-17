using Microsoft.EntityFrameworkCore;
using TodoList.Core.Entities.Concrete;
using TodoList.Core.Repositories;
using TodoList.Repository.AppDBContexts;

namespace TodoList.Repository.Repositories
{
    public class TodoRepository : Repository<Todo>, ITodoRepository
    {
        private readonly AppDbContext _appDbContext;

        public TodoRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Todo> GetWithUserByIdAsync(int id)
        {
            return await _appDbContext.Todos.Include(x => x.User).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}