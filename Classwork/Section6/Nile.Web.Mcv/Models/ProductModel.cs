using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Web.Mcv.Models
{
    /// <summary>Provides info about a product.</summary>
    public class ProductModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Range(0, Double.MaxValue, ErrorMessage = "Price must be >= 0")]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool IsDiscontinued { get; set; }

    }
}
