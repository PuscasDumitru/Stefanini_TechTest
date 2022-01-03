using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTest
{
    internal class Dish
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int CookingTime { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public Dish(string name, string description, List<Ingredient> ingredients, int cookingTime, double addPercentage)
        {
            this.Name = name;
            this.Description = description;
            this.Ingredients = ingredients;
            this.CookingTime = cookingTime;
            this.Price = ingredients.Sum(x => x.Price) * addPercentage;
        }
    }
}
