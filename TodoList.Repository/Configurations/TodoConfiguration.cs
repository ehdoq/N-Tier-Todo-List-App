using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Core.Entities.Concrete;

namespace TodoList.Repository.Configurations
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn(1, 1);

            builder.Property(x => x.Title).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Content).IsRequired();

            builder.ToTable("Todos");
        }
    }
}