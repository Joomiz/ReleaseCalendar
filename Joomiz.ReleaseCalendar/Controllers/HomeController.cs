using Joomiz.ReleaseCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Joomiz.ReleaseCalendar.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index(int year = 0, string description = "Default")
        {

            if (year == 0)
                year = DateTime.Now.Year;

            var calendar = new Calendar(year, description);

            var periodRepository = new PeriodRepository();
            calendar.InfrastructurePeriods = periodRepository.GetInfrastructurePeriods(year, description);
            calendar.ReleasePeriods = periodRepository.GetReleasePeriods(year, description);
            calendar.FreezingPeriods = periodRepository.GetFreezingPeriods(year, description);

            /*calendar.ReleasePeriods.Add(new Period(new DateTime(2015, 1, 10), new DateTime(2015, 1, 22)));
            calendar.FreezingPeriods.Add(new Period(new DateTime(2015, 2, 7), new DateTime(2015, 2, 16)));
            calendar.InfrastructurePeriods.Add(new Period(new DateTime(2015, 1, 10), new DateTime(2015, 1, 11)));
            calendar.InfrastructurePeriods.Add(new Period(new DateTime(2015, 1, 17), new DateTime(2015, 1, 18)));*/



            return View(calendar);
        }

    }
}
