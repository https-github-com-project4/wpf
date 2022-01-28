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
       
        
        private ObservableCollection<Pizzas> pizza = new ObservableCollection<Pizzas>();

        public ObservableCollection<Pizzas> Pizza
        {
            get { return pizza; }
            set { pizza = value; OnPropertyChanged();}
        }

        private ObservableCollection<Pizzas> selectedPizza;

        public ObservableCollection<Pizzas> SelectedPizza
        {
            get { return selectedPizza; }
            set { selectedPizza = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Ingredients> ingredients = new ObservableCollection<Ingredients>();

        public ObservableCollection<Ingredients> Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; OnPropertyChanged(); }
        }

        private Ingredients selectedIngredient;

        public Ingredients SelectedIngredient
        {
            get { return selectedIngredient; }
            set { selectedIngredient = value;
                OnPropertyChanged();
            }
        }

        public pizzas()
        {
            InitializeComponent();
            DataContext = this;
            PopulatePizzas();
            PopulateIngredients();
          


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

            foreach (Pizzas pizza in dbPizzas)
            {
                Pizza.Add(pizza);
            }
        }

        private void PopulateIngredients()
        {
            List<Ingredients> dbIngredients = DB.GetIngredients();

            if (dbIngredients == null)
            {
                MessageBox.Show("Fout bij ophalen Orders, waarschuw service desk");
                return;
            }
            Ingredients.Clear();
            foreach (Ingredients pizza in dbIngredients)
            {
                
                 Ingredients.Add(pizza);
            }
        }
        //private void Loadproperies()
        //{
        //    land = sConn.GetLanden();
        //    People = sConn.GetAllPerson();
            

        //    //   getVakantieland = sConn.GetAllLanden();

        //}
        #endregion
        #region Delete 
        private void btDelete_Click(object sender, RoutedEventArgs e)
        {

            int iIngeredient = (int)SelectedIngredient.Id;

            if (DB.DeleteIngredient(iIngeredient.ToString()))
            {
                
                MessageBox.Show($"kutje {iIngeredient} verwijderd");
            }
            else
            {
                MessageBox.Show($"Verwijderen van {iIngeredient} mislukt");
            }
            PopulateIngredients();


        }
        #endregion

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            AddIngrededient add = new AddIngrededient();
            add.ShowDialog();
           
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (DB.UpdateIngredients((SelectedIngredient.Id, SelectedIngredient.Name, SelectedIngredient.Price)))
            {
                MessageBox.Show($"ingredient {SelectedIngredient.Id} aangepast");
            }
            else
            {
                MessageBox.Show($"Aanpassen van {SelectedIngredient.Id} mislukt");
            }
            this.Close();
        }

        private void tbIngredient_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void btchange_Click(object sender, RoutedEventArgs e)
        {
            lvOrder.ItemsSource = SelectedIngredient.Name;
        }
    }
}
