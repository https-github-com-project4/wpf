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
    /// Interaction logic for UpdatePizza.xaml
    /// </summary>
    public partial class UpdatePizza : Window
    {
        private DB DB = new DB();

        public UpdatePizza(ulong id, string name, double price)
        {
            InitializeComponent();

            tbPizza.Text = name;
            tbPrice.Text = price.ToString();
            tbID.Text = id.ToString();
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (DB.UpdatePizza(tbID.Text, tbPizza.Text, tbPrice.Text))
            {
                MessageBox.Show($"pizza  aangepast");
            }
            else
            {
                MessageBox.Show($"Aanpassen van  mislukt");
            }

            this.Close();
        }
    }
}
