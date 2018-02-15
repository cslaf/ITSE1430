using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeSchlaefli.MovieLib
{
    /// <summary>Provides info about a movie. </summary>
    public class Movie
    {
        /// <summary>Title of the Movie. </summary>
        public string Title { get; set; } = "";
        /// <summary>Description of the Movie. </summary>
        public string Description { get; set; }
        /// <summary>Length of the Movie in Minutes. </summary>
        public int Length { get; set; }
        /// <summary>If the movie is owned. </summary>
        public bool IsOwned { get; set; }

        /// <summary>Checks input to see if valid</summary>
        /// <returns>Error message or ""</returns>
        public string Validate()
        {
            if (String.IsNullOrEmpty(Title))
                return "Title cannot be empty";
            if (Length < 0)
                return "Price must be >= 0";
            return "";
        }

    }
}
