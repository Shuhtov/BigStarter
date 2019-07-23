namespace BigStarter.Domain.Entities
{
    public class Transaction: BaseEntity
    {
        public User User { get; set; }

        public Project Project { get; set; }

        public int UserId { get; set; }

        public int ProjectId { get; set; }

        public decimal Amount { get; set; }
    }
}
