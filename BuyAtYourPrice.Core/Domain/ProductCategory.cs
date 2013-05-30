namespace BuyAtYourPrice.Core.Domain
{
    public class ProductCategory : DomainEntity
    {
        public virtual ProductCategory Parent { get; set; }

        public virtual string Name { get; set; }
    }
}