using System.Linq;
using System.Web.Mvc;

namespace Website.RealWorldApps.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index()
        {
            var data = new Data();
            data.Games = data.Games.OrderByDescending(g => g.TipOff).ToList();
            return View(data.Games);
        }

        public ActionResult GameDetails(int id)
        {
            var data = new Data();
            return View(data.Games[id]);
        }

    }
}
