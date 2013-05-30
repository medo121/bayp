using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BuyAtYourPrice.Domain;
using BuyAtYourPrice.Repository.Interfaces;

namespace BuyAtYourPrice.Web.Controllers
{
    public class ProductCategoryController : ApiController
    {

        private readonly IRepository<ProductCategory> _categoryRepository;
        public ProductCategoryController(IRepository<ProductCategory> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET api/ProductCategory
        public IEnumerable<ProductCategory> Get()
        {
            return _categoryRepository.GetAll();
        }

        // GET api/ProductCategory/5
        public ProductCategory Get(int id)
        {
            var productCategory = _categoryRepository.GetById(id);
            if (productCategory != null) return productCategory;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }
    }

  
}