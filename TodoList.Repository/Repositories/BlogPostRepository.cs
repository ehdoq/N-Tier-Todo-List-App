using TodoList.Core.Entities.Concrete;
using TodoList.Core.Repositories;
using TodoList.Repository.AppDBContexts;

namespace TodoList.Repository.Repositories
{
    public class BlogPostRepository : Repository<BlogPost>, IBlogPostRepository
    {
        private readonly AppDbContext _appDbContext;

        public BlogPostRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}