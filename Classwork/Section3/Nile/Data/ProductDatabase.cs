using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Data 
{
    /// <summary> Storage for Producst in memory</summary>
    public abstract class ProductDatabase : IProductDatabase
    {
        //test
        private List<Product> _products = new List<Product>();
        private int _nextId = 1;

        public IEnumerable<Product> GetAll()
        {
            return GetAllCore();
        }

        public Product Add( Product product, out string message )
        {
            if(product == null)
            {
                message = "Product cannot be null";
                return null;
            }

            var errors = ObjectValidator.Validate(product);
            if(errors.Count() > 0)
            {
                message = errors.ElementAt(0).ErrorMessage;
            }

            // verify unique product
            var existing = GetProductByName(product.Name);
            if(existing != null)
            {
                message = "Product Already Exists";
                return null;
            }

            message = null;
            return AddCore(product);
        }

        Product Clone (Product item )
        {
            var newProduct = new Product();
             Copy(newProduct, item);
            return newProduct;
        }

        public Product Update( Product product, out string message )
        {
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

            var existing = GetProductByName(product.Name);
            if(existing != null && existing.Id != product.Id)
            {
                message = "Product Already Exists";
                return null;
            }

            existing = existing ?? GetById(product.Id);
            if(existing == null)
            {
                message = "Product not found";
               return null;
            }

            Copy(existing, product); 

            message = null;
                
            return product;

        }

        private void Copy(Product target, Product source)
        {
            target.Id = source.Id;
            target.Name = source.Name;
            target.Description = source.Description;
            target.Price = source.Price;
            target.IsDiscontinued = source.IsDiscontinued;

        }

        public void Remove(int id )
        {
            if (id > 0)
            {
                var toDel = GetById(id);
                if(toDel != null)
                    _products.Remove(toDel);
            }
        }

        private Product GetById (int id )
        {
            foreach (var product in _products)
            {
                if (product.Id == id)
                    return product;

            }
            return null;
        }

        private Product GetProductByName(string name )
        {
            foreach (var product in _products)
            {
                //product.Name.CompareTo
                if (String.Compare(product.Name, name, true) ==0 )
                    return product;

            }
            return null;

        }

        protected abstract Product AddCore( Product product );

        protected abstract IEnumerable<Product> GetAllCore();
        protected abstract Product GetCore(int id);

    }
}
