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

        public Product Add( Product product)
        {

            product = product ?? throw new ArgumentNullException(nameof(product));
            //if (product == null)
            //    throw new ArgumentNullException(nameof(product));
            product.Validate();

            // verify unique product
            var existing = GetCore(product.Name);
            if(existing != null)
                throw new Exception("Product already exsists");

            return AddCore(product);
        }

        public Product Update( Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            product.Validate();

            var existing = GetCore(product.Name);
            if (existing != null && existing.Id != product.Id)
                throw new Exception("Product already exsists");                

            existing = existing ?? GetCore(product.Id);
            if (existing == null)
                throw new Exception("Product does not exsist");

            return UpdateCore(product);

        }

        public void Remove(int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be >=0");
            RemoveCore(id);  
        }

        protected abstract Product AddCore( Product product );
        protected abstract IEnumerable<Product> GetAllCore();
        protected abstract Product GetCore(int id);
        protected abstract Product GetCore( string name );
        protected abstract Product UpdateCore( Product product );
        protected abstract void RemoveCore( int id );

    }
}
