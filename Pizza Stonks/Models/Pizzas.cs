using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Pizza_Stonks.Models
{
   public class Pizzas
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public double Price  { get; set; }

        private ObservableCollection<Ingredients>  ingredients;

        public ObservableCollection<Ingredients> Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; }
        }

        private Ingredients ingredientpizza;

        public Ingredients Ingredientpizza
        {
            get { return ingredientpizza; }
            set { ingredientpizza = value; }
        }

        //private List<Ingredients> ingredient() {

        //}
    }

}
