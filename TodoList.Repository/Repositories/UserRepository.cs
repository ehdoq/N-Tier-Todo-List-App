using Microsoft.EntityFrameworkCore;
using TodoList.Core.Entities.Concrete;
using TodoList.Core.Repositories;
using TodoList.Repository.AppDBContexts;

namespace TodoList.Repository.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
            
        public async Task<User> GetWithTodosByIdAsync(int id)
        {
            return await _appDbContext.Users.Include(x => x.Todos).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}