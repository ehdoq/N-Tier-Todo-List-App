using TodoList.Core.Repositories;

namespace TodoList.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        ITodoRepository Todo { get; }
        IUserRepository User { get; }
        IBlogPostRepository BlogPost { get; }
        Task CommitAsync();
        void Commit();
    }
}