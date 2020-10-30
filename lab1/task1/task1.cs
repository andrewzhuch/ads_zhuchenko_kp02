using System;
using static System.Console;
using static System.Math;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Input x");
            double x = double.Parse(ReadLine());
            WriteLine("Input y ");
            double y = double.Parse(ReadLine());
            WriteLine("Input z ");
            double z = double.Parse(ReadLine());
            double rangeOfValidValues1 = Pow(x, 2) + x * Pow(y, 2) + Pow(x, 2) * z;
            if (rangeOfValidValues1 <= 0)
            {
                WriteLine("Impossible to count ");
            }
            else    
            {
                double a = Convert.ToDouble(Sin(x * (PI / 180))) / Sqrt(rangeOfValidValues1);
                WriteLine(a);
                if (Convert.ToDouble(Cos(a * (PI / 180))) == 0)
                {
                    WriteLine("Impossible to count b");
                }
                else
                {
                    double b = Pow(x, 3) / Convert.ToDouble(Cos(a * (PI / 180)));
                    WriteLine(b);
                }
            }
        }
    }
}
