using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace G_Delegation
{
    public class Car
    {
        private int speed = 0;

        public delegate void TooFast(int currentSpeed);

        private TooFast tooFast;

        public void Start()
        {
            speed = 10;
        }

        public void Accelerate()
        {
            speed += 10;
            if (speed > 80)
                tooFast(speed);
        }

        public void Stop()
        {
            speed = 0;
        }

        public void RegisterOnTooFast(TooFast tooFast)
        {
            this.tooFast = tooFast;
        }
    }
    public class Program
    {
        private static Car car;
        public static void Main(string[] args)
        {
            // Делегаты
            car = new Car();
            car.RegisterOnTooFast(HandleOnTooFast);
            
            car.Start();

            for (int i = 0; i < 10; i++)
            {
                car.Accelerate();
            }
        }

        private static void HandleOnTooFast(int speed)
        {
            Console.WriteLine($"Oh, I got it, calling stop! Current Speed={speed}");
            car.Stop();
        }
    }
}