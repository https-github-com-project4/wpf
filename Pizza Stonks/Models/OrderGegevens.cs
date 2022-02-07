using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace Pizza_Stonks.Models
{
   public class OrderGegevens
    { 
        public ulong Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string address { get; set; }
        public string StatusName { get; set; }
        public int Qty { get; set; }

    }
}
