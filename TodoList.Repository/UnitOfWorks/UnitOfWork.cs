using TodoList.Core.UnitOfWorks;
using TodoList.Repository.AppDBContexts;

namespace TodoList.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbcontext;

        public UnitOfWork(AppDbContext appDbcontext)
        {
            _appDbcontext = appDbcontext;
        }
        
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