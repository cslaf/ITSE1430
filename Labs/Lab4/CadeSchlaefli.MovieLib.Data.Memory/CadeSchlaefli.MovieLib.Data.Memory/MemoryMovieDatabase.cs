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

namespace CadeSchlaefli.MovieLib.Data.Memory
{
    public class MemoryMovieDatabase : MovieDatabase
    {
        protected override Movie AddCore( Movie movie )
        {
            movie.Id = _nextId++;
            _movies.Add(Clone(movie));

            return movie;
        }

        protected override IEnumerable<Movie> GetAllCore()
        {
           foreach (var movie in _movies)
            {
                if (movie != null)
                    yield return Clone(movie);
                
            }
        }

        protected override Movie GetCore( int id )
        {
            foreach (var movie in _movies)
            {
                if (movie.Id == id)
                    return movie;
            }
            return null;
        }

        protected override Movie GetCore( string title )
        {
                foreach (var movie in _movies)
            {
                if (String.Compare(movie.Title, title, true) == 0)
                    return movie;
            }
            return null;        
        }

        protected override void RemoveCore( Movie movie )
        {
            _movies.Remove(movie);
        }

        protected override Movie UpdateCore( Movie movie )
        {
            var existing = GetCore(movie.Id);
            Copy(existing, movie);
            return movie;
        }

        #region Private Members
        
        private int _nextId = 1;
        private readonly List<Movie> _movies = new List<Movie>();

        private Movie Clone( Movie movie )
        {
            var newMovie = new Movie();
            Copy(newMovie, movie);

            return newMovie;
        }

        private void Copy( Movie target, Movie src )
        {
            target.Id = src.Id;
            target.Title = src.Title;
            target.Description = src.Description;
            target.Length = src.Length;
            target.IsOwned = src.IsOwned;
        }
        #endregion
    }
}
