using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Host
{
    class Program
    {
        static void Main( string[] args )
        {
            int hours = 0;
            double rate =10.25;

            int hours2 = hours;

            string firstName, lastName;

            //string @class; This works but like, why?

            firstName = "Bob";
            lastName = "Miller";

            firstName = lastName = "Sue";

            //Math ops
            int x = 0, y = 10;
            int add = x + y;
            int substract = x - y;
            int multiply = x * y;
            int divide = x / y;
            int modulos = x % y;

            //+= still works

            double ceiling = Math.Ceiling(rate);
            double floor = ceiling;

            
        }
    }
}
