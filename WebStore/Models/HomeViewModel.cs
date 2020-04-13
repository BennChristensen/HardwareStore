using HardwareStoreCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStore.Models
{
    public class HomeViewModel
    {
        public List<Tool> Tools { get; set; }
        public Customer Customer { get; set; }
        public int ToolId { get; set; }
    }
}