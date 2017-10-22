using System.Web.Mvc;

namespace AnnaAnimalChatWebSite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return Redirect("index.html");
        }
    }
}