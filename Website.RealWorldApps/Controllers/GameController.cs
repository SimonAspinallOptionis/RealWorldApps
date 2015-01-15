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
            Data.League.Teams[0].Results = Data.League.Teams[0].Results.OrderByDescending(g => g.TipOff).ToList();
            return View(Data.League.Teams[0].Results);
        }

        public ActionResult GameDetails(int id)
        {
            Data = HomeController.Data;
            return View(Data.League.Teams[0].Results[id]);
        }

        public ActionResult Schedule()
        {
            Data = HomeController.Data;
            Data.League.Teams[0].Schedule = Data.League.Teams[0].Schedule.Where(f => f.TipOff > DateTime.Now).ToList();
            return View(Data.League.Teams[0].Schedule);
        }

        [Authorize(Roles="Admin")]
        public ActionResult AddResult()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddFixture()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddResult(string league, string opponentName, string organisation, DateTime tipOff, string location, int cheshireScore, int opponentScore, bool wonGame, string boxScore, string gameStory, string shotChartUrl, string imgName)
        {
            Data = HomeController.Data;
            Data.Leagues.Where(r => r.Name == league).ToList()[0].Teams[0].Results.Add(new Models.Game { OpponentName = opponentName, Organisation = organisation, TipOff = tipOff, Location = location, CheshireScore = cheshireScore, OpponentScore = opponentScore, WonGame = wonGame, BoxScoreHtml = boxScore, GameStory = gameStory, ShotChartUrl = shotChartUrl, ImgName = imgName });
            return RedirectToAction("Results");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddFixture(string league, string opponentName, DateTime tipOff, string location, string teamLogoUrl)
        {
            Data = HomeController.Data;
            Data.Leagues.Where(f => f.Name == league).ToList()[0].Teams[0].Schedule.Add(new Models.Fixture { OpponentName = opponentName, TipOff = tipOff, Location = location, TeamLogoUrl = teamLogoUrl });
            return RedirectToAction("Schedule");
        }

    }
}
