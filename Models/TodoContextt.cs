using Microsoft.EntityFrameworkCore;

namespace SampleWebApi.Models
{
    public class TodoContextt : DbContext
    {
        public TodoContextt(DbContextOptions<TodoContextt> options)
            : base(options)
        {
        }

        public DbSet<TodoItemm> TodoItems { get; set; } = null!;
    }
}
