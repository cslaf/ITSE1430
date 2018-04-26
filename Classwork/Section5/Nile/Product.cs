using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile
{
    /// <summary>Provides info about a product.</summary>
    public class Product : IValidatableObject
    {
        internal decimal DiscountPercentage = 0.10M;
        private string _name;
        /// <summary>Gets or sets product ID. </summary>
        public int Id { get; set; }

        /// <summary>Name of the product. </summary>
        [Required(AllowEmptyStrings = false)]
        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value; }
        }
        /// <summary>Description of the product. </summary>
        public string Description { get; set; }
        /// <summary>Price of Product in Dollars. </summary>
        [Range(0, Double.MaxValue, ErrorMessage = "Price must be >= 0")]
        public decimal Price { get; set; } = 0;
        /// <summary> If the product has been disconintued. </summary>
        public bool IsDiscontinued { get; set; }
        /// <summary> Gives a discounted price if Product IsDiscontinued </summary>
        public decimal ActualPrice
        {
            get { return IsDiscontinued ? (Price * DiscountPercentage) : Price; }
            set { }
        }

        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
        {
            var errors = new List<ValidationResult>();
            
            return errors;

        }
    }
}
