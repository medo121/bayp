using System;
using System.ComponentModel.DataAnnotations;

namespace BuyAtYourPrice.Domain
{
    public class DomainEntity
    {
        protected DomainEntity()
        {
            Version = 0;
            Created = DateTime.UtcNow;
            Updated = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }

        public  int Version { get; protected internal set; }

        public  DateTime Created { get; protected set; }

        public  DateTime Updated { get; set; }
    }
}