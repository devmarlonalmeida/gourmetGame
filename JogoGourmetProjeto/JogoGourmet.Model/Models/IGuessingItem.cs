using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoGourmet.Model.Models
{
    public interface IGuessingItem
    {
        string GetName();
        string GetMainFeature();
        Dish GetDishWithMainFeature();
        Dish GetDishWithoutMainFeature();
        void AddDishWithMainFeature(Dish dish);
        void AddDishWithoutMainFeature(Dish dish);
    }
}
