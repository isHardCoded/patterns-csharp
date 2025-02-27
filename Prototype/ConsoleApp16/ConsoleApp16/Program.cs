using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
   public interface IPrototype<T>
    {
        T Clone();
    }

    public class Car : IPrototype<Car>
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public Car(string brand, string model, int year)
        {
            Brand = brand;
            Model = model;
            Year = year;
        }

        public Car Clone()
        {
            return new Car(Brand, Model, Year);
        }

        public override string ToString()
        {
            return $"Brand: {Brand}\nModel: {Model}\nYear: {Year}";
        }
    }

    public class CarRental
    {
        private Dictionary<string, IPrototype<Car>> availableCars = new Dictionary<string, IPrototype<Car>>();

        public void AddCar(string key, Car car) 
        {
            availableCars[key] = car;
        }

        public Car RentCar(string key)
        {
            if (availableCars.ContainsKey(key))
            {
                return availableCars[key].Clone();
            }

            return null;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Prototype
            CarRental carRental = new CarRental();

            carRental.AddCar("седан", new Car("Lotus", "Emira", 1999));
            carRental.AddCar("внедорожник", new Car("Jeep", "Cherokee", 1976));

            Car rentedCar1 = carRental.RentCar("седан");
            Car rentedCar2 = carRental.RentCar("внедорожник");

            Console.WriteLine($"Арендованный автомобиль 1: {rentedCar1}");
            Console.WriteLine($"Арендованный автомобиль 2: {rentedCar2}");

            rentedCar1.Year = 1989;

            Console.WriteLine($"Измененный арендованный автомобиль 1: {rentedCar1}");
            Console.WriteLine($"Оригинал автомобиля 1: {carRental.RentCar("седан")}");

            Console.ReadLine();
        }
    }
}
