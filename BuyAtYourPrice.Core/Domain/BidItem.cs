namespace BuyAtYourPrice.Core.Domain
{
    public class BidItem : DomainEntity
    {
        public virtual decimal Price { get; set; }

        public virtual int Quantity { get; set; }

        public virtual Bid Bid { get; set; }

        public virtual Product Product { get; set; }

        /// <summary>
        /// Example of adding domain business logic to entity
        /// </summary>
        public virtual Money GetTotal()
        {
            return new Money(Price*Quantity);
        }
    }
}