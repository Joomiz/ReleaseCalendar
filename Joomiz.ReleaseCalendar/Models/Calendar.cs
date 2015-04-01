using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joomiz.ReleaseCalendar.Models
{
    public class Calendar
    {
        public Year Year { get; set; }
        public string Description { get; set; }
        public List<Period> FreezingPeriods { get; set; }
        public List<Period> ReleasePeriods { get; set; }
        public List<Period> InfrastructurePeriods { get; set; }

        public Calendar(int year)
        {
            this.FreezingPeriods = new List<Period>();
            this.ReleasePeriods = new List<Period>();
            this.InfrastructurePeriods = new List<Period>();

            this.Year = new Year(year);
        }

        public Calendar(int year, string description) : this(year)
        {
            this.Description = description;
        }

        public bool IsRelease(DateTime date)
        {
            bool isRelease = this.IsReleaseDate(date);
            bool isFreezing = this.IsFreezingDate(date);
            bool isInfrastructure = this.IsInfrastructureDate(date);

            return isRelease && !isFreezing && !isInfrastructure;
        }

        public bool IsInfrastructure(DateTime date)
        {            
            bool isInfrastructure = this.IsInfrastructureDate(date);
            bool isFreezing = this.IsFreezingDate(date);

            return isInfrastructure && !isFreezing;
        }

        public bool IsFreezing(DateTime date)
        {
            return this.IsFreezingDate(date);
        }


        #region Private Methods

        private bool IsReleaseDate(DateTime date)
        {
            return this.ReleasePeriods.Find(x => date >= x.Start && date <= x.End) != null;
        }

        private bool IsFreezingDate(DateTime date)
        {
            return this.FreezingPeriods.Find(x => date >= x.Start && date <= x.End) != null;
        }

        public bool IsInfrastructureDate(DateTime date)
        {
            return this.InfrastructurePeriods.Find(x => date >= x.Start && date <= x.End) != null;
        }

        #endregion
    }
}