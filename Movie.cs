using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalManagementSystem
{
    internal class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public decimal RentalPrice { get; set; }


        public Movie(int movieId, string title, string director, decimal rentalPrice)
        {
            MovieId = movieId;
            Title = title;
            Director = director;
            RentalPrice = rentalPrice;
        }

        public Movie(string title, string director, decimal rentalPrice) 
        {
            Title = title;  
            Director = director;
            RentalPrice = rentalPrice;
        
        }
        public Movie()
        {
            
        }

        public override string ToString()
        {
            return $"ID: {MovieId}, Title: {Title}, Director: {Director}, RentalPrice: {RentalPrice}";
        }
    }
}
