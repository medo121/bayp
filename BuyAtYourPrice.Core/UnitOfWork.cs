using System;
using BuyAtYourPrice.Core.Domain;
using BuyAtYourPrice.Data.Contracts;
using System.Data.Entity;

namespace BuyAtYourPrice.Core
{
    /// <summary>
    /// The Code Camper "Unit of Work"
    ///     1) decouples the repos from the controllers
    ///     2) decouples the DbContext and EF from the controllers
    ///     3) manages the UoW
    /// </summary>
    /// <remarks>
    /// This class implements the "Unit of Work" pattern in which
    /// the "UoW" serves as a facade for querying and saving to the database.
    /// Querying is delegated to "repositories".
    /// Each repository serves as a container dedicated to a particular
    /// root entity type such as a <see cref="Person"/>.
    /// A repository typically exposes "Get" methods for querying and
    /// will offer add, update, and delete methods if those features are supported.
    /// The repositories rely on their parent UoW to provide the interface to the
    /// data layer (which is the EF DbContext in Code Camper).
    /// </remarks>
    public class BaypUOW : IBuyAtYourPriceUnitOfWork, IDisposable
    {
        public BaypUOW(IRepositoryProvider repositoryProvider)
        {
            CreateDbContext();

            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;
        }


        public IRepository<ProductCategory> Categories
        {
            get { return GetStandardRepo<ProductCategory>(); }
            set { }
        }

        public IRepository<Product> Products
        {
            get { return GetStandardRepo<Product>(); }
            set { }
        }

        public IRepository<Bid> Bids
        {
            get { return GetStandardRepo<Bid>(); }
            set { }
        }

        public IRepository<BidMatch> BidMatches
        {
            get { return GetStandardRepo<BidMatch>(); }
            set { }
        }

        public IRepository<BidTransaction> BidTransactions
        {
            get { return GetStandardRepo<BidTransaction>(); }
            set { }
        }

        public IRepository<BidStatus> BidStatuses
        {
            get { return GetStandardRepo<BidStatus>(); }
            set { }
        }

        public IRepository<Offer> Offers
        {
            get { return GetStandardRepo<Offer>(); }
            set { }
        }

        public IRepository<OfferStatus> OfferStatuses
        {
            get { return GetStandardRepo<OfferStatus>(); }
            set { }
        }

        public IRepository<Customer> Customers
        {
            get { return GetStandardRepo<Customer>(); }
            set { }
        }

        /// <summary>
        /// Save pending changes to the database
        /// </summary>
        public void Commit()
        {
            //System.Diagnostics.Debug.WriteLine("Committed");
            DbContext.SaveChanges();
        }

        protected void CreateDbContext()
        {
            DbContext = new BuyAtYourPriceDbContext();
            //new 

            // Do NOT enable proxied entities, else serialization fails
            DbContext.Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicitly (avoid serialization trouble)
            DbContext.Configuration.LazyLoadingEnabled = false;

            // Because Web API will perform validation, we don't need/want EF to do so
            DbContext.Configuration.ValidateOnSaveEnabled = false;

            //DbContext.Configuration.AutoDetectChangesEnabled = false;
            // We won't use this performance tweak because we don't need 
            // the extra performance and, when autodetect is false,
            // we'd have to be careful. We're not being that careful.
        }

        protected IRepositoryProvider RepositoryProvider { get; set; }

        private IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        private DbContext DbContext { get; set; }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }

        #endregion
    }
}