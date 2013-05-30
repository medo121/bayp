using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace BuyAtYourPrice.Domain
{
    public class ProductService : DomainEntity
    {
       
        [Required(ErrorMessage = "Name must be provided")]
        [StringLength(255, ErrorMessage = "Name must be 255 characters or fewer")]
        public virtual string Name { get; set; }

        public virtual IList<Category> Categories { get; set; }
    }
}