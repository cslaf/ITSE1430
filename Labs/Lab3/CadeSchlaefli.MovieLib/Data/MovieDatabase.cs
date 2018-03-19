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
    public abstract class MovieDatabase : IMovieDatabase
    {
        #region Abstract Members
        /// <summary> Gets all values from database</summary>
        /// <returns> The database as an IEnumerable</returns>
        protected abstract IEnumerable<Movie> GetAllCore();
        /// <summary> Adds a movie to the database </summary>
        /// <param name="movie">Movie to be added</param>
        /// <returns>The movie added, or null if could not add</returns>
        protected abstract Movie AddCore( Movie movie );
        /// <summary> Checks database for Movie by Id </summary>
        /// <param name="id"> The movie Id </param>
        /// <returns>The Movie from database if found, or null if not.</returns>
        protected abstract Movie GetCore( int id );
        /// <summary> Checks database for Movie by Title </summary>
        /// <param name="title"> The movie Title </param>
        /// <returns>The Movie from database if found, or null if not.</returns>
        protected abstract Movie GetCore( string title );
        /// <summary> Updates an movie in the database to the movie passed </summary>
        /// <param name="movie">The updated movie to be changed in the database</param>
        /// <returns> The updated movie, or null if could not update </returns>
        protected abstract Movie UpdateCore( Movie movie );
        /// <summary> Removes a provided movie, may want to change implementation to pass both existing and updated movie in future. Current implementation searches for it twice. </summary>
        /// <param name="movie">Movie to be removed </param>
        protected abstract void RemoveCore( Movie movie );

        #endregion

        public IEnumerable<Movie> GetAll()
        {
            return GetAllCore();
        }

        public Movie Add (Movie movie, out string message )
        {
            //check if null
            if(movie == null)
            {
                message = "Movie cannot be null,";
                return null;
            }

            var errors = ObjectValidator.Validate(movie);
            if(errors.Count() > 0)
            {
                //return first error
                message = errors.ElementAt(0).ErrorMessage;
                return null;
            }

            var existing = GetCore(movie.Title);
            if(existing != null)
            {
                message = "Product already exists.";
                return null;
            }

            message = null;
            return AddCore(movie);
        }

        public Movie Update(Movie movie,  out string message )
        {
            if (movie == null)
            {
                message = "Movie cannot be null,";
                return null;
            }

            var errors = ObjectValidator.Validate(movie);
            if(errors.Count() > 0)
            {
                //return first error
                message = errors.ElementAt(0).ErrorMessage;
                return null;
            }
            
            //verify it exist, and is unique
            var existing = GetCore(movie.Title);

            if( existing != null && existing.Id != movie.Id)
            {
                message = "Movie already exists.";
                return null;
            }

            existing = existing ?? GetCore(movie.Id);
            if(existing == null)
            {
                message = "Movie not found";
                return null;
            }

            message = null;
            return UpdateCore(movie);

        }

        public void Remove(int id )
        {
            //TODO: return error on id<= 0

            if(id > 0)
            {
                var existing = GetCore(id);
                if (existing != null)
                    RemoveCore(existing);
                    
            }
        }



    }
}
