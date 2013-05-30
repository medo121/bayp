using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace BuyAtYourPrice.Domain
{
    //     [HasUniqueDomainSignature(ErrorMessage = "A product category already exists with the same name")]
    public class Category : DomainEntity
    {
        public Category()
        {
            Categories = new List<Category>();
            Offerings = new List<ProductService>();
        }

        
        [Required(ErrorMessage = "Name must be provided")]
        [StringLength(255, ErrorMessage = "Name must be 255 characters or fewer")]
        public virtual string Name { get; set; }

        [Display(Name = "Parent Category")]
        public virtual Category Parent { get; set; }

        public virtual IList<ProductService> Offerings { get; set; }

        public virtual IList<Category> Categories { get; set; }

        public virtual string ImageUrl { get; set; }
    }
}