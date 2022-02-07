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
    /// Interaction logic for AddPizza.xaml
    /// </summary>
    public partial class AddPizza : Window
    {
        private DB DB = new DB();
        public AddPizza()
        {
            InitializeComponent();
            
        }
        private const string MessageBoxText = "Er is iets misgegaan!, Ga naar de helpdesk:(";
        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            if (DB.InsertPizza( tbPizza.Text, tbPrice.Text))
            {
                MessageBox.Show($"U hebt een pizza toegevoegd aan de lijst!");
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
