namespace RentARoom.Web.ViewModels.Hotels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public abstract class BaseHotelsInputModel
    {
        [MinLength(4)]
        [MaxLength(20)]
        [RegularExpression("[A-Z][A-z]+", ErrorMessage = "Name should be start with upper letter!")]
        [Required]
        public string Name { get; set; }

        [MinLength(2)]
        [MaxLength(20)]
        [Required]
        public string Town { get; set; }

        [MinLength(2)]
        [MaxLength(30)]
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [Range(1, 100000)]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }
    }
}
