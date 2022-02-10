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

        private ObservableCollection<Pizzas> pizza = new ObservableCollection<Pizzas>();

        public ObservableCollection<Pizzas> Pizza
        {
            get { return pizza; }
            set
            {
                pizza = value; OnPropertyChanged();
            }
        }

        private ObservableCollection<OrderGegevens> orders = new ObservableCollection<OrderGegevens>();

        public ObservableCollection<OrderGegevens> Orders
        {
            get { return orders; }
            set
            {
                orders = value; OnPropertyChanged();
            }
        }

        private OrderGegevens selectedOrder;

        public OrderGegevens SelectedOrder
        {
            get { return selectedOrder; }
            set { selectedOrder = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Order_Pizza> orderpizzza = new ObservableCollection<Order_Pizza>();

        public ObservableCollection<Order_Pizza> Orderpizzza
        {
            get
            {
                return orderpizzza;
                
            }
            set
            {
                orderpizzza = value;
                OnPropertyChanged();
            }
        }

        private Order_Pizza orderpizza;

        public Order_Pizza Orderpizza
        {
            get { return orderpizza; }
            set { orderpizza = value;  }
        }


        public restaurant()
        {
            InitializeComponent();           
            DataContext = this;
            PopulateOrder();
        }
  
        private void PopulateOrder()
        {
            List<OrderGegevens> dbOrderList = DB.GetOrderGegevens();
            if (dbOrderList == null)
            {
                MessageBox.Show("Fout bij ophalen Orders, waarschuw service desk");
                return;
            }
            else
            {
                Orders.Clear();
            }
            
            foreach (OrderGegevens formaat in dbOrderList)
            {
                Orders.Add(formaat);

            }
           

        }


        private void PopulateOrderById()
        {
            List<Order_Pizza> dbOrderList = DB.GetpizzasByOrderId(SelectedOrder.Id);
            if (dbOrderList == null)
            {
                MessageBox.Show("Fout bij ophalen pizzas, waarschuw service desk");
                return;
            }            
                Orderpizzza.Clear();          
            
            foreach (Order_Pizza formaat in dbOrderList)
            {
                Orderpizzza.Add(formaat);
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateOrderById();
        }

        //status updaten

        private void btnVoorbereiden_Click(object sender, RoutedEventArgs e)
        {
            int status = 3;
            if (DB.UpdateStatus(SelectedOrder.Id, status))
            {
                MessageBox.Show($"Status aangepast");
            }
            else
            {
                MessageBox.Show($"Aanpassen van status mislukt");
            }
            this.Close();
            restaurant add = new restaurant();
            add.ShowDialog();
            
        }

        private void btnInOven_Click(object sender, RoutedEventArgs e)
        {
            int status = 4;
            if (selectedOrder == null)
            {
                MessageBox.Show("Selecteer een order A.U.B!");
            }
            else
            {
                if (DB.UpdateStatus(SelectedOrder.Id, status))
                {
                    MessageBox.Show($"Status aangepast");
                }
                else
                {
                    MessageBox.Show($"Aanpassen van status mislukt");
                }
                this.Close();
                restaurant add = new restaurant();
                add.ShowDialog();
            }

           
          

        }

        private void btnOnderweg_Click(object sender, RoutedEventArgs e)
        {
            int status = 5;
            if (DB.UpdateStatus(SelectedOrder.Id, status))
            {
                MessageBox.Show($"Status aangepast");
            }
            else
            {
                MessageBox.Show($"Aanpassen van status mislukt");
            }
            this.Close();
            restaurant add = new restaurant();
            add.ShowDialog();

        }

        private void btnBezorgd_Click(object sender, RoutedEventArgs e)
        {
            int status = 6;
            if (DB.UpdateStatus(SelectedOrder.Id, status))
            {
                MessageBox.Show($"Status aangepast");
            }
            else
            {
                MessageBox.Show($"Aanpassen van status mislukt");
            }

            this.Close();
            restaurant add = new restaurant();
            add.ShowDialog();
        }
    }
}
