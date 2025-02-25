using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    // Абстрактные продукты
    // AbstractProduct
    public interface IButton
    {
        void Render();
    }

    public interface ITextField
    {
        void Render();
    }

    // Конкретные продукты
    // ConcreteProduct
    public class ClassicButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Отображение классической кнопки");
        }
    }

    public class ClassicTextField : ITextField
    {
        public void Render()
        {
            Console.WriteLine("Отображение классического текстового поля");
        }
    }

    public class ModernButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Отображение современной кнопки");
        }
    }

    public class ModernTextField : ITextField
    {
        public void Render()
        {
            Console.WriteLine("Отображение современного текстового поля");
        }
    }

    // Абстрактная фабрика
    public interface IUIFactory
    {
        IButton CreateButton();
        ITextField CreateTextField();
    }

    // Конкретная фабрика для классической темы
    public class ClassicFactory : IUIFactory
    {
        public IButton CreateButton()
        {
            return new ClassicButton();
        }

        public ITextField CreateTextField() { return new ClassicTextField();}
    }

    // Конкретная фабрика для современной темы
    public class ModernFactory : IUIFactory
    {
        public IButton CreateButton() { return new ModernButton(); }
        public ITextField CreateTextField() { return new ModernTextField(); }
    }

    public class Client
    {
        private IButton _button;
        private ITextField _textField;

        public Client(IUIFactory factory)
        {
            _button = factory.CreateButton();
            _textField = factory.CreateTextField();
        }

        public void RenderUI()
        {
            _button.Render();
            _textField.Render();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выбор темы (1 - Классическая тема, 2 - Современная): ");
            var choice = Console.ReadLine();

            IUIFactory factory;

            if (choice == "1")
            {
                factory = new ClassicFactory();
            }

            else
            {
                factory = new ModernFactory();
            }

            var client = new Client(factory);
            client.RenderUI();

            Console.ReadLine();
        }
    }
}
