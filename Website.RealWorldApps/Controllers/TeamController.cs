using System.Web.Mvc;
using System.Collections.Generic;
using Website.RealWorldApps.Models;
using System.Linq;

namespace Website.RealWorldApps.Controllers
{
    public class TeamController : Controller
    {
        private List<Player> DataPlayers { get; set; }
        private Data Data { get; set; }

        public ActionResult Players()
        {
            Data = HomeController.Data;
            DataPlayers = Data.League.Teams[0].Players;
            DataPlayers = DataPlayers.OrderBy(p => p.JerseyNumber).ToList();
            return View(DataPlayers);
        }

        public ActionResult Coaches()
        {
            return View(HomeController.Data);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddPlayer()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddCoach()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPlayer(string league, string playerName, int playerNumber, string position, string imgUrl)
        {
            Data = HomeController.Data;
            Data.Leagues.Where(l => l.Name == league).ToList()[0].Teams[0].Players.Add(new Player { Name = playerName, JerseyNumber = playerNumber, Position = position, ImgName = imgUrl });
            return RedirectToAction("Players");
        }

        [HttpPost]
        public ActionResult AddCoach(string league, string coachName, string position, string imgUrl)
        {
            Data = HomeController.Data;
            Data.Leagues.Where(l => l.Name == league).ToList()[0].Teams[0].Coaches.Add(new Coach { Name = coachName, Position = position, ImgName = imgUrl });
            return RedirectToAction("Coaches");
        }
    }
}
