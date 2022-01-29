
using Pizza_Stonks.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Pizza_Stonks
{
    /// <summary>
    /// Interaction logic for AddIngrededient.xaml
    /// </summary>
    public partial class AddIngrededient : Window
    {
        public AddIngrededient()
        {
            InitializeComponent();
           
        }

        private const string MessageBoxText = "Er is iets misgegaan!, Ga naar de helpdesk:(";
        private DB DB = new DB();

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            if (DB.Insertingredient(tbIngredient.Text, tbPrice.Text))
            {
                MessageBox.Show($"U hebt een kutje toegevoegd aan de lijst!");
                this.Hide();
                pizzas subWindow = new pizzas();
                subWindow.Show();
            }
            else
            {
                MessageBox.Show(MessageBoxText);
            }



        }

    }
}
