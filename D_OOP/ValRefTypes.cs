using System;

namespace D_OOP
{
    public struct PointVal // struct - структура. Все классы это ссылочные типы, а структура это value типы.
    {
        public int X;
        public int Y;

        public void LogValues()
        {
            Console.WriteLine($"X={X}; Y={Y}");
        }
    }

    public class PointRef
    {
        public int X;
        public int Y;

        public void LogValues()
        {
            Console.WriteLine($"X={X}; Y={Y}");
        }
    }

    // Структуры, содержащие ссылочные типы
    public struct EvilStruct
    {
        public int X;
        public int Y;

        public PointRef PointRef;
    }
}