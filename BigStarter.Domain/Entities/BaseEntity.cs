using BigStarter.Domain.Contracts.Repositories;

namespace BigStarter.Domain.Entities
{
    public class BaseEntity: IBaseEntity
    {
        public int Id { get; set; }
    }
}
