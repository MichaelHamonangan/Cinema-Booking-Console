using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieDatabase;

namespace Cinema_Booking_System
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Movie> lstMovie = new List<Movie>();
            
            data.SetConnectionString(ConfigurationManager.ConnectionStrings["Cinema_Booking_System.Properties.Settings.connString"].ConnectionString);
            data[] movies = data.Read();

            foreach (data movie in movies)
            {
                Movie temp = new Movie(movie.MovieName, movie.MovieDuration, movie.MovieTime, movie.MoviePrice, movie.MovieDetail);
                lstMovie.Add(temp);
            }
            Movie[] arrTemp = lstMovie.ToArray();

            string execute = "";
            while (execute != "END PROGRAM")
            {
                Console.WriteLine("Input Username : ");
                string name = Console.ReadLine();

                Console.WriteLine("Input Email : ");
                string email = Console.ReadLine();

                Custommer Subject = new Custommer(name, email);
                Subject.Welcome();

                int indicator = 0, index;
                while (indicator != 1)
                {
                    string letak = "";
                    Console.WriteLine("\nPilih Film :");
                    for (int i = 0; i < arrTemp.Length; i++)
                    {
                        Console.WriteLine("{0}. {1}", i+1,arrTemp[i].MovieName);
                    }

                    try
                    {
                        index = Convert.ToInt32(Console.ReadLine()) - 1;
                        arrTemp[index].ShowMovieDetail();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error!!! Input tidak sesuai");
                        continue;
                    }

                    Console.WriteLine("1.Beli\n0.Kembali");

                    try
                    {
                        indicator = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error!!! Input tidak sesuai");
                        continue;
                    }
                    
                    if (indicator == 1)
                    {
                        letak = arrTemp[index].ShowForm();
                        if (letak != "")
                        {
                            Subject.Payment(arrTemp[index]);
                            MovieTicket tiket = new MovieTicket(arrTemp[index].MovieName, arrTemp[index].MovieDuration, arrTemp[index].startTime, arrTemp[index].MoviePrice, arrTemp[index].MovieDetail, Subject);
                            tiket.printTicket(letak);
                        }
                    }
                }
                execute = Subject.Exit();
            }
        }
    }
}
