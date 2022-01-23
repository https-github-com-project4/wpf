using Pizza_Stonks.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace Pizza_Stonks
{
    /// <summary>
    /// Interaction logic for restaurant.xaml
    /// </summary>
    public partial class restaurant : Window, INotifyPropertyChanged
    {
     private DB DB = new DB();

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion


       


        private ObservableCollection<Order> order_id;

        public ObservableCollection<Order> Order_id
        {
            get { return order_id; }
            set { order_id = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Order> pizza_id;

        public ObservableCollection<Order> Pizza_id
        {
            get { return pizza_id; }
            set { pizza_id = value; }
        }

        private string order;

        public string Order
        {
            get { return order; }
            set { order = value; OnPropertyChanged(); }
        }
        public restaurant()
        {
            InitializeComponent();
            PopulateFormaten();
            DataContext = this;

        }

        private void PopulateFormaten()
        {
            List<Order> dbOrderList = DB.GetOrder();
            if (dbOrderList == null)
            {
                MessageBox.Show("Fout bij ophalen formaten, waarschuw service desk");
                return;
            }

            foreach (Order formaat in dbOrderList)
            {
                Order_id.Add(formaat);
            }
        }
    }
}
