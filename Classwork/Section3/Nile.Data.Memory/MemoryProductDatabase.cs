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

        public MemoryProductDatabase()
        {
            _products = new List<Product>() {

            new Product() {
                Id = _nextId++,
                Name = "iPhone X",
                IsDiscontinued = true,
                Price = 1500
            },
            new Product() {
                Id = _nextId++,
                Name = "Windows Phone",
                IsDiscontinued = true,
                Price = 15
            },
                new Product() {
                Id = _nextId++,
                Name = "Samsung S8",
                IsDiscontinued = false,
                Price = 800
            }

            };
        }

        protected override IEnumerable<Product> GetAllCore()
        {
            foreach (var product in _products)
            {
                if(product != null)
                    yield return Clone(product);
            }
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
            foreach (var product in _products)
            {
                if (product.Id == id)
                    return product;
            }
            return null;
        }

        protected override Product GetCore(string name )
        {
            foreach (var product in _products)
            {
                //product.Name.CompareTo
                if (String.Compare(product.Name, name, true) ==0 )
                    return product;

            }
            return null;

        }
    }
}
