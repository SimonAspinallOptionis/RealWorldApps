using System.Linq;
using System.Web.Mvc;

namespace Website.RealWorldApps.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Results()
        {
            var data = new Data();
            data.AddGames();
            data.Games = data.Games.OrderByDescending(g => g.TipOff).ToList();
            return View(data.Games);
        }

        public ActionResult GameDetails(int id)
        {
            var data = new Data();
            data.AddGames();
            return View(data.Games[id]);
        }

        public ActionResult Schedule()
        {
            var data = new Data();
            data.AddSchedule();
            return View(data.Schedule);
        }

    }
}
