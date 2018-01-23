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
            bool quit = false;
            int pick;
            string userInput;

            string[] mainMenuCommands = { "1. List Movies", "2. Add Movie", "3. Remove Movie", "4. Quit" };

            MovieList MovieList = new MovieList();

            do
            {
                foreach (string c in mainMenuCommands)
                {
                    Console.WriteLine(c + "\n");
                }
                userInput = Console.ReadLine();

                if (Int32.TryParse(userInput, out pick))
                {
                    switch (pick)
                    {
                        case 1:
                        MovieList.listMovies();
                        break;
                        case 2:
                        MovieList.addMovie();
                        break;
                        case 3:
                        MovieList.removeMovie();
                        break;
                        case 4:
                        quit = true;
                        break;
                        default:
                        Console.WriteLine("Invalid input");
                        break;
                    }
                }

            } while (!quit);
            
        }
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

        public string getTitle()
        {
            return title;
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
            bool exit = false;
            do
            {
                Console.WriteLine("Do you own the Movie? (Y/N)\n");
                toCheck = Console.ReadLine();
                switch (toCheck)
                {
                        case "y":
                        case "Y":
                    ownership = true;
                    exit = true;
                    break;
                        case "n":
                        case "N":
                    ownership = false;
                    exit = true;
                    break;
                        default:
                    Console.WriteLine("Enter (Y/N)\n");
                    break;
                } 
            } while (!exit);
        }

        public void setInfo()
        {
            setTitle();

            setDescription();

            setLength();

            setOwnership();
        }
        
        public void listInfo()
        {
            Console.WriteLine(title + "\n" + description + "\nRun Length = " + length + "\n");
            if (ownership)
            {
                Console.WriteLine("Is Owned\n");
            } else
            {
                Console.WriteLine("Not Owned\n");
            }
        }

    }


    class MovieList
    {
        List<Movie> mList = new List<Movie>();
        public void listMovies()
        {
            if(mList.Count != 0)
            {
                foreach(Movie m in mList)
                {
                    m.listInfo();
                }
            } else
            {
                Console.WriteLine("No Movies in list");
            }
        }
        public void addMovie()
        {
            Movie toAdd = new Movie();
            toAdd.setInfo();
            mList.Add(toAdd);
        }
        public void removeMovie()
        {
            string userInput;
            int movieNumber;

            if (mList.Count == 0)
            {
                Console.WriteLine("No Movies in list");
                return;
            }

            for (int i = 0; i < mList.Count ; i++)
            {
                Console.WriteLine(i + ". " + mList[i].getTitle()+"\n");
            }

            do
            {
                if (mList.Count > 1)
                {
                    Console.WriteLine("Remove which movie?(0-" + (mList.Count - 1) + ")\n");
                    userInput = Console.ReadLine();
                    if (Int32.TryParse(userInput, out movieNumber))
                    {
                        if ((movieNumber >= 0) && (movieNumber <= mList.Count - 1))
                        {
                            bool exit = false;
                            do
                            {
                                Console.WriteLine("Are you sure you want to delete the movie (Y/N)?\n");
                                userInput = Console.ReadLine();
                                switch (userInput)
                                {
                                    case "y":
                                    case "Y":
                                    mList.RemoveAt(movieNumber);
                                    Console.WriteLine("\nMovie Removed");
                                    exit = true;
                                    break;
                                    case "n":
                                    case "N":
                                    Console.WriteLine("\nCanceled");
                                    exit = true;
                                    break;
                                    default:
                                    Console.WriteLine("\nEnter (Y/N)");
                                    break;
                                }
                            } while (!exit);
                            break;
                        }
                    }
                } else
                {
                    bool exit = false;
                    do
                    {
                        Console.WriteLine("Remove the only movie?(Y/N)\n");
                        userInput = Console.ReadLine();
                        switch (userInput)
                        {
                            case "y":
                            case "Y":
                            mList.RemoveAt(0);
                            Console.WriteLine("\nMovie Removed");
                            exit = true;
                            break;
                            case "n":
                            case "N":
                            Console.WriteLine("\nCanceled");
                            exit = true;
                            break;
                            default:
                            Console.WriteLine("\nEnter (Y/N)");
                            break;
                        }
                    } while (!exit);
                    break;

                }
            } while (true);
        }
    }
}