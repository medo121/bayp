using System;
using System.Web.Http;
using BuyAtYourPrice.Core.Data;
namespace BuyAtYourPrice.Web.Controllers
{
    public class BaypApiBaseController : ApiController
    {
        public IBuyAtYourPriceCoreUnitOfWork Uow;

        public IBuyAtYourPriceCoreUnitOfWork UnitOfWork
        {
            get
            {
                if (Uow == null)
                {

                    Uow = new BuyAtYourPriceCoreUnitOfWork();
                    return Uow;
                }
                return Uow;
            }

            set { Uow = value; }
        }

        protected override void Dispose(bool disposing)
        {
            if (UnitOfWork != null && UnitOfWork is IDisposable)
            {
                ((IDisposable) UnitOfWork).Dispose();

                //
                UnitOfWork = null;
            }
            base.Dispose(disposing);
        }
    }
}