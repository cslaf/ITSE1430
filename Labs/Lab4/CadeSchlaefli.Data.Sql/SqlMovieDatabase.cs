using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadeSchlaefli.MovieLib;
using CadeSchlaefli.MovieLib.Data;

namespace CadeSchlaefli.Data.Sql
{
    public class SqlMovieDatabase : MovieDatabase
    {
        private readonly string _connectionString;
        public SqlMovieDatabase(string connectionString)
        {
            if (connectionString == null)
                throw new ArgumentNullException(nameof(connectionString));
            if (connectionString == "")
                throw new ArgumentException("Connection String cannot be empty", nameof(connectionString));

            _connectionString = connectionString;
        }

        protected override Movie AddCore( Movie movie )
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("AddMovie", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@title", movie.Title);
                cmd.Parameters.AddWithValue("@description", movie.Description);
                cmd.Parameters.AddWithValue("@length", movie.Length);
                cmd.Parameters.AddWithValue("@isOwned", movie.IsOwned);

                conn.Open();
                var result = cmd.ExecuteScalar();
                var id = Convert.ToInt32(result);
                movie.Id = id;
            }
            return movie;
        }

        protected override IEnumerable<Movie> GetAllCore()
        {        
            var items = new List<Movie>();
            using( var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("GetAllMovies", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();

                var ds = new DataSet();

                var da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                if(ds.Tables.Count == 1)
                {
                    foreach(var row in ds.Tables[0].Rows.OfType<DataRow>())
                    {
                        var movie = new Movie() {
                            Id = Convert.ToInt32(row["Id"]),
                            Title = row.Field<string>("Title"),
                            Description = row.Field<string>("Description"),
                            Length = row.Field<int>("Length"),
                            IsOwned = row.Field<bool>("IsOwned")
                        };

                        items.Add(movie);
                    }
                }
            }
            return items;
        }

        protected override Movie GetCore( int id )
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("GetMovie", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", id));
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var movie = ReadData(reader);
                        return movie;
                    }
                }
            }
            return null;
        }

        protected override Movie GetCore( string title )
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("GetAllMovies", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var movie = ReadData(reader);
                        if (movie.Title == title)
                            return movie;
                    }
                }
            }
            return null;
        }

        protected override void RemoveCore( Movie movie )
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("RemoveMovie", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", movie.Id));
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return;
        }

        protected override Movie UpdateCore( Movie movie )
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("UpdateMovie", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", movie.Id));
                cmd.Parameters.AddWithValue("@title", movie.Title);
                cmd.Parameters.AddWithValue("@length", movie.Length);
                cmd.Parameters.AddWithValue("@description", movie.Description);
                cmd.Parameters.AddWithValue("@isOwned", movie.IsOwned);

                //var parm = cmd.CreateParameter();
                //parm.ParameterName = "@isDiscontinued";
                //parm.DbType = System.Data.DbType.Boolean;
                //parm.Value = product.IsDiscontinued;
                //cmd.Parameters.Add(parm);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return movie;
            ;
        }

        private static Movie ReadData( SqlDataReader reader )
        {
            return new Movie() {
                Id = reader.GetInt32(0),
                Title = Convert.ToString(reader["Title"]),
                IsOwned = Convert.ToBoolean(reader["IsOwned"]),
                Description = Convert.ToString(reader["Description"]),
                Length = Convert.ToInt32(reader["Length"])
            };
        }

    }
}
