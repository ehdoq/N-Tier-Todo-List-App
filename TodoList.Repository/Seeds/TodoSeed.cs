using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TodoList.Core.Entities.Concrete;

namespace TodoList.Repository.Seeds
{
    public class TodoSeed : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.HasData(
                new Todo { Id = 1, Title = "Ekmek", Content = "iki ekmek al ve eve git.", Date = DateTime.Now, IsDone = false, CreatedDate = DateTime.Now, UpdatedDate = null, UserId = 1 },
                new Todo { Id = 2, Title = "Süt", Content = "süt al.", Date = DateTime.Now, IsDone = false, CreatedDate = DateTime.Now, UpdatedDate = null, UserId = 2 },
                new Todo { Id = 3, Title = "Yoğurt", Content = "yoğurt al.", Date = DateTime.Now, IsDone = false, CreatedDate = DateTime.Now, UpdatedDate = null, UserId = 3 },
                new Todo { Id = 4, Title = "Un", Content = "un al.", Date = DateTime.Now, IsDone = false, CreatedDate = DateTime.Now, UpdatedDate = null, UserId = 4 }
            );
       }
    }
}