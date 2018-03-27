using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Nile.Data.IO
{
    public class FileProductDatabase : ProductDatabase
    {
        public FileProductDatabase(string filename )
        {
            _filename = filename;
        }

        protected override Product AddCore( Product product )
        {
            EnsureInitialized();

            product.Id = _id++;
            _items.Add(product);

            SaveData();

            return product;
        }

        protected override IEnumerable<Product> GetAllCore()
        {
            EnsureInitialized();

            return _items;
            
        }

        private void EnsureInitialized ()
        {
            if (_items == null)
            {
                _items = LoadData();

                _id = 0;
                foreach(var item in _items)
                {
                    if (item.Id > _id)
                        _id = item.Id;
                }
                ++_id;
            }
        }

        private List<Product> LoadData()
        {
            var items = new List<Product>();
            if (!File.Exists(_filename))
                return items;

            var lines = File.ReadAllLines(_filename);

            foreach( var line in lines)
            {
                var fields = line.Split(',');

                var product = new Product() {
                    Id = ParseInt32(fields[0]),
                    Name = fields[1],
                    Description = fields[2],
                    Price = ParseDecimal(fields[3]),
                    IsDiscontinued = ParseInt32(fields[4]) != 0
                };
                items.Add(product);
            }
            return items;
        }

        private void SaveData()
        {
            var stream = File.OpenWrite(_filename);
            var writer = new StreamWriter(stream);

            foreach (var item in _items)
            {
                var line = $"{item.Id},{item.Name},{item.Description},{item.Price},{(item.IsDiscontinued ? 0 : 1)}";
                writer.WriteLine(line);
            }

            writer.Close();
            stream.Close();

        }


        private int ParseInt32 (string value)
        {
            if (Int32.TryParse(value, out var result))
                return result;

            return -1;
        }

        private decimal ParseDecimal (string value)
        {
            if (Decimal.TryParse(value, out var result))
                return result;

            return -1;
        }
        protected override Product GetCore( int id )
        {
            EnsureInitialized();

            foreach (var item in _items)
            {
                if (item.Id == id)
                    return item;
            };
            return null;
        }

        protected override Product GetCore( string name )
        {
            EnsureInitialized();

            foreach (var item in _items)
            {
                if (item.Name == name)
                    return item;
            };
            return null;
        }

        protected override void RemoveCore( int id )
        {
            EnsureInitialized();

            var product = GetCore(id);
            if (product != null)
            {
                _items.Remove(product);
                SaveData();
            }
        }

        protected override Product UpdateCore( Product product )
        {
            EnsureInitialized();

            RemoveCore(product.Id);
            _items.Add(product);
            SaveData();

            return product;

        }
        private int _id;
        private readonly string _filename;
        private List<Product> _items;
    }
}
