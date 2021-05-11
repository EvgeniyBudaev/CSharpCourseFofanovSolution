using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Threading;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace A_CSharpCourse
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
        }
        
        static void Variables() // типы переменных.
        {
            int x = -1;
            int y;
            y = 2;
            float f = 1.1f;
            double d = 2.3;
            var a = 10;
            // var dict = new Dictionary<int, string>()
            decimal money = 3.0m;
            char character = 'a';
            string text = "kyuyu";
            bool isActive = true; 
        }

        static void VariablesScope() // область видимости.
        {
             var a = 1;
            {
                var b = 2;
                {
                    var c = 3;
                    Console.WriteLine(a);
                    Console.WriteLine(b);
                    Console.WriteLine(c);
                }
                    Console.WriteLine(a);
                    Console.WriteLine(b);
            }
            Console.WriteLine(a);
        }

        static void Overflow() // переполнение.
        {
            checked // проверка. работает медленно. на практике почти не используется.
            {
                uint x = uint.MaxValue;
                Console.WriteLine(x);
                x = x + 1;
                Console.WriteLine(x);
                x = x - 1;
                Console.WriteLine(x);
            }
        }

        static void IncrementDecrementDemo() // математические операции
        {
            int x = 1;
            x = x + 1;
            x++;
            Console.WriteLine(x);
            ++x;
            Console.WriteLine(x);

            Console.WriteLine("Learn about increments");
            Console.WriteLine($"Last x state is {x}");
            int j = x++;
            Console.WriteLine(j);
            Console.WriteLine(x);
            j = ++x;
            Console.WriteLine(j);
            Console.WriteLine(x);

            x += 2;
        }

        static void MathOperations() // Алгебраические операции
        {
            int x = 1;
            int y = 2;
            int z = x + y;
            int b = x * y;
            int c = x / y;
            int a = 5 % 2;
            bool areEqual = x == y;
            bool res = x != y;
            bool result = x > y;
        }

        static void Methods() // Экземплярные и статические методы
        {
            string name = "abracadabra";
            bool isContainsA = name.Contains('a'); // проверяет есть ли символ 'a' в строке
            string abc = string.Concat("a", "b", "c");
            int x = 1;
            string xToStr = x.ToString();
        }

        static void QueryingStrings() // Базовый API для работы со строками
        {
            string name = "abracadabra";
            bool isContainsA = name.Contains('a'); // проверяет есть ли символ 'a' в строке
            bool isContainsE = name.Contains('E');
            bool endsWithAbra = name.EndsWith("abra"); // заканчивается ли строка на abra
            bool startsWithAbra = name.StartsWith("abra"); // начинается ли строка на abra
            int indexOfA = name.IndexOf('a'); // поиск индекса по первому вхождению этого символа
            int indexOfA1 = name.IndexOf('a', 1); // поиск начиная со второго символа
            int lastIndexOfA = name.LastIndexOf('a'); // поиск индекса по последнему вхождению символа
            Console.WriteLine(name.Length); // Длина строки (кол-во символов)
            string sustrFrom5 = name.Substring(5); // adabra. начинается с 5 индекса
            string sustrFromTo = name.Substring(0, 3); // abr. до 3-го индекса не включительно
        }

        static void StringEmptiness() // Пустота строк
        {
            string str = string.Empty; // Создание пустой строки

            string empty = "";
            string whiteSpaced = " ";
            string notEmpty = " b";
            string nullString = null; // null - означает отсутствие экземпляра

            Console.WriteLine("isNullOrEmpty"); // проверка на null или пустую строку
            bool isNullOrEmpty = string.IsNullOrEmpty(empty);
            Console.WriteLine($"[empty] {isNullOrEmpty}"); // True

            isNullOrEmpty = string.IsNullOrEmpty(whiteSpaced);
            Console.WriteLine($"[whiteSpaced] {isNullOrEmpty}"); // False

            isNullOrEmpty = string.IsNullOrEmpty(notEmpty);
            Console.WriteLine($"[notEmpty] {isNullOrEmpty}"); // False

            isNullOrEmpty = string.IsNullOrEmpty(nullString);
            Console.WriteLine($"[nullString] {isNullOrEmpty}"); // True

            Console.WriteLine();
            Console.WriteLine("isNullOrWhiteSpace"); // проверка на null или пустую строку, учитывая пробелы
            bool isNullOrWhiteSpace = string.IsNullOrWhiteSpace(empty);
            Console.WriteLine($"[empty] {isNullOrWhiteSpace}"); // True

            isNullOrWhiteSpace = string.IsNullOrWhiteSpace(whiteSpaced);
            Console.WriteLine($"[whiteSpaced] {isNullOrWhiteSpace}"); // True

            isNullOrWhiteSpace = string.IsNullOrWhiteSpace(notEmpty);
            Console.WriteLine($"[notEmpty] {isNullOrWhiteSpace}"); // False

            isNullOrWhiteSpace = string.IsNullOrWhiteSpace(nullString);
            Console.WriteLine($"[nullString] {isNullOrWhiteSpace}"); // True
        }

        static void StringModifications() // Изменение строк
        {
            string nameContact = string.Concat("My ", "name ", "is ", "Evgeniy"); // объединение строк

            nameContact = string.Join(" ", "My", "name", "is", "Evgeniy"); // объединяет строки с разделителем

            string newName = nameContact.Insert(0, "By the way, "); // вставка без модификации исходного кода, начиная с индекса 0
            nameContact = nameContact.Insert(0, "By the way, "); // вставка без модификации исходного кода, начиная с индекса 0

            nameContact = "My " + "name " + "is " + "Evgeniy"; // конкатенация строк

            nameContact = nameContact.Remove(0, 1); // удаление с указанного индекса и кол-во удаляемых символов

            string replaced = nameContact.Replace('n', 'z'); // заменить все вхождения

            string data = "12;28;34";
            string[] splitData = data.Split(";"); // разбиваем строку на элементы по разделителю и записываем в массив без разделителя 

            char[] chars = nameContact.ToCharArray(); // получаем массив символов
            Console.WriteLine(chars[0]);

            string name = "abracadabra";
            string sustrFromTo = name.Substring(0, 3); // abr. до 3-го индекса не включительно

            string lower = nameContact.ToLower(); // преобразование к нижнему регистру
            string upper = nameContact.ToUpper(); // преобразование к верхнему регистру

            string john = " My name is John ";
            john.Trim(); // обрезаем пробелы в начале и в конце строки
        }

        static void StringBuilderDemo() // StringBuilder
        {
            StringBuilder sb = new StringBuilder(); // StringBuilder - модифицирует исходную строку. Рекомендуется для сложения 7-ми и более строк. Он работает значительно быстрее, чем Contact, + или Join
            sb.Append("My "); // Append модифицирует строку без возвращаемого значения
            sb.Append("name "); // name будет добавлен к строке My
            sb.Append("John");
            sb.AppendLine("!"); // позволяет перенести каректку на новую строку. My name John!
            sb.AppendLine("Hello"); // Hello с новой строки

            string str = sb.ToString();
            Console.WriteLine(str); // My name John
        }

        static void StringFormat() // Форматирование строк
        {
            string name = "John";
            int age = 30;
            string str1 = string.Format("My name is {0} and I'm {1}", name, age); // 0, 1 - это заполнители (placeholder)
            Console.WriteLine(str1);
            string str2 = "My name is " + name + " and I'm " + age;
            string str3 = $"My name is {name} and I'm {age}"; // $ интерполирование строк
            Console.WriteLine(str3);

            string str4 = "My name is \nJohn"; // \n - переход на новую строку. В разных ОС работает по разному
            string str5 = "I'm \t30"; // \t - табуляция

            str4 = $"My name is {Environment.NewLine}John"; // Тоже что и \n, но для всех ОС работает одинаково корректно

            string str6 = "i'm John and I'm a \"good\" programmer"; // экранирование
            string str7 = "C:\\tmp\\test_file.txt";
            Console.WriteLine(str7); // C:\tmp\test_file.txt
            string str8 = @"C:\tmp\test_file.txt";
            Console.WriteLine(str8); // C:\tmp\test_file.txt

            int answer = 42;
            string result = string.Format("{0:d}", answer); // d- для вывода целых чисел
            string result2 = string.Format("{0:d4}", answer);
            Console.WriteLine();
            Console.WriteLine(result); // 42
            Console.WriteLine(result2); // 0042
            string result3 = string.Format("{0:f}", answer);
            string result4 = string.Format("{0:f4}", answer);
            Console.WriteLine(result3); // 42,00
            Console.WriteLine(result4); // 42,0000

            // double number = 42.3;
            // string result5 = string.Format("{0:f}", number);
            // string result6 = string.Format("{0:f4}", number);
            // Console.WriteLine(result5); // 42,30
            // Console.WriteLine(result6); // 42,3000

            double number2 = 42.06;
            string result7 = string.Format("{0:f}", number2);
            string result8 = string.Format("{0:f1}", number2);
            Console.WriteLine(result7); // 42,06
            Console.WriteLine(result8); // 42,1 округление в большую сторону

            Console.OutputEncoding = Encoding.UTF8;

            double money = 12.8;
            string result9 = string.Format("{0:C}", money); // C - используется для форматирования в денежном формате, выводит 2 знака после запятой
            string result10 = string.Format("{0:C2}", money);
            Console.WriteLine(result9); // 12,80 Р
            Console.WriteLine(result10); // 12,80 Р
            Console.WriteLine(money.ToString("C2"));
            string result11 = $"{money:C2}";
            Console.WriteLine(result11); // 12,80 Р

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Console.WriteLine(money.ToString("C2")); // получим значок долара, т.к. изменили локаль
        }

        static void ComparingStrings() // Сравнение строк
        {
            string str1 = "abcde";
            string str2 = "abcde";
            bool areEqual = str1 == str2; // True
            areEqual = string.Equals(str1, str2, StringComparison.Ordinal); // True. Идентичное сравнение. 

            string s1 = "Strasse";
            string s2 = "straße";
            areEqual = string.Equals(s1, s2, StringComparison.Ordinal); // False. Ordinal - сравнивает байтовую репрезентацию.
            areEqual = string.Equals(s1, s2, StringComparison.InvariantCulture); // True
            areEqual = string.Equals(s1, s2, StringComparison.CurrentCulture); // True
        }

        static void ConsoleBasics() // Работа с консолью
        {
            Console.WriteLine("Hi, please tell me your name.");
            string name = Console.ReadLine();
            string sentence = $"Your name is {name}";
            Console.WriteLine(sentence);
            Console.WriteLine("Hi, please tell me your age.");
            string input = Console.ReadLine();
            int age = int.Parse(input);
            string sentence2 = $"Your age is {age}";
            Console.WriteLine(sentence2);
            Console.Clear(); // Очистка консоли
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("New style "); // без перевода коректки на новую строку
            Console.Write("2021\n");
        }

        static void CastingAndParsing() // Приведение типов и парсинг
        {
            byte b = 3; // 3 //0000 0011
            int i = b; // 3 // 0000 0000 0000 0000 0000 0000 0000 0011
            float f = i; // 3 // 3.0

            // b = i; // Error
            b = (byte)i; // 3 // явное приведение типов
            f = 3.1f; // 3.1
            i = (int)f; // 3 // потеря точности

            string str = "1";
            // i = (int)str; // Error
            i = int.Parse(str); // 1 // Приведение строки к числу

            int x = 5;
            int result = x / 2; // 2
            double result2 = (double)x / 2; // 2.5
        }

        static void Comments() // Комментарии
        {
            // a single-line comment

            /*
            * Milti-line comment
            * We can write here many words
            */

            // describe hows and whys! not whats!
        }

         static void MathDemo() // Класс Math
        {
            Math.Pow(2, 3); // Pow - возведение в степень // 8
            Math.Sqrt(9); // Sqrt - квадратный корень // 3
            Math.Round(1.7); // Round - округление // 2
            Math.Round(1.4); // 1
            Math.Round(2.5); // 2
            Console.WriteLine(Math.Round(2.5));
            Math.Round(2.5, MidpointRounding.AwayFromZero); // 3 // Округление к числу удаленного от нуля.
            Math.Round(2.5, MidpointRounding.ToEven); // 2 // Конвертирование к ближайшему четному числу. По умолчанию ToEven. В банковских системах, т.к. не теряем деньги при округлении.
        }

        static void IntoToArrays() // Введение в массивы
        {
            int[] a1; // инициализация массива
            a1 = new int[10]; // выделили память под 10 элементов

            int[] a2 = new int[5];

            int[] a3 = new int[5] {1, 3, -2, 5, 10};

            int[] a4 = {1, 3, -2, 5, 10};
            Console.WriteLine(a4[0]); // 1

            a4[4] = 6; // перезапись значения в массиве
            Console.WriteLine(a4.Length); // Длина массива
            Console.WriteLine(a4[a4.Length - 1]); // Находим последний элемент в массиве

            string s1 = "abcdefgh";
            char first = s1[0]; // a
            char last = s1[s1.Length - 1]; // h
        }

        static void DateTimeIntro() // Знакомство с DateTime
        {
            DateTime now = DateTime.Now;
            Console.WriteLine(now);
            Console.WriteLine(now.ToString());
            Console.WriteLine($"It's {now.Date}, {now.Hour}:{now.Minute}");
            DateTime dt = new DateTime(2016, 2, 28);
            DateTime newDt = dt.AddDays(1);
            Console.WriteLine(newDt);

            TimeSpan ts = now - dt;
            ts = now.Subtract(dt); // тоже самое что и строкой выше
            Console.WriteLine(ts.Days); // разница в днях
        }
    }
}