using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HardwareStoreCommon.Models
{
    public class Booking
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime PickUpDate { get; set; }
        public int RentPeriod { get; set; }
        public BookingStatus Status { get; set; }
        public Tool Tool { get; set; }
        public Customer Customer { get; set; }

        public enum BookingStatus
        {
            Reserved,
            HandedOut,
            Returned
        }
    }
}
