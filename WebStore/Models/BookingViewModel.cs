using HardwareStoreCommon.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStore.Models
{
    public class BookingViewModel
    {
        public int CustomerId { get; set; }
        public Tool Tool { get; set; }
        [DataType(DataType.Date)]
        public DateTime PickUpDate { get; set; }
        public int RentDays { get; set; }
        public int TotalPrice { get { return RentDays * Tool.PricePerDay; } }
    }
}