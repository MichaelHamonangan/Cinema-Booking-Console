using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Booking_System
{
    interface TicketBuilder
    {
        void TicketHeader(string path);
        void TicketBody(string path, string posisi);
        void TicketFooter(string path);

        void TicketBarcode(string path);
    }
}
