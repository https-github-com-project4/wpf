using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace Pizza_Stonks.Models
{
   public class Formaat: INotifyPropertyChanged
    {
#region

        // Declare the event
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private ulong formaatId;

        public ulong FormaatId
        {
            get { return formaatId; }
            set { formaatId = value; OnPropertyChanged(); }
        }
        private double factor;

        public double Factor
        {
            get { return factor; }
            set { factor = value; OnPropertyChanged(); }
        }
        private string grootte;

        public string Grootte
        {
            get { return grootte; }
            set { grootte = value; OnPropertyChanged(); }
        }



        #endregion
    }
}
