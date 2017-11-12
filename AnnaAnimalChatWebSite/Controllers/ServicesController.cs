using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using AnnaAnimalChatWebSite.Model;
using AnnaAnimalChatWebSite.Services;

namespace AnnaAnimalChatWebSite.Controllers
{
    public class ServicesController : Controller
    {
        private BookingServices _bookingService;

        public ServicesController()
        {
            _bookingService = new BookingServices();
        }
        // GET: Services
        public ActionResult Index()
        {
            var model = new BookingModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError(ExceptionType = typeof(HttpAntiForgeryException), View = "CSRF_Error")]
        public ActionResult Booking(BookingModel model)
        {
            if (model.PetAmount < 2)
            {
                ModelState["AnimalNameB"].Errors.Clear();
                ModelState["PicB"].Errors.Clear();
            }

            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            model = _bookingService.Register(model);
            
            return View("Index", model);
        }
    }

    public enum BookingResult
    {
        Success,
        NotProcess
    }
}