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
            bool quit = false;
            char choice;

            while (!quit)
            {
                //display menu
                choice = DisplayMenu();
                //process menu selection

                switch (choice)
                {
                    case 'L':
                        DisplayUser();
                        ListProducts();
                        break;
                    case 'A':
                        AddProduct();
                        break;
                    case 'Q':
                        quit = true;
                        return;
                    default:
                        Console.WriteLine("How did you do this though?");
                        break;
                }
            };
        }

        private static char DisplayMenu()
        {
            string[] menu = { "(L)ist Products", "(A)dd Product", "(Q)uit" };

            do
            {
                foreach (string item in menu)
                    Console.WriteLine(item);

                string input = Console.ReadLine();
                input = input.ToUpper();

                if (input == "L")
                    return input[0];
                else if (input == "A")
                    return input[0];
                else if (input == "Q")
                    return input[0];
                Console.WriteLine("Please choose a valid option");
            } while (true);

        }

        private static void DisplayUser()
        {
            string fullUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string user;
            string endCheck = "1234567890";
            int index = 0, end = -1;

            fullUser = fullUser.Replace('.', ' ');
            int front = fullUser.IndexOf('\\');
            int middleConvert = fullUser.IndexOf('.');
            foreach (char character in fullUser)
            {
                if (endCheck.Contains(character))
                {
                    end = index;
                    break;
                }
                index++;
            }

            user = fullUser.Substring(++front, end-front);

            Console.WriteLine(user);
        }

        static string _name, _description;
        static decimal _price;
        private static void ListProducts()
        {
            if (!String.IsNullOrEmpty(_name))
            {
                //var msg = String.Format("{0} [${1}]", _name, _price);
                string msg = $"{_name} [${_price}]";
                Console.WriteLine(msg);
                if(!String.IsNullOrEmpty(_description))
                    Console.WriteLine(_description);
            } else
            {
                Console.WriteLine("No Products");
            }
        }

        private static void AddProduct()
        {
            _name = ReadString("Enter a  name : ", true);

            _price = ReadDecimal("Enter price : ", 0);

            _description = ReadString("Enter optional description:", false);

        }

        private static decimal ReadDecimal(string message, int min )
        {
            do
            {
                Console.Write(message);
                string toCheck = Console.ReadLine();
                if (Decimal.TryParse(toCheck, out decimal value) && _price >= 0)
                    return value;
                else
                    Console.WriteLine("Value must be >= "+min.ToString());
            } while (true);
        }

        private static string ReadString(string message, bool isRequired)
        {
            do
            {
                Console.Write(message);

                string value = Console.ReadLine();

                if (value == "" && isRequired)
                    Console.WriteLine("You must enter a value");
                else
                    return value;
            } while (true);
        }

        static void PlayingWithPrimitives()
        {
            //primitve
            decimal unitPrice = 10.5M;

            //Using System.Decimal instead
            Decimal unitPrice2 = 10.5M;

            //Current time
            DateTime now = DateTime.Now;

            //full declaration of ArrayList
            System.Collections.ArrayList items;
        }

        static void PlayingWithVariables()
        {
            int hours = 0;
            double rate = 10.25;

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

        static void PlayingWithReferences()
        {
            string message = "hello";
            string name = null;

            name = new string('*', 10);

            object instance = name;

            string str = instance as string;

            if (instance is string)
            {
                string str2 = (string)instance;
                Console.WriteLine(str);
            } else
                Console.WriteLine("Not a string");
        }
    }
}
