using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Author: Cade Schlaefli
 * Course: ITSE-1430-21722
 * Date: 2/28/2018
 * 
 * 
 * 
*/

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
                return "Length must be empty or >= 0";
            return "";
        }

    }
}
