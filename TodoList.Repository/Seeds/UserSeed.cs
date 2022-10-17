using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Core.Entities.Concrete;

namespace TodoList.Repository.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User { Id = 1, FirstName = "Ali", LastName = "Veli", CreatedDate = DateTime.Now, UpdatedDate = null },
                new User { Id = 2, FirstName = "Ayşe", LastName = "Fatma", CreatedDate = DateTime.Now, UpdatedDate = null },
                new User { Id = 3, FirstName = "Ali", LastName = "Cengiz", CreatedDate = DateTime.Now, UpdatedDate = null },
                new User { Id = 4, FirstName = "John", LastName = "Doe", CreatedDate = DateTime.Now, UpdatedDate = null }
            );
        }
    }
}