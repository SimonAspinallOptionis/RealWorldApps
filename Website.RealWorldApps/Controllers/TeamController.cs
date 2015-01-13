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

        Data data = new Data();

        public ActionResult Players()
        {
            DataPlayers = data.Players;
            return View(DataPlayers.OrderBy(p=>p.JerseyNumber));
        }

        public ActionResult Coaches()
        {
            DataCoaches = data.Coaches;
            return View(DataCoaches);
        }

    }
}
