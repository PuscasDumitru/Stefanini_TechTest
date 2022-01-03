using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTest
{
    internal class Cafe
    {
        Random rand;

        readonly int NUMBER_OF_COOKS;
        readonly int MAX_DISHES_PER_COOK;
        readonly double ADDITIONAL_PERCENTAGE;

        List<Cook> _cooks;
        List<Dish> _menu;

        public Cafe(int numberOfCooks, int maxDishesPerCook, double addPercentage)
        {
            rand = new Random();
            NUMBER_OF_COOKS = numberOfCooks;
            MAX_DISHES_PER_COOK = maxDishesPerCook;
            ADDITIONAL_PERCENTAGE = addPercentage;

            _menu = new List<Dish>
            {
                new Dish
                (
                    name: "Lasagne",
                    description: "Lasagne are a type of pasta, possibly one of the oldest types, made of very wide, flat sheets.",
                    ingredients: new List<Ingredient>
                    {
                        new Ingredient { Name = "Lamb", Price = rand.Next(20, 60)},
                        new Ingredient { Name = "White Sauce", Price = rand.Next(20, 60)},
                        new Ingredient { Name = "Pasta Sheet", Price = rand.Next(20, 60)},
                    },
                    cookingTime: rand.Next(10, 20),
                    addPercentage: ADDITIONAL_PERCENTAGE
                ),

                new Dish
                (
                    name: "Gyros",
                    description: "Greek dish made from meat cooked on a vertical rotisserie.",
                    ingredients: new List<Ingredient>
                    {
                        new Ingredient { Name = "Lamb", Price = rand.Next(20, 60)},
                        new Ingredient { Name = "Onion", Price = rand.Next(20, 60)},
                        new Ingredient { Name = "Tomato", Price = rand.Next(20, 60)},
                        new Ingredient { Name = "Garlic", Price = rand.Next(20, 60)},
                    },
                    cookingTime: rand.Next(10, 20),
                    addPercentage: ADDITIONAL_PERCENTAGE
                ),

                new Dish
                (
                    name: "Pizza",
                    description: "Pizza is a dish of Italian origin consisting of a usually round, flat base of leavened wheat-based dough topped with various ingredients",
                    ingredients: new List<Ingredient>
                    {
                        new Ingredient { Name = "Cheese", Price = rand.Next(20, 60)},
                        new Ingredient { Name = "Flour", Price = rand.Next(20, 60)},
                        new Ingredient { Name = "Yeast", Price = rand.Next(20, 60)},
                        new Ingredient { Name = "Pizza Dough", Price = rand.Next(20, 60)}
                    },
                    cookingTime: rand.Next(10, 20),
                    addPercentage: ADDITIONAL_PERCENTAGE
                ),
            };

            _cooks = new List<Cook>();
            for (int i = 0; i < NUMBER_OF_COOKS; i++)
            {
                _cooks.Add(new Cook { Name = RandomNames.FirstNames[rand.Next(0, RandomNames.FirstNames.Length)] + " " 
                    + RandomNames.LastNames[rand.Next(0, RandomNames.LastNames.Length)] });
            }
        
        }

        public void Work()
        {
            Console.WriteLine("The Menu of Cafe:\n");

            foreach (var dish in _menu)
            {
                Console.WriteLine(
                    $"Dish Name: {dish.Name}\n" +
                    $"Description: {dish.Description}\n" +
                    $"Contents: {dish.Ingredients.Select(x => x.Name).Aggregate((a, b) => a + ", " + b)}\n" +
                    $"Price: {dish.Price}\n"
                    );
            }

            Console.WriteLine("Input the name of the dish you want to order: ");

            while (true)
            {
                string dishName = Console.ReadLine().Trim().ToLower();

                if (_menu.Any(x => x.Name.Trim().ToLower() == dishName))
                {
                    if (_cooks.Any(x => x.Orders.Count < MAX_DISHES_PER_COOK))
                    {
                        Cook assignedCook = _cooks.First(x => x.Orders.Count == _cooks.Select(y => y.Orders.Count).Min());
                        assignedCook.Orders.Add(_menu.First(x => x.Name.Trim().ToLower() == dishName));
                        Console.WriteLine($"Order accepted, you have to wait: {assignedCook.Orders.Sum(x => x.CookingTime)} minutes");
                    }

                    else
                        Console.WriteLine("No cooks available");

                }

                else
                    Console.WriteLine("There is no such dish in the menu, try again!");
            }
        }
    }
}
