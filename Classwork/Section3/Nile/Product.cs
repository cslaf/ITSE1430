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
        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value; }
        }
        /// <summary>Description of the product. </summary>
        public string Description { get; set; }
        /// <summary>Price of Product in Dollars. </summary>
        public decimal Price { get; set; }
        /// <summary> If the product has been disconintued. </summary>
        public bool IsDiscontinued { get; set; }
        /// <summary> Gives a discounted price if Product IsDiscontinued </summary>
        public decimal ActualPrice
        {
            get { return IsDiscontinued ? (Price * DiscountPercentage) : Price; }
            set { }
        }

        /// <summary>Checks input to see if valid</summary>
        /// <returns>Error message or ""</returns>
        public string Validate()
        {
            if (String.IsNullOrEmpty(Name))
                return "Title cannot be empty";
            if (Price < 0)
                return "Price must be >= 0";
            return "";
        }

        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
        {
            var errors = new List<ValidationResult>();

            if (String.IsNullOrEmpty(Name))
                errors.Add(new ValidationResult("Title cannot be empty",
                    new[] {"Name" }));
            if (Price < 0)
               errors.Add(new ValidationResult("Price must be >= 0",
                   new[] { "Price" }));

            return errors;

        }
    }
}
