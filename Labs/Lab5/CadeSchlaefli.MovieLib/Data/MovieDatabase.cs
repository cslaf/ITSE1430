/*
 * Author: Cade Schlaefli
 * Course: ITSE-1430-21722
 * Date: 3/11/2018
*/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public Movie Add (Movie movie)
        {
            //check if null
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            var errors = ObjectValidator.Validate(movie);
            if(errors.Count() > 0)
                throw new ValidationException(errors.FirstOrDefault().ErrorMessage);

            var existing = GetCore(movie.Title);
            if (existing != null)
                throw new ArgumentException("Movie already exists", nameof(movie));

            return AddCore(movie);
        }

        public Movie Update(Movie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));


            var errors = movie.Validate();
            var error = errors.FirstOrDefault();
            if(errors != null)
                throw new ValidationException(errors.FirstOrDefault().ErrorMessage);
            
            //verify it exist, and is unique
            var existing = GetCore(movie.Title);

            if( existing != null && existing.Id != movie.Id)
                throw new ArgumentException("Movie already exists", nameof(movie));

            existing = existing ?? GetCore(movie.Id);
            if(existing == null)
                throw new ArgumentException("Movie not found", nameof(movie));

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
