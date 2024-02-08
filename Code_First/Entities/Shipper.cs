using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First.Entities
{
    public class Shipper
    {
        public int ShipperId { get; set; }
        public string CompanyName { get; set; }
        public string? PhoneNumber { get; set; }

        //Mapping
        public virtual List<Order> Orders { get; set; }
    }
}
