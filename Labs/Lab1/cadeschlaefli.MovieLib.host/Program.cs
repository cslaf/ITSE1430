using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadeschlaefli.MovieLib.host
{
    class Program
    {
        static void Main( string[] args )
        {
            

        }
    }

    class commandLineMenu
    {
        List<String> commands;
        List<String> descriptions;

    }


    class Movie
    {
        string title, description;
        int length;
        bool ownership;

        void setTitle()
        {
            string toCheck;
            do
            {
                Console.WriteLine("Enter title:\n");
                toCheck = Console.ReadLine();
                if (toCheck.Length == 0)
                {
                    Console.WriteLine("You must enter a name\n");
                } else
                {
                    title = toCheck;
                    break;
                }
            } while (true);
        }

        void setDescription()
        {
            Console.WriteLine("Enter optional description:\n");
            description = Console.ReadLine();
        }

        void setLength()
        {
            string toCheck;
            do
            {
                Console.WriteLine("Enter optional length in mins(or 0):\n");
                toCheck = Console.ReadLine();
                if (Int32.TryParse(toCheck, out length))
                {
                    if (length >= 0)
                    {
                        break;
                    }
                }
                Console.WriteLine("Length must be a whole number >= 0:\n");
            } while (true);
        }

        void setOwnership()
        {
            string toCheck;
            do
            {
                Console.WriteLine("Do you own the Movie? (Y/N)\n");
                toCheck = Console.ReadLine();
                switch (toCheck)
                {
                        case "y":
                        case "Y":
                        ownership = true;
                        break;
                        case "n":
                        case "N":
                        ownership = false;
                        break;
                        default:
                            Console.WriteLine("Enter actual option");
                    break;
                } 
            } while (true);
        }

        public void setInfo()
        {
            setTitle();

            setDescription();

            setLength();

            setOwnership();
        }
        

    }


    class MovieController
    {
        List<Movie> mList;
        public void listMovies()
        {

        }
        public void addMovie()
        {
            Movie toAdd = new Movie();
            toAdd.setInfo();
            mList.Add(toAdd);
        }
        public void removeMovie()
        {

        }
    }
}