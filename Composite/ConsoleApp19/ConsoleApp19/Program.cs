using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    public interface IFileSystemComponent
    {
        string GetName();
        void ShowDetails();
    }

    public class File : IFileSystemComponent
    {
        private string _name;

        public File(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"File: {_name}");
        }
    }

    public class Directory : IFileSystemComponent
    {
        private string _name;
        private List<IFileSystemComponent> _components = new List<IFileSystemComponent>();

        public Directory(string name)
        {
            _name = name;
        }

        public void Add(IFileSystemComponent component)
        {
            _components.Add(component);
        }

        public void Remove(IFileSystemComponent component)
        {
            _components.Remove(component);
        }

        public string GetName()
        {
            return _name;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Directory: {_name}");
            foreach (var component in _components)
            {
                component.ShowDetails();
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Composite
            IFileSystemComponent file1 = new File("file1.txt");
            IFileSystemComponent file2 = new File("file2.txt");

            Directory directory1 = new Directory("Directory1");
            directory1.Add(file1);
            directory1.Add(file2);

            Directory directory2 = new Directory("Directory2");
            directory2.Add(new File("file3.txt"));

            Directory rootDirectory = new Directory("Root");
            rootDirectory.Add(directory1);
            rootDirectory.Add(directory2);

            rootDirectory.ShowDetails();

            Console.ReadLine();

            // Создать интерактивное взаимодействие и вывод структуры файловой системы в виде пути.
        }
    }
}
