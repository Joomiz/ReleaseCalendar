using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joomiz.ReleaseCalendar.Models
{
    public class Year
    {
        public int Number { get; private set; }
        public List<Month> Months { get; private set; }

        public Year(int year)
        {
            this.Number = year;
            this.Months = new List<Month>();
            for (int month = 1; month < 13; month++)
            {
                this.Months.Add(new Month(month, year));
            }
        }
    }
}