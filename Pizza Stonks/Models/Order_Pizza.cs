using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Stonks.Models
{
   public class Order_Pizza
    {
        //Ordergegevens
        public ulong Id_Order { get; set; }
        public string Name { get; set; }
        //Order
        public int Size { get; set; }
        //pizzagegevens
        public int Id_PizzaGegevens { get; set; }
        public string PizzaName { get; set; }
        public double Price_Gegevens { get; set; }
        public int Qty { get; set; }
        //pizza
        public ulong Id_Pizza { get; set; }
        public string Name_Pizza { get; set; }
        public double Price__Pizza { get; set; }
    }
}
