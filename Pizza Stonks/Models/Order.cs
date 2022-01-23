using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace Pizza_Stonks.Models
{
   public class Order: INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
        private int pizza_id;

        public int Pizza_id
        {
            get { return pizza_id; }
            set { pizza_id = value; }
        }

        private int order_id;

        public int Order_id
        {
            get { return order_id; }
            set { order_id = value; }
        }

    }
}
