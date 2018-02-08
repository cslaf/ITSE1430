using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile
{
    /// <summary>Provides info about a product.</summary>
    public class Product
    {
        internal decimal DiscountPercentage = 0.10M;

        /// <summary>Name of the product. </summary>
        public string Name { get; set; }
        /// <summary>Description of the product. </summary>
        public string Description { get; set; }
        /// <summary>Price of Product in Dollars. </summary>
        public decimal Price { get; set; }
        /// <summary> If the product has been disconintued. </summary>
        public bool IsDiscontinued { get; set; }

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

    }
}
