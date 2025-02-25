using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    public interface ICar
    {
        void Drive();
    }

    public interface IMotorcycle
    {
        void Ride();
    }

    public class SportsCar : ICar
    {
        public void Drive()
        {
            Console.WriteLine("Вождение спортивного автомобиля.");
        }
    }

    public class SportsMotorcycle : IMotorcycle 
    {
        public void Ride()
        {
            Console.WriteLine("Вождение спортивного мотоцикла");
        }
    }

    public interface IVehicleFactory
    {
        ICar CreateCar();
        IMotorcycle CreateMotorcycle();
    }

    public class SportsVehicleFactory : IVehicleFactory
    {
        public ICar CreateCar() { return new SportsCar(); }
        public IMotorcycle CreateMotorcycle() { return new SportsMotorcycle(); }
    }

    public class Client
    {
        private ICar _car;
        private IMotorcycle _motorcycle;

        public Client(IVehicleFactory factory)
        {
            _car = factory.CreateCar();
            _motorcycle = factory.CreateMotorcycle();
        }

        public void DriveVehicle()
        {
            _car.Drive();
            _motorcycle.Ride();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IVehicleFactory sportsFactory = new SportsVehicleFactory();
            Client sportsClient = new Client(sportsFactory);
            sportsClient.DriveVehicle();

            Console.ReadLine();
        }
    }
}
