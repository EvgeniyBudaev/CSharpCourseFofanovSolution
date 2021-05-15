using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace E_Exceptions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Исключения");
            Console.WriteLine("Please input a number");
            string result = Console.ReadLine();
            int number = 0;
            try
            {
                number = int.Parse(result);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("A format exception has occured");
                Console.WriteLine("Information is below");
                Console.WriteLine(ex.ToString());
            }
            // этот блок отлавливает все исключения
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine(number);
            Console.WriteLine();

            FileStream file = null;
            try
            {
                file = File.Open("temp.txt", FileMode.Open);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            // finally - Если нам нужно гарантировать, что некий блок кода отрабоает после возникновения ошибки
            // В finally пишут блок очистки.
            finally 
            {
                if (file != null)
                    // Dispose - если произошла ошибка, то гарантировано закрываем FileStream
                    file.Dispose(); 
            }
        }
        
    }
}