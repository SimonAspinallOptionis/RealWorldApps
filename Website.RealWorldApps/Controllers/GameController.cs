using System;
using System.Linq;
using System.Web.Mvc;

namespace Website.RealWorldApps.Controllers
{
    public class GameController : Controller
    {
        private Data Data { get; set; }

        public ActionResult Results()
        {
            Data = HomeController.Data;
            Data.League.Team.Results = Data.League.Team.Results.OrderByDescending(g => g.TipOff).ToList();
            return View(Data.League.Team.Results);
        }

        public ActionResult GameDetails(int id)
        {
            Data = HomeController.Data;
            return View(Data.League.Team.Results[id]);
        }

        public ActionResult Schedule()
        {
            Data = HomeController.Data;
            Data.League.Team.Schedule = Data.League.Team.Schedule.Where(f => f.TipOff > DateTime.Now).ToList();
            return View(Data.League.Team.Schedule);
        }

    }
}
