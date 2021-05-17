using System;
using System.Timers;

namespace G_Delegation
{
    public class CarArgs : EventArgs
    {
        public CarArgs(int currentSpeed)
        {
            CurrentSpeed = currentSpeed;
        }

        public int CurrentSpeed { get; }
    }
    
    public class Car
    {
        private int speed = 0;

        public event EventHandler<CarArgs> TooFastDriving;

        // public delegate void TooFast(int currentSpeed);

        // private TooFast tooFast;

        public void Start()
        {
            speed = 10;
        }

        public void Accelerate()
        {
            speed += 10;
            if (speed > 80)
                if (TooFastDriving != null)
                    TooFastDriving(this, new CarArgs(speed));
        }

        public void Stop()
        {
            speed = 0;
        }

        // public void RegisterOnTooFast(TooFast tooFast)
        // {
        //     this.tooFast += tooFast;
        // }
        //
        // public void UnregisterOnTooFast(TooFast tooFast)
        // {
        //     this.tooFast -= tooFast;
        // }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            // Делегаты
            Timer timer = new Timer();
            timer.Elapsed += Timer_Elapsed;
            
            timer.Interval = 2000;
            timer.Start();
            
            Car car = new Car();
            car.TooFastDriving += HandleOnTooFast; // подписались
            car.TooFastDriving += HandleOnTooFast;
            
            car.TooFastDriving -= HandleOnTooFast; // отписались
            
            car.Start();

            for (int i = 0; i < 10; i++)
            {
                car.Accelerate();
            }
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // var timer = (Timer) sender;
            Console.WriteLine("Handling Timer Elapsed Event");
        }

        private static void HandleOnTooFast(object obj, CarArgs speed)
        {
            var car = (Car) obj;
            Console.WriteLine($"Oh, I got it, calling stop! Current Speed={speed}");
            car.Stop();
        }
    }
}