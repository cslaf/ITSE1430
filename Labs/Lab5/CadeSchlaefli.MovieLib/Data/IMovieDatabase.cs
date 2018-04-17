/*
 * Author: Cade Schlaefli
 * Course: ITSE-1430-21722
 * Date: 3/11/2018
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeSchlaefli.MovieLib.Data
{
    /// <summary> Interface for adding, updating, getting and removing movies from database </summary>
    interface IMovieDatabase
    {
        /// <summary>Add a new Movie. </summary>
        /// <param name="movie"> The Movie to add.</param>
        /// <param name="message"> Error Message.</param>
        /// <returns>The added movie</returns>
        /// <remarks>Returns an error if Movie is null, invalid or if already exists in database. </remarks>
        Movie Add( Movie movie);
        /// <summary>Update an exisiting Movie.</summary>
        /// <param name="movie">The Movie to update.</param>
        /// <param name="message">Error Message. </param>
        /// <returns>The updated product.</returns>
        /// <remarks> Returns an error if Movie is null, invalid, or cannot be found. </remarks>
        Movie Update( Movie movie);
        /// <summary> Gets all Movie.</summary>
        /// <returns>The list of Movies as enumerable</returns>
        IEnumerable<Movie> GetAll();
        /// <summary> Removes a Movie by ID.</summary>
        /// <param name="id">The Movie ID.</param>
        void Remove( int id );

    }
}
