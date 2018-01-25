using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Author: Cade Schlaefli
 * Course: ITSE-1430-21722
 * Date: 1/24/2018
 * 
 * Todo: clean up MovieList.removeMovie, 
 * edit main menu it so it only holds 1 movie
*/
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

            MovieList movieList = new MovieList();

            //main menu loop
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
                            movieList.ListMovies();
                            break;
                        case 2:
                            movieList.AddMovie();
                            break;
                        case 3:
                            movieList.RemoveMovie();
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

        void SetTitle()
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

        public string GetTitle()
        {
            return title;
        }

        void SetDescription()
        {
            Console.WriteLine("Enter optional description:\n");
            description = Console.ReadLine();
        }

        void SetLength()
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

        void SetOwnership()
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

        public void SetInfo()
        {
            SetTitle();

            SetDescription();

            SetLength();

            SetOwnership();
        }
        
        public void ListInfo()
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

    //Manages Movies on the list by adding, removing, or changing info
    class MovieList
    {
        List<Movie> movieList = new List<Movie>();

        public void ListMovies()
        {
            if(movieList.Count != 0)
            {
                foreach(Movie m in movieList)
                {
                    m.ListInfo();
                }
            } else
            {
                Console.WriteLine("No Movies in list");
            }
        }

        public void AddMovie()
        {
            Movie toAdd = new Movie();
            toAdd.SetInfo();
            movieList.Add(toAdd);
        }

        //lists movies with numbers to be removed
        public void RemoveMovie()
        {
            string userInput;


            if (movieList.Count == 0)
            {
                Console.WriteLine("No Movies in list");
                return;
            }

            for (int i = 0; i < movieList.Count ; i++)
            {
                Console.WriteLine(i + ". " + movieList[i].GetTitle()+"\n");
            }

            do
            {
                if (movieList.Count > 1)
                {
                    Console.WriteLine("Remove which movie?(0-" + (movieList.Count - 1) + ")\n");
                    userInput = Console.ReadLine();
                    if (Int32.TryParse(userInput, out var movieNumber))
                    {
                        if ((movieNumber >= 0) && (movieNumber <= movieList.Count - 1))
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
                                        movieList.RemoveAt(movieNumber);
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
                            movieList.RemoveAt(0);
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