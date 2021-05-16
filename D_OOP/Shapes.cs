using System;

namespace D_OOP
{
    public abstract class Shape // нельзя создать экземпляр абстрактного класса или интерфейса
    {
        public Shape()
        {
            Console.WriteLine("Shape Created");
        }
        // Мы можем создавать виртуальные методы внутри абстрактного класса
        public abstract void Draw(); // Абстрактные методы не имеют реализацию. Наследники обязаны эти методы переопределить.
        public abstract double Area();
        public abstract double Perimeter();
    }

    public class Rectangle : Shape
    {
        private readonly double width;
        private readonly double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
            Console.WriteLine("Rectangle Created");
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing Rectangle");
        } 
        public override double Area()
        {
            return width * height;
        }
        public override double Perimeter()
        {
            return 2 * (width + height);
        }
    }

    public class Triangle : Shape
    {
        private readonly double ab;
        private readonly double bc;
        private readonly double ac;

        public Triangle(double ab, double bc, double ac)
        {
            this.ab = ab;
            this.bc = bc;
            this.ac = ac;
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing Triangle");
        } 
        public override double Area()
        {
            double s = (ab + bc + ac) / 2;
            return Math.Sqrt(s*(s-ab)*(s-bc)*(s-ac));
        }
        public override double Perimeter()
        {
            return ab + bc + ac;
        }
    }
}