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
    /// Interaction logic for pizzas.xaml
    /// </summary>
    public partial class pizzas : Window, INotifyPropertyChanged
    {
        private DB DB = new DB();

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region properties
        private ObservableCollection<Pizzas> pizza = new ObservableCollection<Pizzas>();

        public ObservableCollection<Pizzas> Pizza
        {
            get { return pizza; }
            set
            {
                pizza = value; OnPropertyChanged();
            }
        }

        private Pizzas selectedPizza;

        public Pizzas SelectedPizza
        {
            get { return selectedPizza; }
            set
            {
                selectedPizza = value;
                if (PropertyChanged != null)

                    tbSelectedPizza.Text = SelectedPizza.Name;

                PropertyChanged(this, new PropertyChangedEventArgs("selectedPizza"));
                OnPropertyChanged();
            }
        }




        #endregion
        public pizzas()
        {
            InitializeComponent();
            DataContext = this;
            PopulatePizzas();
            this.DataContext = this;

        }





        #region Populate
        private void PopulatePizzas()
        {
            List<Pizzas> dbPizzas = DB.Getpizzas();

            if (dbPizzas == null)
            {
                MessageBox.Show("Fout bij ophalen Orders, waarschuw service desk");
                return;
            }
            Pizza.Clear();
            foreach (Pizzas pizza in dbPizzas)
            {
                Pizza.Add(pizza);
            }

        }


        //private void Loadproperies()
        //{
        //    land = sConn.GetLanden();
        //    People = sConn.GetAllPerson();


        //    //   getVakantieland = sConn.GetAllLanden();

        //}
        #endregion
        

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            Ingrededient add = new Ingrededient();
            add.ShowDialog();

        }


        private void deletePizza_Click(object sender, RoutedEventArgs e)
        {

            int Pizza = (int)SelectedPizza.Id;

            if (DB.DeletePizza(Pizza.ToString()))
            {

                MessageBox.Show($"pizza {Pizza} verwijderd");
            }
            else
            {
                MessageBox.Show($"Verwijderen van {Pizza} mislukt. Er is een bestelling aan gekoppeld. dus het verwijderen van {SelectedPizza.Name} kan niet.");
            }
            PopulatePizzas();


        }

        private void btAddPizza_Click(object sender, RoutedEventArgs e)
        {
            AddPizza add = new AddPizza();
            add.ShowDialog();
        }

        private void btUpdatePizza_Click(object sender, RoutedEventArgs e)
        {
            UpdatePizza add = new UpdatePizza(SelectedPizza.Id, SelectedPizza.Name, selectedPizza.Price);
            add.ShowDialog();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lvpizza.ItemsSource = DB.Getpizzas();
        }

        private void btAddIngr_Click(object sender, RoutedEventArgs e)
        {
            IngredientPizza add = new IngredientPizza(SelectedPizza);
            
            add.ShowDialog();
        }

        //private void lvpizza_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    tbSelectedPizza.Text = SelectedPizza.Name;
        //}

        //private void lvIngredients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    selectedIngr.Text = SelectedIngredient.Name;
        //}
    }
}
