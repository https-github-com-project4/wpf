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
    /// Interaction logic for Ingredient.xaml
    /// </summary>
    public partial class Ingredient : Window, INotifyPropertyChanged
    {
        private DB DB = new DB();

        public Ingredient()
        {
            InitializeComponent();
            DataContext = this;
            PopulateIngredients();
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
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
            set
            {
                selectedIngredient = value;
                if (SelectedIngredient != null)
                {
                    selectedIngr.Text = $"Naam: {SelectedIngredient.Name} Prijs: €{SelectedIngredient.Price},00";
                }


                OnPropertyChanged();
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
        #region CUD 
        private void btDelete_Click(object sender, RoutedEventArgs e)
        {

            int iIngeredient = (int)SelectedIngredient.Id;

            if (DB.DeleteIngredient(iIngeredient.ToString()))
            {

                MessageBox.Show($"Ingrediënt {iIngeredient} verwijderd");
            }
            else
            {
                MessageBox.Show($"Verwijderen van {iIngeredient} mislukt");
            }
            PopulateIngredients();


        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            Ingrededient add = new Ingrededient();
            add.ShowDialog();

        }

        private void btUpdateIngredient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateIngredient updatepage = new UpdateIngredient(SelectedIngredient.Id, SelectedIngredient.Name, SelectedIngredient.Price);
                updatepage.ShowDialog();

            }
            catch (Exception)
            {
                MessageBox.Show("Selecteer eerst een ingredient");
                throw;
            }
            PopulateIngredients();


        }
        #endregion
    }
}
