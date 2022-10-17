using TodoList.Core.Entities.Concrete;
using TodoList.Core.Repositories;
using TodoList.Core.Services;
using TodoList.Core.UnitOfWorks;

namespace TodoList.Service.Services
{
    public class BlogPostService : Service<BlogPost>, IBlogPostService
    {
        public BlogPostService(IRepository<BlogPost> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {

        }
    }
}