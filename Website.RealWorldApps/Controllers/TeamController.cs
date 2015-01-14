using System.Web.Mvc;
using System.Collections.Generic;
using Website.RealWorldApps.Models;
using System.Linq;

namespace Website.RealWorldApps.Controllers
{
    public class TeamController : Controller
    {
        private List<Player> DataPlayers { get; set;}
        private List<Coach> DataCoaches { get; set; }

        public ActionResult Players()
        {
            var data = new Data();
            data.AddPlayers();
            DataPlayers = data.Players;
            DataPlayers = DataPlayers.OrderBy(p => p.JerseyNumber).ToList();
            return View(DataPlayers);
        }

        public ActionResult Coaches()
        {
            
            return View(DataCoaches);
        }

        public ActionResult Team()
        {
            var data = new Data();
            data.AddCoaches();
            DataCoaches = data.Coaches;
            return View();
        }

    }
}
