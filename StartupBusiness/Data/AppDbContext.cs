using Microsoft.EntityFrameworkCore;
using StartupBusiness.Models;

namespace StartupBusiness.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users {get; set;}
        public DbSet<Team> Teams {get;set;}
        public DbSet<Project> Project {get;set;}

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(t => t.Teams)
                .WithMany(u => u.Users)
                .HasForeignKey(u => u.TeamsId);

            modelBuilder.Entity<Project>()
                .HasOne(t => t.Teams)
                .WithMany(p => p.Project)
                .HasForeignKey(p => p.TeamsId);
        }
    }
}
