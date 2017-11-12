using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnnaAnimalChatWebSite.Controllers;
using AnnaAnimalChatWebSite.Model;

namespace AnnaAnimalChatWebSite.Services
{
    public class BookingServices : IBookingService
    {
        public BookingModel Register(BookingModel model)
        {
            //Todo: 未實作
            model.Result = BookingResult.Success;
            return model;
        }
    }

    public interface IBookingService
    {
        BookingModel Register(BookingModel model);
    }
}