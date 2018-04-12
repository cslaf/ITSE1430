using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class WordData : IComparable
    {
        public readonly string word;
        public HashSet<int> lines { get; set; }
        
        public WordData(string w )
        {
            word = w;
            lines = new HashSet<int>();
        }

        public int CompareTo( object obj )
        {
            var test = obj as WordData;
            if(test != null)
            {
                return String.Compare(test.word, word);
            }

            throw new ArgumentNullException();
            
        }


        public int CompareTo( T other )
        {
            throw new NotImplementedException();
        }
    }
}
