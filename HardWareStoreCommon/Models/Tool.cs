using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareStoreCommon.Models
{
    public class Tool
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int Deposit { get; set; }
        public int PricePerDay { get; set; }
        public List<Booking> Bookings { get; set; }
        public String ImgSrc { get; set; }
    }
}
