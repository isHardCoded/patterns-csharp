using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{

    public interface IDrawingAPI
    {
        void DrawCircle(double x, double y, double radius);
        void DrawRectangle(double x, double y, double width, double height);
        void DrawTriangle(double x1, double y1, double x2, double y2, double x3, double y3);
    }

    public class VectorDrawingAPI : IDrawingAPI
    {
        public void DrawCircle(double x, double y, double radius)
        {
            Console.WriteLine($"Vector: Circle at ({x}, {y}) with radius {radius}");
        }

        public void DrawRectangle(double x, double y, double width, double height)
        {
            Console.WriteLine($"Vector: Rectangle at ({x}, {y}) with width {width} and height {height}");
        }

        public void DrawTriangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            Console.WriteLine($"Vector: Triangle with vertices at ({x1}, {y1}), ({x2}, {y2}), ({x3}, {y3})");
        }
    }

    public class RasterDrawingAPI : IDrawingAPI
    {
        public void DrawCircle(double x, double y, double radius)
        {
            Console.WriteLine($"Raster: Circle at ({x}, {y}) with radius {radius}");
        }

        public void DrawRectangle(double x, double y, double width, double height)
        {
            Console.WriteLine($"Raster: Rectangle at ({x}, {y}) with width {width} and height {height}");
        }

        public void DrawTriangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            Console.WriteLine($"Raster: Triangle with vertices at ({x1}, {y1}), ({x2}, {y2}), ({x3}, {y3})");
        }
    }

    public abstract class Shape
    {
        protected IDrawingAPI drawingAPI;

        protected Shape(IDrawingAPI drawingAPI)
        {
            this.drawingAPI = drawingAPI;
        }

        public abstract void Draw();
        public abstract void Resize(double percent);
    }

    public class Circle : Shape
    {
        private double x;
        private double y;
        private double radius;

        public Circle(double x, double y, double radius, IDrawingAPI drawingAPI) : base(drawingAPI)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

        public override void Draw()
        {
            drawingAPI.DrawCircle(x, y, radius);
        }

        public override void Resize(double percent)
        {
            radius *= percent;
        }
    }

    public class Rectangle : Shape {
        private double x;
        private double y;
        private double width;
        private double height;

        public Rectangle(double x, double y, double width, double height, IDrawingAPI drawingAPI) : base(drawingAPI)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public override void Draw()
        {
            drawingAPI.DrawRectangle(x, y, width, height);
        }

        public override void Resize(double percent)
        {
            width *= percent;
            height *= percent;
        }
    }

    public class Triangle : Shape
    {
        private double x1, y1;
        private double x2, y2;
        private double x3, y3;

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3, IDrawingAPI drawingAPI) : base(drawingAPI)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;
        }

        public override void Draw()
        {
            drawingAPI.DrawTriangle(x1, y1, x2, y2, x3, y3);
        }

        public override void Resize(double percent)
        {
            x1 *= percent;
            y1 *= percent;
            x2 *= percent;
            y2 *= percent;
            x3 *= percent;
            y3 *= percent;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Bridge
            Shape vectorCircle = new Circle(5, 10, 3, new VectorDrawingAPI());
            Shape rasterCircle = new Circle(20, 30, 5, new RasterDrawingAPI());

            Shape vectorRectangle = new Rectangle(3, 3, 100, 100, new VectorDrawingAPI());
            Shape rasterRectangle = new Rectangle(5, 2, 85, 85, new RasterDrawingAPI());

            Shape vectorTriangle = new Triangle(2, 2, 3, 3, 5, 5, new VectorDrawingAPI());
            Shape rasterTriangle = new Triangle(2, 3, 5, 6, 7, 8, new RasterDrawingAPI());

            vectorCircle.Draw();
            rasterCircle.Draw();
            vectorRectangle.Draw();
            rasterRectangle.Draw();
            vectorTriangle.Draw();
            rasterTriangle.Draw();

            vectorCircle.Resize(2);
            rasterCircle.Resize(0.5);
            vectorRectangle.Resize(2);
            rasterRectangle.Resize(0.5);
            vectorTriangle.Resize(2);
            rasterTriangle.Resize(0.5);

            vectorCircle.Draw();
            rasterCircle.Draw();
            vectorRectangle.Draw();
            rasterRectangle.Draw();
            vectorTriangle.Draw();
            rasterTriangle.Draw();

            Console.ReadLine();
        }
    }
}
