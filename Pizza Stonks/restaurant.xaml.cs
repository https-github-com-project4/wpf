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
<<<<<<< HEAD
            set
            {
                orders = value; OnPropertyChanged();

=======
            set { orders = value; OnPropertyChanged(); 
            
>>>>>>> 0ce935b64d0ecb86744f9ed9a30cd31b7a6aa701
            }
        }

        private OrderGegevens selectedOrder;

        public OrderGegevens SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                selectedOrder = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Order_Pizza> orderpizzza = new ObservableCollection<Order_Pizza>();

        public ObservableCollection<Order_Pizza> Orderpizzza
        {
            get { return orderpizzza; }
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
            set
            {
                orderpizza = value;
                OnPropertyChanged();

            }


        }

        private ObservableCollection<Order_Pizza> orderpizzza = new ObservableCollection<Order_Pizza>();

        public ObservableCollection<Order_Pizza> Orderpizzza
        {
            get { return orderpizzza; }
            set { orderpizzza = value; }
        }

        private Order_Pizza orderpizza;

        public Order_Pizza Orderpizza
        {
            get { return orderpizza; }
            set { orderpizza = value; }
        }


        public restaurant()
        {
            InitializeComponent();
            PopulateOrder();
<<<<<<< HEAD

=======
        
>>>>>>> 0ce935b64d0ecb86744f9ed9a30cd31b7a6aa701
            DataContext = this;
        }
        //private void PopulateBestelling()
        //{
        //    List<OrderGegevens> dbOrderGegevens = DB.GetOrderGegevens();

        //    if (dbOrderGegevens == null)
        //    {
        //        MessageBox.Show("Fout bij ophalen bestelling, waarschuw service desk");
        //        return;
        //    }

        //    foreach (OrderGegevens pizza in dbOrderGegevens)
        //    {
        //        Pizza.Add(pizza);
        //    }
        //}
        private void PopulateOrder()
        {
            //List<OrderGegevens> dbOrderGegevens = DB.GetOrderGegevens();
            List<OrderGegevens> dbOrderList = DB.GetOrderGegevens();
            if (dbOrderList == null)
            {
                MessageBox.Show("Fout bij ophalen Orders, waarschuw service desk");
                return;
            }

            foreach (OrderGegevens formaat in dbOrderList)
            {
                Orders.Add(formaat);
<<<<<<< HEAD

            }

=======
                 
            }
               
>>>>>>> 0ce935b64d0ecb86744f9ed9a30cd31b7a6aa701
        }


        private void PopulateOrderById()
        {
            //List<OrderGegevens> dbOrderGegevens = DB.GetOrderGegevens();
<<<<<<< HEAD

=======
       
>>>>>>> 0ce935b64d0ecb86744f9ed9a30cd31b7a6aa701
            List<Order_Pizza> dbOrderList = DB.GetpizzasByOrderId(SelectedOrder.Id);
            if (dbOrderList == null)
            {
                MessageBox.Show("Fout bij ophalen pizzas, waarschuw service desk");
                return;
            }
<<<<<<< HEAD
            Orderpizzza.Clear();
            foreach (Order_Pizza formaat in dbOrderList)
            {

=======

            foreach (Order_Pizza formaat in dbOrderList)
            {
>>>>>>> 0ce935b64d0ecb86744f9ed9a30cd31b7a6aa701
                Orderpizzza.Add(formaat);
            }

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateOrderById();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             PopulateOrderById();
        }
    }
}
