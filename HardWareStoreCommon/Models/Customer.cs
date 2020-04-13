using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HardwareStoreCommon.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Indtast venligst et navn")]
        public string Name { get; set; }
        public string Address { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Indtast venligst et bruger navn")]
        [Index(IsUnique = true, Order = 1)]
        [StringLength(200)]
        public string UserName { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
