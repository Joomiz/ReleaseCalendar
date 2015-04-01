using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Joomiz.ReleaseCalendar.Models
{
    public class Month
    {

        private DateTime FirstDay { get; set; }
        public int Number { get { return this.FirstDay.Month; } }
        public int Year { get { return this.FirstDay.Year; } }
        public string Name { get { return this.FirstDay.ToString("MMMM", CultureInfo.InvariantCulture); } }        
        public List<DateTime> Days { get; private set; }
        public DayOfWeek FirstWeekDay { get { return this.FirstDay.DayOfWeek; } }
        public int DaysInMonth { get; private set; }

        public Month(int month, int year)
        {            
            this.FirstDay = new DateTime(year, month, 1);
            this.DaysInMonth = DateTime.DaysInMonth(year, month);

            this.Days = new List<DateTime>();
            for (int day = 1; day <= this.DaysInMonth; day++)
            {
                this.Days.Add(new DateTime(year, month, day));
            }            
            
        }

        public int TotalWeeks()
        {
            int totalWeeks = 0;

            DateTime firstSunday = new DateTime(this.FirstDay.Year, this.FirstDay.Month, (7 - (int)this.FirstDay.DayOfWeek) + 1);

            if (firstSunday.Day != 1)
                totalWeeks++;

            while (this.FirstDay.Month == firstSunday.Month)
            {
                firstSunday = firstSunday.AddDays(7);
                totalWeeks++;
            }

            return totalWeeks;
            
        }

    }
}