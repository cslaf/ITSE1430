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
            var error = Enumerable.FirstOrDefault(errors);
            if(error != null)
            {
                message = error.ErrorMessage;
                return null;
            }

            // verify unique product
            var existing = GetCore(product.Name);
            if(existing != null)
            {
                message = "Product Already Exists";
                return null;
            }

            message = null;
            return AddCore(product);
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

            var existing = GetCore(product.Name);
            if(existing != null && existing.Id != product.Id)
            {
                message = "Product Already Exists";
                return null;
            }

            existing = existing ?? GetCore(product.Id);
            if(existing == null)
            {
                message = "Product not found";
               return null;
            }

            message = null;

            return UpdateCore(product);

        }

        public void Remove(int id )
        {
            if (id > 0)
            {
                RemoveCore(id);  
            }
        }

        protected abstract Product AddCore( Product product );
        protected abstract IEnumerable<Product> GetAllCore();
        protected abstract Product GetCore(int id);
        protected abstract Product GetCore( string name );
        protected abstract Product UpdateCore( Product product );
        protected abstract void RemoveCore( int id );

    }
}
