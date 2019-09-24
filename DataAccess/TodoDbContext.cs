using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class TodoDbContext : IdentityDbContext<User>
    {
        public TodoDbContext(DbContextOptions options)
            :base(options)
        {

        }


        public DbSet<TodoTask> Tasks { get; set; }
        public DbSet<SubTodoTask> SubTasks { get; set; }
        public DbSet<TodoTaskType> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Tasks)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);
            modelBuilder.Entity<TodoTask>()
                .HasMany(x => x.SubTasks)
                .WithOne(x => x.Task)
                .HasForeignKey(x => x.TaskId);
            modelBuilder.Entity<TodoTaskType>()
                .HasMany(x => x.Tasks)
                .WithOne(x => x.TaskType)
                .HasForeignKey(x => x.TaskTypeId);
            


            modelBuilder.Entity<TodoTaskType>()
                .HasData(
                new TodoTaskType { Title = "Work", Id = 1 },
                new TodoTaskType { Title = "Personal", Id = 2 },
                new TodoTaskType { Title = "Hobby", Id = 3 }
                );


           


        }


    }
}
