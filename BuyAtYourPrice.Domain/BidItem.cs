namespace BuyAtYourPrice.Domain
{
    public class BidItem : DomainEntity
    {
    
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int BidId { get; set; }
   
        public BidItemCondition Condition { get; set; }
        
        public Product Product { get; set; }

        /// <summary>
        /// Example of adding domain business logic to entity
        /// </summary>
        public Money GetTotal()
        {
            return new Money(Price*Quantity);
        }
    }
}