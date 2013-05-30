using System;
using System.ComponentModel.DataAnnotations;

namespace BuyAtYourPrice.Core.Domain
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

        public virtual int Version { get; protected internal set; }

        public virtual DateTime Created { get; protected set; }

        public virtual DateTime Updated { get; set; }
    }
}