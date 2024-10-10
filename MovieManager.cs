using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalManagementSystem
{
    internal class MovieManager
    {
        //private List<Movie> Movies = new List<Movie>();

        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MovieRentalManagement;Integrated Security=True";


        public void CreateTable()
        {
            using(var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                                        IF NOT EXISTS(SELECT * FROM sys.tables WHERE name = 'Movies')
                                        BEGIN
                                        CREATE TABLE Movies(
                                        MovieId INT IDENTITY(1,1) PRIMARY KEY,
                                        Title NVARCHAR(50),
                                        Director NVARCHAR(50),
                                        RentalPrice DECIMAL
                                        );
                                        END ";

                command.ExecuteNonQuery();

            }
        }



        public void CreateMovie(Movie movie)
        {
            using( var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                                        INSERT INTO Movies(Title, Director, RentalPrice)
                                        VALUES(@Title, @Director, @RentalPrice)
                                        ";

                command.Parameters.AddWithValue("@Title", movie.Title);
                command.Parameters.AddWithValue("@Director", movie.Director);
                command.Parameters.AddWithValue("@RentalPrice", movie.RentalPrice);

                command.ExecuteNonQuery();

            }

            //Movies.Add(movie);
            Console.WriteLine("movie Add SuccessFully");
        }










        public void ReadMovies()
        {
            using(var connection =new SqlConnection(connectionString))
            {
                connection.Open();
               
                var listmovie = new List<Movie>();

                var command = connection.CreateCommand();
                command.CommandText = @"
                                        SELECT * FROM Movies
                                        ";

                using (var reader = command.ExecuteReader()) 
                while (reader.Read())
                {
                        var movie = new Movie
                        {
                            MovieId = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Director = reader.GetString(2),
                            RentalPrice = reader.GetDecimal(3)


                        };

                        listmovie.Add(movie);
                        Console.WriteLine(movie.ToString());
                }

            }
               


            //foreach (Movie movie in Movies)
            //{
            //    Console.WriteLine(movie.ToString());
                
            //}
        }

        public void GetById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                                        SELECT * FROM Movies
                                        WHERE MovieId = @id
                                        ";

                command.Parameters.AddWithValue("@id", id);
                using(var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var movie = new Movie
                        {
                            MovieId=reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Director = reader.GetString(2),
                            RentalPrice=reader.GetDecimal(3)
                        };
                        Console.WriteLine(movie.ToString());
                    }
                }
            }
        }


        public void UpdateMovie(int movieId, string newTitle, string newdiector, decimal newPrice)
        {


            using(var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                                        UPDATE Movies
                                        SET Title = @Title, 
                                        Director = @Director, 
                                        RentalPrice = @RentalPrice
                                        WHERE MovieId = @id
                                        ";

                command.Parameters.AddWithValue("@id", movieId);
                command.Parameters.AddWithValue("@Title", newTitle);
                command.Parameters.AddWithValue("@Director", newdiector);
                command.Parameters.AddWithValue("@RentalPrice", newPrice);

                command.ExecuteNonQuery();
            }

            Console.WriteLine("Updater successfully");








            //var movie = Movies.Find(x => x.MovieId == movieId);
            //if (movie != null)
            //{
            //    movie.Title = newTitle;
            //    movie.Director = newdiector;
            //    movie.RentalPrice = newPrice;

            //    Console.WriteLine("Movie updatedSuccesfully");

            //}
            //else 
            //    {
            //        Console.WriteLine("No movie there");
            //    }
        }


        public void DeleteMovie(int movieId)
        {
            using( var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                                        DELETE Movies
                                        WHERE MovieId = @id 
                                        ";

                command.Parameters.AddWithValue("@id", movieId);
                command.ExecuteNonQuery();
            }

            Console.WriteLine("movie Deleted successfully");

            //Movies.RemoveAll(x => x. MovieId == movieId);
            //Console.WriteLine("movie Deleted successfully");
        }


        public decimal ValidateMovieRentalPrice(decimal price)
        {
            if (price > 0)
            {
                return price;
            }
            else
            {
                while (price <= 0)
                {
                    Console.WriteLine("Enter The Price for Positive Value");
                    Console.Write("Reenter The Price: ");
                     price = Convert.ToDecimal(Console.ReadLine());

                }

                return price;

            }
        }
    }
}
