using System.Collections.Generic;
using System.Linq;

namespace BigStarter.Domain.Entities
{
    public class Project: BaseEntity
    {
        public string Name { get; set; }

        public string LogoUrl { get; set; }

        public string Description { get; set; }

        public decimal Goal { get; set; }

        public int OwnerId { get; set; }

        public User Owner { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

        public decimal Pledged
        {
            get
            {
                return Transactions?.Sum(x => x.Amount) ?? 0;
            }
        }

        public decimal RemainingAmount
        {
            get
            {
                return Goal - Pledged;
            }
        }

        public bool IsCompleted
        {
            get
            {
                return Goal - Pledged <= 0;
            }
        }

        
    }
}
