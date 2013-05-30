using BuyAtYourPrice.Core.Data;
using BuyAtYourPrice.Domain;
using BuyAtYourPrice.Repository.Interfaces;

namespace BuyAtYourPrice.Repository
{
    public class CustomerRepository : EfRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(BuyAtYourPriceCoreDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
