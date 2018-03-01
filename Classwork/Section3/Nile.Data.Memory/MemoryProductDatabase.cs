using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Data.Memory
{
    /// <summary> Storage for Producst in memory</summary>
    public class MemoryProductDatabase
    {
        //test
        private List<Product> _products = new List<Product>();



        public List<Product> GetAll() { return _products; }

        public Product Add( Product product, out string message )
        {
            if(product == null)
            {
                message = "Product cannot be null";
                return null;
            }

            var error = product.Validate();
            if (!String.IsNullOrEmpty(error))
            {
                message = error;
                return null;
            }

            //TODO: verify unique product
            message = null;
            _products.Add(product);
            return product;
            
        }

        public Product Edit( Product product, out string message )
        {
            product = SearchFor(product.Id);
            if (product == null)
            {
                message = "Product cannot be null";
                return null;
            }

            var error = product.Validate();
            if (!String.IsNullOrEmpty(error))
            {
                message = error;
                return null;
            }

            //TODO: verify unique product except current

            //var exisitingIndex = GetById(product.Id);
            //if(exisitingIndex < 0)
            //{
            //    message = "Product not found";
            //    return null;
            //}

            message = null;
                
            return product;

        }

        public void Remove(int id )
        {

        }

        private Product SearchFor (int id )
        {
            Product result = _products.Find(delegate ( Product prod ) { return prod.Id == id; });
            
            if( result != null)
            {
                return result;
            } else
            {
                return null;
            }

        }
    }
}
