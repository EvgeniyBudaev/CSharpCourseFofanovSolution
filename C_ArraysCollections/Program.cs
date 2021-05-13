using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace C_ArraysCollections
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Массивы и коллекции");
        }
        
        static void ClassArray() // Класс Array
        {
            int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9};
            int index = Array.BinarySearch(numbers, 7); // находит индекс первого вхождения у элемента

            int[] copy = new int[10];
            Array.Copy(numbers, copy, numbers.Length); // копирование массива

            int[] anotherCopy = new int[10]; // копирование массива
            copy.CopyTo(anotherCopy, 0);

            Array.Reverse(copy); // модифицирует массив
            Array.Sort(copy); // сортировка массива
            Array.Clear(copy, 0, copy.Length); // обнуляем масссив 

            int[] a1;
            a1 = new int[10];
            int[] a2 = new int[5];
            int[] a3 = new int[5] {1, 3, -2, 5, 10};
            int[] a4 = {1, 3, 2, 4, 5};
            Array myArray = new int[5];
            Array myArray2 = Array.CreateInstance(typeof(int), 4);
            myArray2.SetValue(12, 0); // по нулевому индексу установим число 12
            Console.WriteLine(myArray2.GetValue(0));
        }

        static void CollectionList() // Коллекция List
        {
            var intList = new List<int>() {1, 4, 2, 7, 5, 9, 12};
            intList.Add(7); // Метод Add модифицирует исходный массив
            int[] intArray = {1, 2, 3};
            intList.AddRange(intArray); // добавить массив в коллекцию List
            if (intList.Remove(1)) {} // если находит такой элемент, то метод Remove его удаляет первое вхождение
            intList.RemoveAt(0); // удаляем элемент по индексу 0
            intList.Reverse();
            bool contains = intList.Contains(3); // содержится ли элемент 3 в коллекции?
            int min = intList.Min(); // поиск минимального значение
            int max = intList.Max(); // поиск максимального значения
            int indexOf = intList.IndexOf(2); // находим индекс первой попавшиеся двойки
            int lastIndexOf = intList.LastIndexOf(2);

            for (int i = 0; i < intList.Count; i++) {}
            foreach (int item in intList) {}
        }

        static void CollectionDictionary() // Коллекция Dictionary
        {
            var people = new Dictionary<int, string>(); // ключи должны быть уникальными
            people.Add(1, "John");
            people.Add(2, "Bob");
            people.Add(3, "Alice");

            var people2 = new Dictionary<int, string>() {
                {1, "John"},
                {2, "Bob"},
                {3, "Alice"}
            };

            string name = people[1]; // вытащим имя по ключу 1

            Console.WriteLine("Iterating over keys");
            var keys = people.Keys;
            foreach (var item in keys) {
                Console.WriteLine(item);
            }

            Console.WriteLine("Iterating over values");
            var values = people.Values;
            foreach (var item in values) {
                Console.WriteLine(item);
            }

            Console.WriteLine("Iterating over keys and values");
            foreach (var pair in people) {
                Console.WriteLine($"Key:{pair.Key}, Value:{pair.Value}");
            }

            Console.WriteLine(people.Count); // Количество элементов в словаре
            bool containsKey = people.ContainsKey(2); // Содержится ли двойка в словаре?
            bool containsValue = people.ContainsValue("John");

            if (people.TryAdd(2, "Elias")) {  // Попытаться добавить значение Elias по ключу 2. Вернет false, если такой ключ уже существует.
                Console.WriteLine("Added successfuly");
            } else {
                Console.WriteLine("Failed to add using key 2");
            }

            // Объявляем переменную val, в которой мы хотим видеть значение, которое будет найдено методом TryGetValue по ключу 2
            if (people.TryGetValue(2, out string val)) { 
                Console.WriteLine($"Key 2, Val={val}");
            } else {
                Console.WriteLine("Failed to get");
            }

            people.Clear();
        }

        static void StackAndQueue() // Stack и Queue (стек и очередь)
        {
            // Stack применяется при отмене операций
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            Console.WriteLine($"Should print out 4: {stack.Peek()}"); // выведет последний элемент
            stack.Pop(); // Метод Pop удаляет элемент и возвращает удаленный элемент. 4-ка удалена
            Console.WriteLine("Iterate over the stack.");
            foreach (var cur in stack) {
                Console.WriteLine(cur); // 3 2 1
            }
            Console.WriteLine();

            // Queue - очередь
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            Console.WriteLine($"Should print out 1: {queue.Peek()}"); // выведет первый элемент
            queue.Dequeue();
            Console.WriteLine($"Should print out 2: {queue.Peek()}"); // выведет 2-ку
            Console.WriteLine("Iterate over the queue.");
            foreach (var cur in queue) {
                Console.WriteLine(cur); // 2 3 4
            }
        }

        static void MultiArrays() // Многомерные массивы
        {
            int[,] r1 = new int[2, 3] { {1, 2, 3}, {4, 5, 6}};
            int[,] r2 = { {1, 2, 3}, {4, 5, 6} }; // более короткая запись двумерного массива

            for (int i = 0; i < r2.GetLength(0); i++) {
                for (int j = 0; j < r2.GetLength(1); j++) {
                    Console.Write($"{r2[i, j]}");
                }
                Console.WriteLine();
            }
        }

        static void JaggedArrays() // Зубчатые массивы
        {
            int[][] jaggedArray = new int[4][];
            jaggedArray[0] = new int[1];
            jaggedArray[1] = new int[2];
            jaggedArray[2] = new int[3];
            jaggedArray[3] = new int[4];

            Console.WriteLine("Enter the number for a jagged array");
            for (int i = 0; i < jaggedArray.Length; i++) {
                for (int j = 0; j < jaggedArray[i].Length; j++) {
                    string st = Console.ReadLine();
                    jaggedArray[i][j] = int.Parse(st);
                }
            }
            Console.WriteLine();
            Console.WriteLine("Printing the elements");
            for (int i = 0; i < jaggedArray.Length; i++) {
                for (int j = 0; j < jaggedArray[i].Length; j++) {
                    Console.WriteLine(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void CustomIndexedArrays() // Массивы с настраиваемой индексацией
        {
            Array myArray = Array.CreateInstance(typeof(int), new[] { 4 }, new[] { 1 });
            myArray.SetValue(2019, 1);
            myArray.SetValue(2019, 2);
            myArray.SetValue(2019, 3);
            myArray.SetValue(2019, 4);
            Console.WriteLine($"Starting index: {myArray.GetLowerBound(0)}");
            Console.WriteLine($"Ending index: {myArray.GetUpperBound(0)}");
            for (int i = myArray.GetLowerBound(0); i <= myArray.GetUpperBound(0); i++) {
                Console.WriteLine($"{myArray.GetValue(i)} at index {i}");
            }
            Console.WriteLine();
            for (int i = 1; i < 5; i++) {
                Console.WriteLine($"{myArray.GetValue(i)} at index {i}");
            }
        }
        
    }
}