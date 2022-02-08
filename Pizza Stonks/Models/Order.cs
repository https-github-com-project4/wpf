using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace Pizza_Stonks.Models
{
   public class Order : OrderGegevens
    {
        private ulong pizza;

        public ulong Pizza
        {
            get { return pizza; }
            set { pizza = value; }
        }

        private ulong orders;

        public ulong Orders
        {
            get { return orders; }
            set { orders = value; }
        }
        public int Size { get; set; }
    }
}
