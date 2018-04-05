using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Data.Memory 
{
    /// <summary> Storage for Producst in memory</summary>
    public class MemoryProductDatabase : ProductDatabase
    {
        //test
        private List<Product> _products = new List<Product>();
        private int _nextId = 1;

        protected override IEnumerable<Product> GetAllCore()
        {
            return from p in _products
                   select Clone(p);

            //return _products.Select(p => Clone(p));
        }

        protected override Product AddCore( Product product )
        {
            product.Id = _nextId++;
            _products.Add(Clone(product));
            return product;
        }

        Product Clone (Product item )
        {
            var newProduct = new Product();
             Copy(newProduct, item);
            return newProduct;
        }

        protected override Product UpdateCore( Product product)
        {
            var existing = GetCore(product.Id);
            Copy(existing, product); 
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

        protected override void RemoveCore(int id )
        {
           var toDel = GetCore(id);
           if(toDel != null)
           _products.Remove(toDel);
        }

        protected override Product GetCore (int id )
        {
            //return (from p in _products
            //       where p.Id == id
            //       select p).FirstOrDefault();

            return _products.FirstOrDefault(e => e.Id == id);
        }

        protected override Product GetCore(string name )
        {
            var items = from p in _products
                        where p.Name == name
                        select p;
            return items.FirstOrDefault(e => e.Name == name);
        }
    }
}
