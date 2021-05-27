using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cinema_Booking_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Booking_System.Tests
{
    [TestClass()]
    public class SeatsTests
    {
        [TestMethod()]
        public void ConvertToArrayTest()
        {
            var seat = new Seats();
            var NOticketEx = 3;
            var InputEx = "11 12 13";
            var HasilEx = seat.ConvertToArray(InputEx, NOticketEx);

            Assert.AreEqual("11", HasilEx[0]);
            Assert.AreEqual("12", HasilEx[1]);
            Assert.AreEqual("13", HasilEx[2]);
        }
    }
}