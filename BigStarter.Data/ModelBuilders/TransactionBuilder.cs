using BigStarter.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace BigStarter.Data.ModelBuilders
{
    public class TransactionBuilder : BaseBuilder<Transaction>
    {
        public TransactionBuilder(ModelBuilder builder): base(builder)
        {
            builder.Entity<Transaction>()
                .Property(x => x.Amount)
                .IsRequired();

            builder.Entity<Transaction>()
                .HasOne(x => x.User)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Transaction>()
                .HasOne(x => x.Project)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.ProjectId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
