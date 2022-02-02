﻿using System;
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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }


        private void btIngr_Click(object sender, RoutedEventArgs e)
        {
            Ingredient ingr = new Ingredient();
            ingr.ShowDialog();
        }

        private void btPizza_Click(object sender, RoutedEventArgs e)
        {
            pizzas pizza = new pizzas();
            pizza.ShowDialog();
        }

        private void btOrder_Click(object sender, RoutedEventArgs e)
        {

            restaurant order = new restaurant();
            order.ShowDialog();
        }
    }
}
