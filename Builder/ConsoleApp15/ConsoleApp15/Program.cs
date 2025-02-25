using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    public class Pizza
    {
        public string Sauce { get; set; }
        public string Dough {  get; set; }
        public List<string> Toppings { get; set; } = new List<string>();

        public override string ToString()
        {
            return $"Пицца с {Dough} тесто, {Sauce} соус с начинкой: {string.Join(", ", Toppings)}";
        }
    }

    public interface IPizzaBuilder
    {
        void SetDough(string dough);
        void SetSauce(string sauce);
        void addTopping(string topping);
        Pizza Build();
    }

    public class PizzaBuilder : IPizzaBuilder
    {
        private Pizza _pizza = new Pizza();

        public void SetDough(string dough)
        {
            _pizza.Dough = dough;
        }

        public void SetSauce(string sauce)
        {
            _pizza.Sauce = sauce;
        }

        public void addTopping(string topping)
        {
            _pizza.Toppings.Add(topping);
        }

        public Pizza Build()
        {
            return _pizza;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Builder
            IPizzaBuilder pizzaBuilder = new PizzaBuilder();

            pizzaBuilder.SetSauce("Песто");
            pizzaBuilder.SetDough("Толстая корочка");
            pizzaBuilder.addTopping("Моцарелла");
            pizzaBuilder.addTopping("Cалями");
            pizzaBuilder.addTopping("Гауда");
            pizzaBuilder.addTopping("Руккола");

            Pizza pizza = pizzaBuilder.Build();
            Console.WriteLine(pizza);

            Console.ReadLine();
        }
    }
}
