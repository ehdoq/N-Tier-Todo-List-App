using TodoList.Core.Repositories;

namespace TodoList.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}