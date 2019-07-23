using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BigStarter.Data.ModelBuilders;
using BigStarter.Domain.Entities;

namespace BigStarter.Data
{
    public class DatabaseContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        
        public DatabaseContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            new UserBuilder(builder);
            new ProjectBuilder(builder);
            new TransactionBuilder(builder);
        }
    }
}
