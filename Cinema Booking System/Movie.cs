using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Booking_System
{
    class Movie
    {
        private string movieName;
        private int movieDuration;
        private int moviePrice;

        public DateTime startTime;
        public DateTime endTime;

        private string movieDetail;
        public string MovieName { get => movieName; set => movieName = value; }
        public int MovieDuration{ get => movieDuration; set => movieDuration = value; }
        public string MovieDetail { get => movieDetail; set => movieDetail = value; }
        public int MoviePrice { get => moviePrice; set => moviePrice = value; }

        protected Seats movieSeat;
        internal MoviePrice harga;

        public Movie(string name, int duration, DateTime time, int price, string detail)
        {
            MovieName = name;
            MovieDuration = duration;
            MoviePrice = price;
            MovieDetail = detail;
            movieSeat = new Seats();

            startTime = time;
            endTime = startTime.AddMinutes(duration);

            harga = new MoviePrice(price);
        }

        public void ShowMovieDetail()
        {
            int hour = 0, minutes = 0;
            if (movieDuration >= 60)
            {
                hour = movieDuration / 60;
                minutes = movieDuration % 60;
            }

            Console.WriteLine("\nFilm '{0}'\nDurasi : {1} Jam {2} Menit\nDetail : {3} \nWaktu : {4}\nHarga : {5} rupiah", movieName, hour, minutes, movieDetail, startTime, moviePrice);
        }

        public string ShowForm()
        {
            Console.Write("\nBerapa banyak tiket yang ingin dipesan?\nJumlah Tiket : ");
            int NOticket = 1;
            try
            {
                NOticket = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Error, tidak ada input yang diterima");
                return "";
            }

            string letak = "";
            bool isValid = true;
            if (NOticket < 1)
            {
                Console.WriteLine("Error! Input tidak boleh kurang dari 1");
                isValid = false;
            }

            movieSeat.printAvailableSeats();
            if (NOticket == 1)
            {
                Console.Write("Pilih posisi tempat duduk \nPosisi : ");
            }
            else if (NOticket > 1)
            {
                Console.Write("Pilih posisi tempat duduk (pisahkan satu sama lain dengan spasi (ex: 11 23 34)\nPosisi : ");
            }

            letak = Console.ReadLine();
            string[] arrLetak = movieSeat.ConvertToArray(letak, NOticket);
            if (arrLetak != null)
            {
                isValid = movieSeat.Reserve(arrLetak);
            }
            else
            {
                isValid = false;
            }

            harga.totalPrices(NOticket);
            if (isValid == true)
            {
                return letak;
            }
            else
            {
                return "";
            }
        }
    }
}
