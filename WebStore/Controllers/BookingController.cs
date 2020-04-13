using HardwareStoreCommon.Models;
using HardwareStoreCommon.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class BookingController : Controller
    {
        private readonly HardwareStoreContext dbContext = new HardwareStoreContext();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Book(HomeViewModel model)
        {
            var booking = new BookingViewModel
            {
                CustomerId = model.Customer.Id,
                Tool = dbContext.Tools.Find(model.ToolId),
                PickUpDate = DateTime.Now.Date,
                RentDays = 1
            };
            
            return View("BookingPeriod", booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Confirm(BookingViewModel model)
        {
            model.Tool = dbContext.Tools.Find(model.Tool.Id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmReservation(BookingViewModel model)
        {
            var booking =
                new Booking
                {
                    Customer = dbContext.Customers.Find(model.CustomerId),
                    Tool = dbContext.Tools.Find(model.Tool.Id),
                    PickUpDate = model.PickUpDate,
                    RentPeriod = model.RentDays,
                    Status = Booking.BookingStatus.Reserved
                };
            dbContext.Bookings.Add(booking);
            dbContext.SaveChanges();
            return View("Confirmation", booking);
        }
    }
}