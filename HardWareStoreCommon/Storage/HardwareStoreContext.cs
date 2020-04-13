using HardwareStoreCommon.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStoreCommon.Storage
{
    public class HardwareStoreContext : DbContext
    {
        public HardwareStoreContext() : base("name=HardwareStoreConnectionString")
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Tool> Tools { get; set; }

        public void AddNewCustomer(Customer newCustomer)
        {
            Customers.Add(newCustomer);
            SaveChanges();
        }

        public List<Tool> GetAvailableTools()
        {
            return Tools.Include(t => t.Bookings)
                .Where(t => t.Bookings.All(b => b.Status == Booking.BookingStatus.Returned))
                .ToList();
        }
    }
}
