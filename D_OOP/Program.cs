using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace D_OOP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("ООП");
            Character c = new Character();
            c.Hit(20);
            Console.WriteLine(c.Health);

            Calculator calc = new Calculator();
            // Перегрузка методов
            double square1 = calc.CalcTriangleSquare(10, 20);
            double square2 = calc.CalcTriangleSquare(10, 20, 30);
            // Модификатор static
            Character c1 = new Character();
            Character c2 = new Character();
            c1.IncreaseSpeed();
            Console.WriteLine($"c2.Speed={c1.PrintSpeed()}. c2.Speed={c2.PrintSpeed()}");

            double avg = Calculator.Average(new int[] {1, 2, 3, 4});
            // Ключевое слово params
            double avg2 = calc.Average2(1, 2, 3, 4);
            // Именованные аргументы
            calc.CalcTriangleSquare(ab: 10, bc: 20, ac: 30);
            Console.WriteLine("Enter a number, please");
            string line = Console.ReadLine();

            // Выходные out-параметры
            // TryParse возвращает true, если удалось отпарсить строку. Если нет, то возвращает false
            // Успешний результат в out параметре
            bool wasParsed = int.TryParse(line, out int number); 
            if (wasParsed) {
                Console.WriteLine(number);
            }
            else
            {
                Console.WriteLine("Failed to parse");
            }

            if (calc.TryDivide(10, 2, out double result))
            {
                Console.WriteLine(result);
            }
            else 
            {
                Console.WriteLine("Failed to divide");
            }

            // Опциональные параметры
            Calculator calc3 = new Calculator();
            calc3.CalcTriangleSquare(10, 20, 30, true);

            // Ссылочные типы и типы-значения
            Console.WriteLine("Ссылочные типы и типы-значения");
            PointVal a; // тоже самое что и PointVal a = new PointVal
            a.X = 3;
            a.Y = 5;

            PointVal b = a;
            b.X = 7;
            b.Y = 10;
            a.LogValues();
            b.LogValues();
            Console.WriteLine("After structs");
            PointRef d = new PointRef(); 
            d.X = 3;
            d.Y = 5;

            PointRef e = d;
            e.X = 7;
            e.Y = 10;
            d.LogValues();
            e.LogValues();

            // Структуры, содержащие ссылочные типы
            Console.WriteLine("Структуры, содержащие ссылочные типы");
            EvilStruct es1 = new EvilStruct();
            // es1.PointRef = new PointRef(); 
            // es1.PointRef.X = 1;
            // es1.PointRef.Y = 2;
            es1.PointRef = new PointRef() { X = 1, Y = 2 }; // Или краткая запись
            EvilStruct es2 = es1;
            Console.WriteLine($"es1.PointRef.X={es1.PointRef.X}, es1.PointRef.Y={es1.PointRef.Y}"); 
            Console.WriteLine($"es2.PointRef.X={es2.PointRef.X}, es2.PointRef.Y={es2.PointRef.Y}");
            es2.PointRef.X = 42;
            es2.PointRef.Y = 45;
            Console.WriteLine($"es1.PointRef.X={es1.PointRef.X}, es1.PointRef.Y={es1.PointRef.Y}"); 
            Console.WriteLine($"es2.PointRef.X={es2.PointRef.X}, es2.PointRef.Y={es2.PointRef.Y}");

            // Передача ссылочных типов и типов-значений как аргументов
            var list = new List<int>();
            AddNumbers(list);
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }

            int aa = 1;
            int bb = 2;
            Swap(ref aa, bb); // ref- передаем аргументы по ссылке. ref достаточно редко применяется

            // NullReferenceException и Nullable-структуры
            Console.WriteLine("NullReferenceException и Nullable-структуры");
            PointRef variable; // variable = null
            // Console.WriteLine(variable.X); // NullReferenceException
            PointVal variablePV; // не null, сразу выделяется память в структуре. PointVal variablePV = null так сделать нельзя.
            // Console.WriteLine(variablePV.X);
            PointVal? variablePVNullable = null; // теперь можно структуре присвоить null
            if (variablePVNullable.HasValue)
            {
                // PointVal pv2 = variablePVNullable.Value; // тоже самое что и ниже запись
                Console.WriteLine(variablePVNullable.Value.X);
            } 
            else 
            {
                //
            }
            // если variablePVNullable не null, то получим value и запишем ее в pv3, иначе получим экземпляр по умолчанию
            PointVal pv3 = variablePVNullable.GetValueOrDefault(); 

            // Упаковка и разупаковка (boxing \ unboxing)
            Console.WriteLine("Упаковка и разупаковка (boxing \\ unboxing)");
            int x  = 1;
            object obj = x; // boxing

            int y = (int)obj; // unboxing

            double pi = 3.14;
            object obj1 = pi;
            int numberr = (int)(double)obj1;

            // Конструкторы
            Console.WriteLine("Конструкторы");
            Character elf = new Character(Race.Elf);

            // Константы: модификаторы const и readonly
            Console.WriteLine("Константы: модификаторы const и readonly");

            // Наследование
             Console.WriteLine("Наследование");
             ModelXTerminal terminal = new ModelXTerminal("123id");
             terminal.Connect();

             // Полиморфизм
             Console.WriteLine("Полиморфизм");
             Shape[] shapes = new Shape[2];
             shapes[0] = new Triangle(10, 20, 30);
             shapes[1] = new Rectangle(5, 10);
             foreach(Shape shape in shapes)
             {
                 shape.Draw();
                 Console.WriteLine(shape.Perimeter());
             }

             // Интерфейсы
             Console.WriteLine("Интерфейсы");
             List<object> listVariables = new List<object>() {1, 2, 3};
             IBaseCollection collection = new BaseList(4);
             collection.Add(1);

             // Методы-расширения (extension methods)            
             collection.AddRange(listVariables);

             // Отношение "is a" при наследовании. Проблема представителя.
            //  Rect rect = new Rect { Height = 2, Width = 5 }; 
            //  int rectArea = AreaCalculator.CalcSquare(rect);
            //  Console.WriteLine($"Rect area = {rectArea}");
            //  Rect square = new Square { Height = 2, Width = 10 };
            IShape rect = new Rect() { Height = 2, Width = 10 };
            IShape square = new Square { SideLenght = 10 };
            Console.WriteLine($"Rect area = {rect.CalcSquare()}");
            Console.WriteLine($"Square area = {square.CalcSquare()}");

            // Перечисления
            Console.WriteLine("Перечисления");
            Character personazh = new Character(Race.Elf);
            
            // Пишем Stack основанный на object
            // Делаем Stack обобщённым
            Console.WriteLine("Пишем Stack основанный на object");
            MyStack<int> ms = new MyStack<int>();
            ms.Push(1);
            ms.Push(2);
            ms.Push(3);
            Console.WriteLine(ms.Peek()); // последний добавленный элемент
            ms.Pop(); // извлекаем последний элемент
            Console.WriteLine(ms.Peek());
            ms.Push(3); // проверяем расширение стека
            ms.Push(4);
            ms.Push(5);
            Console.WriteLine(ms.Peek());
            // А что если вместо цифр мы передадаим белеберду ?
            // ms.Push("abra");
            // ms.Push(false);
            // ms.Push(new Character(Race.Elf));
            // и переберем в цикле. И мы думаем, что там только инты 
            while (ms.Count != 0)
            {
                Console.WriteLine((int)ms.Peek());
                ms.Pop();
            }
            
            // foreach и IEnumerable
            var myst = new MyStack<int>();
            // System.Collections.IEnumerable enumer = (System.Collections.IEnumerable)myst;
            // enumer.GetEnumerator();
            foreach (var item in ms)
            {
                Console.WriteLine(item);
            }
            
            // Ленивое вычисление и yield
            
            // Управление памятью и сборка мусора

        }
        
        // ООП

        static void MyFirstClass() // Создаем свой первый класс
        {
            Character c = new Character();
        }

        static void AccessModifiers() // Модификаторы доступа
        {
            // public class Character
            // {
            //     // public - получение доступа из внешней сборки, к примеру A_CSharpCourse
            //     // internal - получение доступа в текущей сборке D_OOP
            //     // protected - доступ в классах наследниках
            //     public int Health = 100;

            //     public void Hit(int damage)
            //     {
            //         Health -= damage;
            //     }
            // }
        }


        static void PublicAccessIssues() // Проблемы с публичным доступом
        {
            // public class Character
            // {
            //     private int Health = 100;

            //     public void Hit(int damage)
            //     {
            //         if (damage > Health)
            //             damage = Health;

            //         Health -= damage;
            //     }
            // }
        }

        static void IntroToProperties() // Введение в свойства
        {
                // public class Character
                // {
                //     private int health = 100;

                //     public int Health // свойство класса
                //     {
                //         get
                //         {
                //             return health;
                //         }
                //         private set
                //         {
                //             health = value;
                //         }
                //     }

                //     public void Hit(int damage)
                //     {
                //         if (damage > health)
                //             damage = health;

                //         // health -= damage;
                //         Health -= damage;
                //     }
                // }
        }

        static void IntroAutoProperties() // Как устроены свойства. Автосвойства
        {
            // public class Character
            // {
            //     public int Health {get; private set;} = 100; // Автосвойства

            //     public void Hit(int damage)
            //     {
            //         if (damage > Health)
            //             damage = Health;

            //         Health -= damage;
            //     }
            // }
        }

        static void MethodOverloading() // Перегрузка методов
        {
            // public class Calculator
            // {
            //     public double CalcTriangleSquare(double ab, double bc, double ac)
            //     {
            //         double p = (ab + bc + ac) / 2;
            //         return System.Math.Sqrt(p  (p - ab)  (p - bc) * (p - ac));
            //     }

            //     public double CalcTriangleSquare(double b, double h)
            //     {
            //         return 0.5  b  h;
            //     }
            // }
        }

        static void ParamsKeyword() // Ключевое слово params
        {
            // public class Calculator
            // {
            //     public double Average(int[] numbers)
            //     {
            //         int sum = 0;
            //         foreach(int n in numbers)
            //         {
            //             sum += n;
            //         }
            //         return (double)sum / numbers.Length;
            //     }

            //     public double Average2(params int[]  numbers)
            //     {
            //         int sum = 0;
            //         foreach(int n in numbers)
            //         {
            //             sum += n;
            //         }
            //         return (double)sum / numbers.Length;
            //     }

            //     public double CalcTriangleSquare(double ab, double bc, double ac)
            //     {
            //         double p = (ab + bc + ac) / 2;
            //         return System.Math.Sqrt(p  (p - ab)  (p - bc) * (p - ac));
            //     }

            //     public double CalcTriangleSquare(double b, double h)
            //     {
            //         return 0.5  b  h;
            //     }
            // }
        }

        static void NamedArguments() // Именованные аргументы
        {
            Calculator calc = new Calculator();
            calc.CalcTriangleSquare(ab: 10, bc: 20, ac: 30);
        }
        
        static void OutputoutParameters() // Выходные out-параметры
        {
            // public bool TryDivide(double divisible, double divisor, out double result)
            // {
            //     result = 0;
            //     if (divisor == 0)
            //     {
            //         return false;
            //     }
            //     result = divisible / divisor;
            //     return true;
            // }
        }

        static void StaticModifier() // Модификатор static
        {
            // public static int speed = 10; // статическое свойство или поле абсолютно разделяются на все экземпляры типа Character
        }

        static void OptionalParameters() // Опциональные параметры
        {
            // Опциональные параметры должны быть последними в списке. Для Public API лучше избегать опциональные параметры.
            // public double CalcTriangleSquare(double ab, double ac, int alpha, bool isInRadians = false)
        }

        static void ReferenceTypesAndValueTypes() // Ссылочные типы и типы-значения
        {
            // public struct PointVal // struct - структура. Все классы это ссылочные типы, а структура это value типы.
            // {
            //     public int X;
            //     public int Y;

            //     public void LogValues()
            //     {
            //         Console.WriteLine($"X={X}; Y={Y}");
            //     }
            // }

            // public class PointRef
            // {
            //     public int X;
            //     public int Y;

            //     public void LogValues()
            //     {
            //         Console.WriteLine($"X={X}; Y={Y}");
            //     }
            // }
        }

        static void StackAndHeap() // Стек и куча
        {
            // Все объекты (экземпляры и стуктур и классов) распологаютс яв оперативной памяти
            // В оперативной памяти есть области, называемые стек и куча (управляемая куча для .NET)
            // Обычно, типы-значения (структуры) распологаются на стеке, а ссылочные типы (классы) распологаются в куче
        }

        static void StructuresContainingReferenceTypes() // Структуры, содержащие ссылочные типы
        {
            // Структуры лучше не использовать
        }

        static void PassingReferenceAndValueTypesAsArguments() // Передача ссылочных типов и типов-значений как аргументов
        {
            // Swap(ref aa, bb);
        }

        static void AddNumbers(List<int> numbers) // Передача ссылочных типов и типов-значений как аргументов
        {
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
        }

        static void Swap(ref int a, int b) // ref- данный метод принимает аргументы по ссылке
        {
            Console.WriteLine($"Original a={a}, b={b}");
            int tmp = a;
            a = b;
            b = tmp;
            Console.WriteLine($"Swapped a={a}, b={b}");
        }

        static void NullReferenceExceptionAndNullable() // NullReferenceException и Nullable-структуры
        {
            // PointVal pv3 = variablePVNullable.GetValueOrDefault()
        }

        static void boxingAndUnboxing() // Упаковка и разупаковка (boxing \ unboxing)
        {
        }

        static void Do(object obj) // Упаковка и разупаковка (boxing \ unboxing)
        {
            bool isPointRef = obj is PointRef;
            if (isPointRef)
            {
                PointRef pr1 = (PointRef)obj;
                Console.WriteLine(pr1.X);
            }
            else {}

            PointRef pr2 = obj as PointRef;
            if (pr2 != null)
            {
                Console.WriteLine(pr2.X);
            }
        }

        static void Constructors() // Конструкторы
        {
            // public Character(string race)
            // {
            //     Race = race;
            //     Armor = 30;
            // }
        }

        static void ConstAndReadonly() // Константы: модификаторы const и readonly
        {
                // public const int charisma = 10; // константа. обязаны инициализировать переменную
                // readonly - используется, если поле инициализируем через конструктор единожды и дальше в метод не имеем права его дальше менять
                // readonly - помечает поле как инстанцию класса
                // readonly. не обязаны сразу инициализировать переменную. 
                // public readonly int strength; // readonly. не обязаны сразу инициализировать переменную. 
        }

        static void Inheritance() // Наследование
        {
            //  ModelXTerminal terminal = new ModelXTerminal("123id");
            //  terminal.Connect();
        }

        static void Polymorphism() // Полиморфизм
        {
            //  Shape[] shapes = new Shape[2];
            //  shapes[0] = new Triangle(10, 20, 30);
            //  shapes[1] = new Rectangle(5, 10);
            //  foreach(Shape shape in shapes)
            //  {
            //      shape.Draw();
            //      Console.WriteLine(shape.Perimeter());
            //  }
        }

        static void Stream() // Интерфейсы
        {
            IBaseCollection collection = new BaseList(4);
            collection.Add(1);
        }

        static void Interfaces() // Методы-расширения (extension methods)
        {
            // collection.AddRange(listVariables);
        }
        
    }
}