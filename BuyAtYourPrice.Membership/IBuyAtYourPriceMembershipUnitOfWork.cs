

namespace BuyAtYourPrice.Membership
{
    public interface IBuyAtYourPriceMembershipUnitOfWork
    {
// Save pending changes to the data store.
        void Commit();
    }
}