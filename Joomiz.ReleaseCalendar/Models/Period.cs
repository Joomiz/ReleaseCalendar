using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joomiz.ReleaseCalendar.Models
{
    public class Period
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public Period(DateTime start, DateTime end)
        {
            this.Start = start;
            this.End = end;
        }
    }
}