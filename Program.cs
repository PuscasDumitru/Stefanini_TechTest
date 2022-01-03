using System;

namespace TechTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Cafe cafe = new Cafe(numberOfCooks: 3, maxDishesPerCook: 5, addPercentage: 0.2);
            cafe.Work();
        }
    }
}
