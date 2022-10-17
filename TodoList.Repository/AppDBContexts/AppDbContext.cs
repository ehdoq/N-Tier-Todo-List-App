using Microsoft.EntityFrameworkCore;
using TodoList.Core.Entities.Concrete;
using TodoList.Repository.Configurations;
using TodoList.Repository.Seeds;

namespace TodoList.Repository.AppDBContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Todo>? Todos { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<BlogPost>? BlogPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //Foreign keylerde

            //Configurations
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TodoConfiguration());

            //Seeds
            modelBuilder.ApplyConfiguration(new UserSeed());
            modelBuilder.ApplyConfiguration(new TodoSeed());
        }
    }
}