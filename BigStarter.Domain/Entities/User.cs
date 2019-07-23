using BigStarter.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BigStarter.Domain.Entities
{
    public class User : IdentityUser<int>, IBaseEntity
    {
        public string LogoUrl { get; set; }

        public ICollection<Project> Projects { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
