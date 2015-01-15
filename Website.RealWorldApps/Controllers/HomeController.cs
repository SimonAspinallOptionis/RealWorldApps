using System.Web.Mvc;
using System.Collections.Generic;
using Website.RealWorldApps.Models;
using System.Linq;
using System;

namespace Website.RealWorldApps.Controllers
{
    public class HomeController : Controller
    {
        public static Data Data { get; set; }

        public ActionResult Home()
        {
            Data = new Data();
            Data.AddLeagues();
            Data.AddNews();
            Data.AddImages();
            Data.AddTeam("Under 13", "White");
            Data.AddTeam("Under 13", "Green");
            Data.AddTeam("Under 14", "");
            Data.AddTeam("Under 15", "");
            Data.AddTeam("Under 16", "Conference");
            Data.AddTeam("Under 16", "Premier");
            Data.AddTeam("Under 18", "Conference");
            Data.AddTeam("Under 18", "Premier");

            Data.AddCoaches("Under 13", "White");
            Data.AddCoaches("Under 13", "Green");
            Data.AddCoaches("Under 14", "");
            Data.AddCoaches("Under 15", "");
            Data.AddCoaches("Under 16", "Conference");
            Data.AddCoaches("Under 16", "Premier");
            Data.AddCoaches("Under 18", "Conference");
            Data.AddCoaches("Under 18", "Premier");


            Data.AddGames("Under 13", "White");
            Data.AddSchedule("Under 13", "White");
            Data.AddPlayers("Under 13","White");
            Data.AddLeagueTable("Under 13");
            ViewBag.Under13Fixture = Data.League.Teams[0].Schedule.Where(g => g.TipOff > DateTime.Now).OrderBy(g => g.TipOff).ToList()[0];
            ViewBag.Under13Result = Data.League.Teams[0].Results.Where(g => g.TipOff < DateTime.Now).OrderByDescending(g => g.TipOff).ToList()[0];

            return View(Data.News);
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
