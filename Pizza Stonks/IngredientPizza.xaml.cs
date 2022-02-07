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
    /// Interaction logic for IngredientPizza.xaml
    /// </summary>
    public partial class IngredientPizza : Window, INotifyPropertyChanged
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
        private Pizzas pizzas;

        public Pizzas Pizzas
        {
            get { return pizzas; }
            set
            {
                pizzas = value;
                OnPropertyChanged();
                
            }
        }
        private ObservableCollection<Ingredients> ingredients = new ObservableCollection<Ingredients>();

        public ObservableCollection<Ingredients> Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; OnPropertyChanged(); }
        }
        private ObservableCollection<Ingredients> ingredientsInPizzas = new ObservableCollection<Ingredients>();

        public ObservableCollection<Ingredients> IngredientsInPizzas
        {
            get { return ingredientsInPizzas; }
            set { ingredientsInPizzas = value; OnPropertyChanged(); }
        }
        private Ingredients selectedIngredient;

        public Ingredients SelectedIngredient
        {
            get { return selectedIngredient; }
            set
            {
                selectedIngredient = value;
                if (SelectedIngredient != null)
                {
                    //selectedIngr.Text = $"Naam: {SelectedIngredient.Name} Prijs: €{SelectedIngredient.Price},00";

                }

                OnPropertyChanged();
            }
        }


  
        #endregion

        public IngredientPizza(Pizzas pizzas)
        {
            InitializeComponent(); 
            this.Pizzas = pizzas;
            PopulateIngredients();
            //PopulateIngredientsOnPizza();
            DataContext = this;
        

        }
     

        private void PopulateIngredients()
        {
            List<Ingredients> dbIngredientsInPizza = DB.GetIngredientsInPizza(pizzas.Id);
            List<Ingredients> dbIngredients = DB.GetIngredients();

            if (dbIngredients == null)
            {
                MessageBox.Show("Fout bij ophalen Orders, waarschuw service desk");
                return;
            }
            Ingredients.Clear();
            foreach (Ingredients ingredredient in dbIngredients)
            {
                
                Ingredients.Add(ingredredient);
            }
            IngredientsInPizzas.Clear();
            foreach (Ingredients ingredredient in dbIngredientsInPizza)
            {

                IngredientsInPizzas.Add(ingredredient);
                
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedIngredient != null)
            {
                DB.AddIngr_Pizza(Pizzas.Id, SelectedIngredient.Id);
                MessageBox.Show($"{selectedIngredient.Name} toegevoed aan {Pizzas.Name}");
            }
            else
            {
                MessageBox.Show("geen item geselecteerd");
            }
            PopulateIngredients();
        }
        


    }
}