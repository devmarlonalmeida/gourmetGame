using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoGourmet.Model.Models
{
    public class Dish : IGuessingItem
    {
        private string Name { get; }
        private string MainFeature { get; }

        private Dish DishWithoutFeature { get; set; }
        private Dish DishWithFeature{ get; set; } 

        public Dish(string name, string mainFeature)
        {
            if (name == null || mainFeature == null)
                throw new ArgumentNullException();

            Name = name;
            MainFeature = mainFeature;       
        }

        public string GetName()
        {
            return Name;
        }

        public string GetMainFeature()
        {
            return MainFeature;
        }

        public Dish GetDishWithMainFeature()
        {
            return DishWithFeature;
        }

        public Dish GetDishWithoutMainFeature()
        {
            return DishWithoutFeature;
        }

        public void AddDishWithMainFeature(Dish dish)
        {
            DishWithFeature = dish;
        }

        public void AddDishWithoutMainFeature(Dish dish)
        {
            DishWithoutFeature = dish;
        }
    }
}
