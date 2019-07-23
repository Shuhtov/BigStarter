using BigStarter.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BigStarter.Data.ModelBuilders
{
    public class ProjectBuilder: BaseBuilder<Project>
    {
        public ProjectBuilder(ModelBuilder builder): base(builder)
        {
            builder.Entity<Project>()
                .Property(x => x.Name)
                .HasMaxLength(512)
                .IsRequired();

            builder.Entity<Project>()
                .Property(x => x.LogoUrl)
                .HasMaxLength(512);

            builder.Entity<Project>()
                .Property(x => x.Description)
                .HasMaxLength(2048);

            builder.Entity<Project>()
                .Property(x => x.Goal)
                .IsRequired();

            builder.Entity<Project>()
                .HasOne(x => x.Owner)
                .WithMany(x => x.Projects)
                .HasForeignKey(x => x.OwnerId)
                .IsRequired();

            builder.Entity<Project>()
                .HasMany(x => x.Transactions)
                .WithOne(x => x.Project)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
