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
    /// Interaction logic for UpdateIngredient.xaml
    /// </summary>
    public partial class UpdateIngredient : Window
    {
        private DB DB = new DB();
 
        public UpdateIngredient(ulong id, string ingredient, int price)
        {
            InitializeComponent();
            tbIngredient.Text = ingredient;
            tbPrice.Text = price.ToString();
            tbID.Text = id.ToString();
           
        }


        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            if (DB.UpdateIngredients(tbID.Text, tbIngredient.Text, tbPrice.Text))
            {
                MessageBox.Show($"ingredient  aangepast");
            }
            else
            {
                MessageBox.Show($"Aanpassen van  mislukt");
            }

            this.Close();

        }



        //        private void btAdd_Click(object sender, ulong id, string ingredient, int price, RoutedEventArgs e)
        //        {
        //       if (DB.UpdateIngredients((id, ingredient, price)))
        //            {
        //                MessageBox.Show($"ingredient {id} aangepast");
        //            }
        //            else
        //            {
        //                MessageBox.Show($"Aanpassen van {id} mislukt");
        //            }
        //this.Close();
        //        }
    }
}
