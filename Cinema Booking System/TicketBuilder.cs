using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;
using Xceed.Document.NET;
using System.Diagnostics;


namespace Cinema_Booking_System
{
    interface TicketBuilder
    {
        void TicketHeader(Xceed.Words.NET.DocX doc, string path);
        void TicketBody(Xceed.Words.NET.DocX doc, string path, string posisi);
        void TicketFooter(Xceed.Words.NET.DocX doc, string path);

        void TicketBarcode(string path);
    }
}
