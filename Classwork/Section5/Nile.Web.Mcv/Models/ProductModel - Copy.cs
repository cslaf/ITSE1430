using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Web.Mcv.Models
{
    public static class ProductExtension
    {
        public static ProductModel ToModel( this Product source )
            => new ProductModel() {
                   Id = source.Id,
                   Name = source.Name,
                   Description = source.Description,
                   IsDiscontinued = source.IsDiscontinued,
                   Price = source.Price
            };
        public static Product ToProduct( this ProductModel source )
            => new Product() {
                   Id = source.Id,
                   Name = source.Name,
                   Description = source.Description,
                   IsDiscontinued = source.IsDiscontinued,
                   Price = source.Price
            };
    }
}
