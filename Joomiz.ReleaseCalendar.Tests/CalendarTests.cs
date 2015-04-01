using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Joomiz.ReleaseCalendar.Models;

namespace Joomiz.ReleaseCalendar.Tests
{
    [TestClass]
    public class CalendarTests
    {
        [TestMethod]
        public void Month_Shoud_Be_Named_Correctly()
        {            
            var month = new Month(1, 2015);

            Assert.IsTrue(month.Name == "January");
        }

        

        [TestMethod]
        public void FirstWeekDay_Shoud_Be_Named_Correctly()
        {
            var month = new Month(1, 2015);

            Assert.IsTrue(month.FirstWeekDay == DayOfWeek.Thursday);
        }


        [TestMethod]
        public void Month_Shoud_Have_31_Days()
        {
            var month = new Month(1, 2015);

            Assert.IsTrue(month.DaysInMonth == 31);
        }

        [TestMethod]
        public void Year_Shoud_Have_12_Months()
        {
            var year = new Year(2015);

            Assert.IsTrue(year.Months.Count == 12);
        }



        [TestMethod]
        public void Month_2015_January_Shoud_Have_5_Weeks()
        {
            var month = new Month(1, 2015);

            Assert.IsTrue(month.TotalWeeks() == 5);
        }


        [TestMethod]
        public void Month_2015_February_Shoud_Have_4_Weeks()
        {
            var month = new Month(1, 2015);

            Assert.IsTrue(month.TotalWeeks() == 5);
        }

        [TestMethod]
        public void Month_2015_August_Shoud_Have_6_Weeks()
        {
            var month = new Month(1, 2015);

            Assert.IsTrue(month.TotalWeeks() == 5);
        }
    }
}
