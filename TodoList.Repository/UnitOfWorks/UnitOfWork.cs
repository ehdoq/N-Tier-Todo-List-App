using Microsoft.EntityFrameworkCore;
using TodoList.Core.Repositories;
using TodoList.Core.UnitOfWorks;
using TodoList.Repository.AppDBContexts;
using TodoList.Repository.Repositories;

namespace TodoList.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbcontext;

        private TodoRepository? _toDoRepository;
        private UserRepository? _userRepository;
        private BlogPostRepository? _blogPostRepository;

        public UnitOfWork(AppDbContext appDbcontext)
        {
            _appDbcontext = appDbcontext;
        }

        public ITodoRepository Todo => _toDoRepository = _toDoRepository ?? new TodoRepository(_appDbcontext);
        public IUserRepository User => _userRepository = _userRepository ?? new UserRepository(_appDbcontext);
        public IBlogPostRepository BlogPost => _blogPostRepository = _blogPostRepository ?? new BlogPostRepository(_appDbcontext);
        
        public async Task CommitAsync()
        {
            await _appDbcontext.SaveChangesAsync();
        }

        public void Commit()
        {
            _appDbcontext.SaveChanges();
        }
    }
}