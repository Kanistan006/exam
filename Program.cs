using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MovieManager movieManager = new MovieManager();

            while (true)
            {
                Console.WriteLine("Movie Rental Management System:");
                Console.WriteLine("1. Add a Movie");
                Console.WriteLine("2. View All Movies");
                Console.WriteLine("3. Update a Movie");
                Console.WriteLine("4. Delete a Movie");
                Console.WriteLine("5. Exit");


                Console.WriteLine("Choose an option:");


                string option = Console.ReadLine();

                switch(option)
                {
                    case "1":
                        Console.Write("Enter The Movie id: ");
                        int id  = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter The Movie Title: ");
                        string title = Console.ReadLine();

                        Console.Write("Enter The Movie Director: ");
                        string director = Console.ReadLine();

                        Console.Write("Enter The Movie rentalPrice: ");
                        decimal rentalPrice = Convert.ToDecimal(Console.ReadLine());

                        movieManager.CreateMovie(new Movie(id, title, director, rentalPrice));

                        break;

                        case "2":

                        movieManager.ReadMovies();

                        break;

                        case "3":

                        Console.Write("Enter The Movie id: ");
                        int movieid = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter The Movie newTitle: ");
                        string newTitle = Console.ReadLine();

                        Console.Write("Enter The Movie newdirector: ");
                        string newdirector = Console.ReadLine();

                        Console.Write("Enter The Movie newrentalPrice: ");
                        decimal newrentalPrice = Convert.ToDecimal(Console.ReadLine());

                        movieManager.UpdateMovie( movieid,  newTitle,  newdirector,  newrentalPrice);

                        break;

                        case "4":
                        Console.Write("Enter The Movie id: ");
                        int deleteid = Convert.ToInt32(Console.ReadLine());

                        movieManager.DeleteMovie(deleteid);

                        break;

                        case "5":

                        Environment.Exit(0);

                        break;

                        default:
                        Console.WriteLine("Enter the Correct Number");
                        break;
                }



            }
        }

    }
}

