using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTest
{
    internal class Cook
    {
        public string Name { get; set; }
        public List<Dish> Orders { get; set; } = new List<Dish>();
    }
}
