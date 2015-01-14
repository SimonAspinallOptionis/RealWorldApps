using System.Web.Mvc;
using System.Collections.Generic;
using Website.RealWorldApps.Models;
using System.Linq;
using System;

namespace Website.RealWorldApps.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            var data = new Data();
            data.AddNews();
            data.AddGames();
            data.AddSchedule();
            var fixture = data.Schedule.Where(g => g.TipOff > DateTime.Now).OrderBy(g => g.TipOff).ToList()[0];
            var result = data.Games.Where(g => g.TipOff < DateTime.Now).OrderByDescending(g => g.TipOff).ToList()[0];
            ViewBag.FixtureDate = fixture.TipOff;
            ViewBag.FixtureOpponent = fixture.OpponentName;
            ViewBag.FixtureLocation = fixture.Location;
            ViewBag.ResultDate = result.TipOff;
            ViewBag.ResultOpponent = result.OpponentName;
            ViewBag.ResultLocation = result.Location;
            string wonLoss;
            if(result.WonGame)
            {
                wonLoss="W";
            }
            else
            {
                wonLoss="L";
            }
            ViewBag.ResultScore = string.Format("{0} : {1} {2}", result.CheshireScore, result.OpponentScore, wonLoss);
            return View(data.News);
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }
    }
}
