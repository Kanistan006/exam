using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalManagementSystem
{
    internal class MovieManager
    {
        public List<Movie> Movies = new List<Movie>();

        public void CreateMovie(Movie movie)
        {
            Movies.Add(movie);
            Console.WriteLine("movie Add SuccessFully");
        }

        public void ReadMovies()
        {
            foreach (Movie movie in Movies)
            {
                Console.WriteLine(movie.ToString());
                
            }
        }


        public void UpdateMovie(int movieId, string newTitle, string newdiector, decimal newPrice)
        {
            var movie = Movies.Find(x => x.MovieId == movieId);
            if (movie != null)
            {
                movie.Title = newTitle;
                movie.Director = newdiector;
                movie.RentalPrice = newPrice;

                Console.WriteLine("Movie updatedSuccesfully");

            }
            else 
                {
                    Console.WriteLine("No movie there");
                }
        }


        public void DeleteMovie(int movieId)
        {
            Movies.RemoveAll(x => x. MovieId == movieId);
            Console.WriteLine("movie Deleted successfully");
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
