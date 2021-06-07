using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;
using Xceed.Document.NET;
using System.Diagnostics;

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

                string Path = @"D:\Tiket-" + MovieName + "-seat" + Convert.ToString(posisi) + ".docx";
                Xceed.Words.NET.DocX doc = DocX.Create(Path);
                TicketHeader(doc, Path);
                TicketBody(doc, Path, posisi);
                TicketFooter(doc, Path);

                Console.Write("\nTiket telah dibuat dengan direktori {0}", Path);
            }
        }

        public void TicketHeader(Xceed.Words.NET.DocX doc, string path)
        {
            if (!File.Exists(path))
            {
                string title = "CINEMA BOOKING E-Ticket";

                Xceed.Document.NET.Formatting titleFormat = new Formatting();  
                titleFormat.FontFamily = new Font("Batang"); 
                titleFormat.Size = 18;
                titleFormat.Position = 40;
                titleFormat.FontColor = System.Drawing.Color.DarkBlue;
                titleFormat.UnderlineColor = System.Drawing.Color.Gray;
                titleFormat.Bold = true;

                Paragraph paragraphTitle = doc.InsertParagraph(title, false, titleFormat);
                paragraphTitle.Alignment = Alignment.center;
            }
        }

        public void TicketFooter(Xceed.Words.NET.DocX doc, string path)
        {
            string title = "------------------Enjoy your joy!!------------------";

            Xceed.Document.NET.Formatting titleFormat = new Formatting();
            titleFormat.FontFamily = new Font("Batang");
            titleFormat.Size = 14;
            titleFormat.Position = 40;
            titleFormat.FontColor = System.Drawing.Color.BlueViolet;
            titleFormat.Italic = true;

            Paragraph paragraphTitle = doc.InsertParagraph(title, false, titleFormat);
            paragraphTitle.Alignment = Alignment.center;

            doc.Save();
            Process.Start("WINWORD.EXE", path);
        }

        public void TicketBody(Xceed.Words.NET.DocX doc, string path, string posisi)
        {
            string textParagraph = "FILM\t: " + MovieName + Environment.NewLine + 
                                   "Start\t: " + startTime.ToString() + "\t\t\tSeat\t: " + posisi + Environment.NewLine + 
                                   "End\t: " + endTime.ToString() + Environment.NewLine + Environment.NewLine +
                                   "Reserved by\t: " + Subjek.username + Environment.NewLine + 
                                   "Email\t\t\t: " + Subjek.email + Environment.NewLine + Environment.NewLine;

            Formatting textParagraphFormat = new Formatting(); 
            textParagraphFormat.FontFamily = new Font("Century Gothic");
            textParagraphFormat.Size = 10;
            textParagraphFormat.Spacing = 2;

            doc.InsertParagraph(textParagraph, false, textParagraphFormat);
        }

        public void TicketBarcode(string path) { }
    }
}
