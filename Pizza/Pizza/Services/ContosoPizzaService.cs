using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoPizza.Models;

namespace ContosoPizza.Services
{
    public class PizzaService
    {
        static List<ContosoPizza.Models.Pizza> Pizzas { get; }
        static int nextId = 3;
        static PizzaService()
        {
            Pizzas = new List<ContosoPizza.Models.Pizza>
        {
            new ContosoPizza.Models.Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
            new ContosoPizza.Models.Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true }
        };
        }

        public static List<ContosoPizza.Models.Pizza> GetAll() => Pizzas;

        public static ContosoPizza.Models.Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

        public static void Add(ContosoPizza.Models.Pizza pizza)
        {
            pizza.Id = nextId++;
            Pizzas.Add(pizza);
        }

        public static void Delete(int id)
        {
            var pizza = Get(id);
            if (pizza is null)
                return;

            Pizzas.Remove(pizza);
        }

        public static void Update(ContosoPizza.Models.Pizza pizza)
        {
            var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
            if (index == -1)
                return;

            Pizzas[index] = pizza;
        }
    }
}
