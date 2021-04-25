using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Booking_System
{
    class MovieTicket : Movie, TicketBuilder
    {
        protected Custommer Subjek;
        public MovieTicket(string name, int duration, DateTime time, int price,string detail ,Custommer subjek) : base(name, duration, time, price, detail)
        {
            MovieName = name;
            MovieDuration= duration;
            startTime = time;
            endTime = startTime.AddMinutes(duration);

            MoviePrice = price;
            MovieDetail = detail;

            Subjek = subjek;
        }

        public void printTicket(string letak)
        {
            char[] separator = { ' ' };
            string[] temporary = letak.Split(separator);

            for (int i = 0; i < temporary.Length; i++)
            {
                string posisi = temporary[i];

                string Path = @"D:/Tiket " + MovieName + " seat-" + Convert.ToString(posisi) + ".txt";
                TicketHeader(Path);
                TicketBody(Path, posisi);
                TicketFooter(Path);

                Console.Write("\nTiket telah dibuat dengan direktori {0}", Path);
            }
        }

        public void TicketHeader(string path)
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("---------------CINEMA BOOKING E-Ticket--------------\n");
                }
            }
        }

        public void TicketFooter(string path)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("------------------Enjoy your joy!!------------------");
            }
        }

        public void TicketBody(string path, string posisi)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("FILM : {0}", MovieName);
                sw.WriteLine("\nStart : {0}          Seat : {1}", startTime, posisi);
                sw.WriteLine("End   : {0}", endTime);
                sw.WriteLine("\nReserved by : {0}\nemail       : {1} \n", Subjek.username, Subjek.email);
            }
        }

        public void TicketBarcode(string path) { }
    }
}
