using Microsoft.EntityFrameworkCore;
using WebService.Data.Entites;

namespace WebService.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>().Property(m => m.Text).HasMaxLength(128);
        }
    }
}
