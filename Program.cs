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
            movieManager.CreateTable();


            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Movie Rental Management System:");
                Console.WriteLine("1. Add a Movie");
                Console.WriteLine("2. View All Movies");
                Console.WriteLine("3. Update a Movie");
                Console.WriteLine("4. Delete a Movie");
                Console.WriteLine("5. Get By Id");
                Console.WriteLine("6. Exit");


                Console.WriteLine("Choose an option:");


                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ClearConsole();

                        Console.WriteLine("Add Movies");
                        //Console.Write("Enter The Movie id: ");
                        //int id = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter The Movie Title: ");
                        string title = Console.ReadLine();
                        string capitalize = char.ToUpper(title[0]) + title.Substring(1);

                        Console.Write("Enter The Movie Director: ");
                        string director = Console.ReadLine();

                        Console.Write("Enter The Movie rentalPrice: ");
                        decimal rentalPrice = Convert.ToDecimal(Console.ReadLine());

                        decimal validateMovieRentalPrice = movieManager.ValidateMovieRentalPrice(rentalPrice);
                        movieManager.CreateMovie(new Movie(capitalize, director, validateMovieRentalPrice));

                        break;

                    case "2":
                        ClearConsole();
                        Console.WriteLine("View Movies");
                        movieManager.ReadMovies();

                        break;

                    case "3":
                        ClearConsole();
                        Console.WriteLine("Update Movies");

                        Console.Write("Enter The Movie id: ");
                        int movieid = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter The Movie newTitle: ");
                        string newTitle = Console.ReadLine();

                        Console.Write("Enter The Movie newdirector: ");
                        string newdirector = Console.ReadLine();

                        Console.Write("Enter The Movie newrentalPrice: ");
                        decimal newrentalPrice = Convert.ToDecimal(Console.ReadLine());

                        decimal validateUpdateMovieRentalPrice = movieManager.ValidateMovieRentalPrice(newrentalPrice);
                        movieManager.UpdateMovie(movieid, newTitle, newdirector, validateUpdateMovieRentalPrice);

                        break;

                    case "4":
                        ClearConsole();
                        Console.WriteLine("Delete Movies");

                        Console.Write("Enter The Movie id: ");
                        int deleteid = Convert.ToInt32(Console.ReadLine());

                        movieManager.DeleteMovie(deleteid);

                        break;

                    case "5":

                        ClearConsole();
                        Console.WriteLine("getBy id Movies");

                        Console.Write("Enter The Movie id: ");
                        int getid = Convert.ToInt32(Console.ReadLine());
                        movieManager.GetById(getid);

                        break;

                    case "6":

                        Environment.Exit(0);

                        break;

                    

                    default:
                        ClearConsole();
                        Console.WriteLine("Enter the Correct Number");
                        break;
                }



            }


            void ClearConsole()
            {
                Console.Clear();
            }
        }

    }
}

