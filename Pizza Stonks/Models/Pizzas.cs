using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Pizza_Stonks.Models
{
   public class Pizzas : Order
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public double Price  { get; set; }
    }

}
