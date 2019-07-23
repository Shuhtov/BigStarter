using BigStarter.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BigStarter.Data.ModelBuilders
{
    public class BaseBuilder<TModel> where TModel: BaseEntity
    {
        public BaseBuilder(ModelBuilder builder)
        {
            builder.Entity<TModel>()
                .HasKey(x => x.Id);
        }
    }
}
