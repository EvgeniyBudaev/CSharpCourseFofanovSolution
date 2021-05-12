using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace B_ControlFlow
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Управление потоком исполнения (Control Flow)");
        }

                static void IfAndElse() // Условные выражения в C#
        {
            Console.WriteLine("What's your age?");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("What's your weight in kg?");
            double weight = double.Parse(Console.ReadLine());

            Console.WriteLine("What's your height in meters?");
            double height = double.Parse(Console.ReadLine());

            double bodyMassIndex = weight / (height * height);

            bool isTooLow = bodyMassIndex <= 18.5;
            bool isNormal = bodyMassIndex > 18.5 && bodyMassIndex < 25;
            bool isAboveNormal = bodyMassIndex >= 25 && bodyMassIndex <= 30;
            bool isTooFat = bodyMassIndex > 30;
            bool isFat = isAboveNormal || isTooFat;

            if (isFat) {
                Console.WriteLine("You'd better lose some weight.");
            } else {
                Console.WriteLine("Oh, you're in a good shape.");
            }

            if (!isFat) {
                Console.WriteLine("You're definitely not fat!");
            }

            if (isTooLow) {
                Console.WriteLine("Not enough weight.");
            } else if (isNormal) {
                Console.WriteLine("You'are OK.");
            } else if (isAboveNormal) {
                Console.WriteLine("Be careful.");
            } else {
                Console.WriteLine("You need to lose some weight.");
            }

            if (isFat || isTooFat) {
                Console.WriteLine("Anyway it's time to get on diet.");
            }

            // Тернарный оператор
            string description = age > 18 ? "You can drink alcohol" : "You should get a bit older";
            Console.WriteLine(description);
        }

        static void ForAndForeach() // Циклы for и foreach
        {
            int[] numbers = {1, 2, 3, 4, 5};
            for(int i = 0; i < numbers.Length; i++) {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();
            for(int j = numbers.Length - 1; j >= 0; j--) {
                Console.Write(numbers[j] + " ");
            }
            Console.WriteLine();
            for(int k = 0; k < numbers.Length; k++) {
                if (numbers[k] % 2 == 0) {
                    Console.Write(numbers[k] + " ");
                }
            }
            Console.WriteLine();
            foreach(int val in numbers) {
                Console.Write(val + " ");
            }
        }

        static void NestedForLoop() // Вложенный цикл for
        {
            int[] numbers = {1, -2, 4, -7, 5, 3, 2, -1, -3, 2, 7, -1, -3, 1, 7};
            for (int i = 0; i < numbers.Length - 1; i++) {
                for (int j = i + 1; j < numbers.Length; j++) {
                    int atI = numbers[i];
                    int atJ = numbers[j];
                    if (atI + atJ == 0) {
                        Console.WriteLine($"Pair ({atI};{atJ}). Indexes ({i};{j})");
                    }
                }
            }

            Console.WriteLine();

            for (int i = 0; i < numbers.Length - 2; i++) {
                for (int j = i + 1; j < numbers.Length - 1; j++) {
                    for (int k = j + 1; k < numbers.Length; k++) {
                        int atI = numbers[i];
                        int atJ = numbers[j];
                        int atK = numbers[k];
                        if (atI + atJ + atK == 0) {
                            Console.WriteLine($"Pair ({atI};{atJ};{atK}). Indexes ({i};{j};{k})");
                        }
                    }
                }
            }
        }

        static void WhileAndDowhile() // Циклы while и do while
        {
            int age = 0;
            while (age < 18) {
                Console.WriteLine("What is your age?");
                age = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Good!");
            Console.WriteLine();

            do {
                Console.WriteLine("What is your age?");
                age = int.Parse(Console.ReadLine());
            }
            while (age < 18);
            Console.WriteLine();

            int[] numbers = {1, 2, 3, 4, 5};
            int i = 0;
            while (i < numbers.Length) {
                Console.WriteLine(numbers[i] + " ");
                i++;
            }
        }

        static void BreakAndContinue() // Управление циклом: break и continue
        {
            int[] num = {0, 1, 2, 3, 4, 5};

            foreach(int n in num) {
                if (n % 2 != 0) {
                    continue;
                }
                Console.WriteLine(n);
            }
            Console.WriteLine();

            char[] letters = {'a', 'b', 'c', 'd', 'e', 'f'};
            for (int i = 0; i < num.Length; i++) {
                Console.WriteLine($"Number={num[i]}");
                for (int j = 0; j < letters.Length; j++) {
                    if (num[i] == j) {
                        break;
                    }     
                    Console.Write($" {letters[j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            int[] numbers = {1, -2, 4, -7, 5, 3, 2, -1, -3, 2, 7, -1, -3, 1, 7};
            int counter = 0;
            for (int i = 0; i < numbers.Length - 1; i++) {
                if (counter == 3) {
                    break;
                }
                for (int j = i + 1; j < numbers.Length; j++) {
                    int atI = numbers[i];
                    int atJ = numbers[j];
                    if (atI + atJ == 0) {
                        Console.WriteLine($"Pair ({atI};{atJ}). Indexes ({i};{j})");
                        counter++;
                    }
                    if (counter == 3) {
                        break;
                    }
                }
            }
        }

        static void SwitchAndCase() // Условия через switch\case
        {
            Console.WriteLine("Введите месяц от 1 до 12");
            int month = int.Parse(Console.ReadLine());
            string season = string.Empty;
            switch (month) {
                case 1:
                case 2:
                case 12:
                    season = "Winter";
                    break;
                case 3:
                case 4:
                case 5:
                    season = "Spring";
                    break;
                case 6:
                case 7:
                case 8:
                    season = "Summer";
                    break;
                case 9:
                case 10:
                case 11:
                    season = "Autumn";
                    break;
                 default:
                    throw new ArgumentException("Unexpected number of month");   
            }
            Console.WriteLine();

            Console.WriteLine("Введите сколько лет прошло со свадьбы");
            int weddingYears = int.Parse(Console.ReadLine());
            string name = string.Empty;
            switch (weddingYears) {
                case 5:
                    name = "Деревянная свадьба";
                    break;
                 case 10:
                    name = "Оловянная свадьба";
                    break; 
                 case 15:
                    name = "Хрустальная свадьба";
                    break; 
                default:
                    name = "не знаем такого юбилея!";
                    break;      
            }
            Console.WriteLine(name);
        }

        static void Debugging() // Отладка: основы основ
        {
            Console.WriteLine("Let's calculate the square of a triangle");
            Console.WriteLine("enter the length of side AB:");
            double ab = GetDouble();
            Console.WriteLine("enter the length of side BC:");
            double bc = GetDouble();
            Console.WriteLine("enter the length of side AC:");
            double ac = GetDouble();
            double p = (ab + bc + ac) / 2;
            double square = Math.Sqrt(p * (p - ab) * (p - bc) * (p - ac));
            Console.WriteLine($"Square of the triangle equals {square}");
        }

        static double GetDouble() // Получение числа, введенного от пользователя
        {
            return double.Parse(Console.ReadLine());
        }

    }
}