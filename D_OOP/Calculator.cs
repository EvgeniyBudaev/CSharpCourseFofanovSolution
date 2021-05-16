namespace D_OOP
{
    // public static class Calculator // не возможно создать экземпляр класса если есть static у класса
    public class Calculator
    {
        public static double Average(int[] numbers)
        {
            int sum = 0;
            foreach(int n in numbers)
            {
                sum += n;
            }
            return (double)sum / numbers.Length;
        }

        public double Average2(params int[]  numbers)
        {
            int sum = 0;
            foreach(int n in numbers)
            {
                sum += n;
            }
            return (double)sum / numbers.Length;
        }

        public double CalcTriangleSquare(double ab, double bc, double ac)
        {
            double p = (ab + bc + ac) / 2;
            return System.Math.Sqrt(p * (p - ab) * (p - bc) * (p - ac));
        }

        public double CalcTriangleSquare(double b, double h)
        {
            return 0.5 * b * h;
        }

        // Опциональные параметры должны быть последними в списке. Для Public API лучше избегать опциональные параметры.
        public double CalcTriangleSquare(double ab, double ac, int alpha, bool isInRadians = false)
        {
            if (isInRadians) 
            {
                return 0.5 * ab * ac * System.Math.Sin(alpha);
            }
            else
            {
                double rads = alpha * System.Math.PI / 180;
                return 0.5 * ab * ac * System.Math.Sin(rads);
            }
        }

        public bool TryDivide(double divisible, double divisor, out double result)
        {
            result = 0;
            if (divisor == 0)
            {
                return false;
            }
            result = divisible / divisor;
            return true;
        }
    }
}