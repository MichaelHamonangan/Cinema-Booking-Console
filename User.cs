using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Booking_System
{
    abstract class User
    {
        public string username;
        public abstract void Welcome();
        public abstract string Exit();
    }
}
