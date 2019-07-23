using BigStarter.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BigStarter.Data.ModelBuilders
{
    public class UserBuilder
    {
        public UserBuilder(ModelBuilder builder)
        {
            builder.Entity<User>()
                .Property(x => x.LogoUrl)
                .HasMaxLength(512);

            builder.Entity<User>()
                .HasMany(x => x.Projects)
                .WithOne(x => x.Owner)
                .HasForeignKey(x => x.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<User>()
                .HasMany(x => x.Transactions)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
                
        }
    }
}
