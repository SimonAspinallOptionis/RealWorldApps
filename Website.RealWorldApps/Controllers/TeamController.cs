using System.Web.Mvc;
using System.Collections.Generic;
using Website.RealWorldApps.Models;
using System.Linq;

namespace Website.RealWorldApps.Controllers
{
    public class TeamController : Controller
    {
        private List<Player> DataPlayers { get; set;}
        private Data Data { get; set; }

        public ActionResult Players()
        {
            Data = HomeController.Data;
            DataPlayers = Data.League.Team.Players;
            DataPlayers = DataPlayers.OrderBy(p => p.JerseyNumber).ToList();
            return View(DataPlayers);
        }

        public ActionResult Coaches()
        {
            Data = HomeController.Data;
            return View(Data.League.Team.Coaches);
        }
    }
}
