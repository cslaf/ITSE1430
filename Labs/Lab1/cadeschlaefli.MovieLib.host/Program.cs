using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Author: Cade Schlaefli
 * Course: ITSE-1430-21722
 * Date: 1/25/2018
 * 
 * 
 * 
*/
namespace cadeschlaefli.MovieLib.host
{
    class Program
    {
        static void Main( string[] args )
        {
            char pick;

            string[] mainMenuCommands = { "List Movies", "Add Movie", "Remove Movie", "Quit" };

            var movieList = new MovieList();

            Console.WriteLine("Use the number or first letter of each selection to make your choice");

            //main menu loop
            do
            {
                int index = 0;
                foreach (string commands in mainMenuCommands)
                {
                    index++;
                    Console.WriteLine(index+". "+commands);
                }

                pick = Console.ReadKey().KeyChar;
                Console.Write("\b"); //erases input
                
                switch (Char.ToUpper(pick))
                {
                    case '1':
                    case 'L':
                        movieList.PrintMovies();
                        break;
                    case '2':
                    case 'A':
                    //movieList.AddMovie();
                    movieList.EditMovie();
                        break;
                    case '3':
                    case 'R':
                    //movieList.RemoveMovie();
                    movieList.SimpleRemoveMovie();
                        break;
                    case '4':
                    case 'Q':
                        return;
                    default:
                        //Console.Clear();
                        //Console.WriteLine("Invalid input");
                        break;
                }

            } while (true); 
        }

    }
    //A class with methods for getting user input that needs to be validated in some way 
    public class InputChecker
    {

        //prompts user for yes or no answer to a question, returns a bool
        public static bool PromptYesNo( string userPrompt )
        {
            string toCheck;
            while (true)
            {
                Console.WriteLine(userPrompt);
                toCheck = Console.ReadLine();
                switch (toCheck)
                {
                    case "y":
                    case "Y":
                        return true;
                    case "n":
                    case "N":
                        return false;
                    default:
                    //Console.Write("Enter (Y/N):");
                        break;
                }
            }
        }

        public static int PromptFromRange( string userPrompt, int min, int max )
        {
            string userInput;
            int value;

            while (true)
            {
                Console.WriteLine(userPrompt);
                userInput = Console.ReadLine();
                if (Int32.TryParse(userInput, out value))
                {
                    if (value >= min && value <= max)
                    {
                        return value;
                    }
                }
                Console.WriteLine($"Please enter a whole nuber between {min} and {max}");
            }
        }

        public static int PromptFromRange( string userPrompt, int min, int max, int defaultValue )
        {
            string userInput;
            int value;

            while (true)
            {
                Console.WriteLine(userPrompt);
                userInput = Console.ReadLine();

                if (userInput == "")
                {
                    return defaultValue;
                }

                if (Int32.TryParse(userInput, out value))
                {
                    if (value >= min && value <= max)
                    {
                        return value;
                    }
                }
                Console.WriteLine($"Please enter a whole nuber between {min} and {max}");
            }
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
                Console.WriteLine("Enter title");
                toCheck = Console.ReadLine();
                if (toCheck.Length == 0)
                {
                    Console.WriteLine("You must enter a name");
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
            Console.WriteLine("Enter optional description:");
            description = Console.ReadLine();
        }

        void SetLength()
        {
            string userPrompt = "Enter optional length in mins:";
            length = InputChecker.PromptFromRange(userPrompt, 0, Int32.MaxValue, 0);
        }

        void SetOwnership()
        {
            string prompt = "Do you own the Movie? (Y/N)";
            ownership = InputChecker.PromptYesNo(prompt);

        }

        public void SetInfo()
        {
            SetTitle();

            SetDescription();

            SetLength();

            SetOwnership();
        }
        
        public void PrintInfo()
        {
            Console.WriteLine($"Title : {title}\n {description} \nRun Time = {length}");
            if (ownership)
            {
                Console.WriteLine("Owned");
            } else
            {
                Console.WriteLine("Not Owned");
            }
        }

    }

    //Manages Movies on the list by adding, removing, or changing info
    class MovieList
    {
        List<Movie> movies = new List<Movie>();

        public void PrintMovies()
        {
            int index = 0;
            if(movies.Count != 0)
            {
                foreach(Movie movie in movies)
                {
                    index++;
                    //Console.Write($"{index}. ");
                    movie.PrintInfo();
                }
            } else
            {
                Console.WriteLine("No Movies in list");
            }
        }

        public void PrintMoviesTitle()
        {
            if (movies.Count == 0)
            {
                Console.WriteLine("No Movies in list");
                return;
            }

            for (int index = 1; index <= movies.Count; index++)
            {
                Console.WriteLine($"{index} . {movies[index - 1].GetTitle()}");
            }
        }

        public void AddMovie()
        {
            Movie toAdd = new Movie();
            toAdd.SetInfo();
            movies.Add(toAdd);
        }

        //lists movies and prompts removal by number in the list
        public void RemoveMovie()
        {
            string loneDeletePrompt = "Remove the only remaining movie?(Y/N)",
                deletePrompt = "Are you sure you want to delete the movie (Y/N)?",
                listPrompt = "Remove which movie?(1-" + (movies.Count) + ")";
            
            PrintMoviesTitle();

            if (movies.Count > 1)
            {
                int movieNumber = InputChecker.PromptFromRange(listPrompt, 1, movies.Count);
                --movieNumber;                //OFFSET BY -1 FOR LIST
                if (InputChecker.PromptYesNo(deletePrompt))
                {
                    movies.RemoveAt(movieNumber);
                    Console.WriteLine($"{movies[movieNumber].GetTitle()} deleted");
                } else
                {
                    Console.WriteLine("Canceled");
                }
            } else
            {
                if (InputChecker.PromptYesNo(loneDeletePrompt))
                {
                    Console.WriteLine($"{movies[0].GetTitle()} deleted");
                    movies.RemoveAt(0);
                } else
                {
                    Console.WriteLine("Canceled");
                }
            }
        }
        //just for imitating lab1
        public void SimpleRemoveMovie()
        {
            string loneDeletePrompt = "Remove the only remaining movie?(Y/N)";

            if (movies.Count == 0)
            {
                Console.WriteLine("No Movies in list");
                return;
            }

            if (InputChecker.PromptYesNo(loneDeletePrompt))
            {
                Console.WriteLine(movies[0].GetTitle() + " deleted");
                movies.RemoveAt(0);
            } else
            {
                Console.WriteLine("Canceled");
            }
        }
        //add functionality later, right now being used to imitate not using a list

        public void EditMovie()
        {
            //just for imitation, should just return an error message
            if(movies.Count == 0)
            {
                AddMovie();
            } else
            {
                movies[0].SetInfo();
            }

            //select from list
            if (movies.Count > 1)
            {
                string listPrompt = "Edit which movie?";

                PrintMoviesTitle();

                int movieNumber = InputChecker.PromptFromRange(listPrompt, 1, movies.Count);
                --movieNumber;                //OFFSET BY -1 FOR LIST
                if (InputChecker.PromptYesNo($"Edit {movies[movieNumber].GetTitle()}"))
                {
                    movies[movieNumber].SetInfo();
                } else
                {
                    Console.WriteLine("Canceled");
                }
            }


        }
    }
}