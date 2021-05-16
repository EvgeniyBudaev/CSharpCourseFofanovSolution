using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace F_WorkToFiles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Работа с файлами"); 
            // Файлы, директории и папки
            try
            {
                DirFileDemo();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        static void DirFileDemo()
        {
            File.Copy("test.txt", @"Q:\tmp\test_copy.txt", overwrite:true); // копирование
            File.Move("test_copy.txt", "test_copy_renamed.txt", overwrite:true); // перемещение
            File.Delete("test_copy.txt"); // удаление
            // Exists возвращает true, если файл на диске
            if (File.Exists("test.txt"))
            {
                File.AppendAllText("test.txt", "bla");
            }
            // Replace - если мы хотим перезаписать внутренности одного файла внутренностями другого файла
            File.Replace("test_2.txt", "test_3.txt", "test_backup.txt");

            bool existsDir = Directory.Exists(@"C:\tmp");
            if (existsDir)
            {
                var files = Directory.EnumerateFiles(@"C:\tmp", "*.txt", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    Console.WriteLine(file);
                }
            }
            
            Directory.Delete(@"C:\tmp");

            Path.Combine(@"C:\tmp", "\\bla", "file.txt");
        }

        static void FileDemo()
        {
            // Файлы и потоки
            string[] allLines = File.ReadAllLines("test.txt"); // в массив
            string allText = File.ReadAllText("test.txt");
            IEnumerable<string> lines = File.ReadLines("test.txt"); // для больших файлов
            File.WriteAllText("test_2.txt", "My name is John");
            File.WriteAllLines("test_3.txt", new string[] { "My name", " is John" });
            File.WriteAllBytes("test_4.txt", new byte[] { 72, 101, 108, 108, 111 });
            
            Console.WriteLine("==============");    
            Stream fs = new FileStream("test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            try
            {
                string str = "Hello, World!";
                byte[] strInBytes = Encoding.ASCII.GetBytes(str);
                fs.Write(strInBytes, 0, strInBytes.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.ToString()}");
                throw;
            }
            finally
            {
                fs.Close();
            }

            Console.WriteLine("Now reading");

            using (Stream readingStream = new FileStream("test.txt", FileMode.Open, FileAccess.Read))
            {
                byte[] temp = new byte[readingStream.Length];
                int bytesToRead = (int)readingStream.Length;
                int bytesRead = 0;
                while (bytesToRead > 0)
                {
                    int n = readingStream.Read(temp, bytesRead, bytesToRead);
                    if (n == 0)
                        break;

                    bytesRead += n;
                    bytesToRead -= n;
                    string str = Encoding.ASCII.GetString(temp, 0, temp.Length);
                    Console.WriteLine(str);
                }
            }
        }
        
    }
}