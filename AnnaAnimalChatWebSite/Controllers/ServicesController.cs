using System;
using System.Web;
using System.Web.Mvc;
using AnnaAnimalChatWebSite.Model;

namespace AnnaAnimalChatWebSite.Controllers
{
    public class ServicesController : Controller
    {
        // GET: Services
        public ActionResult Index()
        {
            var model = new BookingModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Booking(BookingModel model)
        {
            //if (!ModelState.IsValid) return View("Index",model);

            ViewBag.Message = "已登記成功";
            return View("Index", model);
        }
    }
}