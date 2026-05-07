using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП_1
{
    internal class Program
    {   
        static double Calculate(double x)
        {
            // Вычисляет значение выражения sqrt(|x^3 - 1|) - 7 * cos((x^4 + x)^(1/3))
            double p1 = Math.Sqrt(Math.Abs(Math.Pow(x, 3) - 1));
            double p2 = 7 * Math.Cos(Math.Pow((Math.Pow(x, 4) + x), 1.0 / 3.0));
            return p1 - p2;
        }

        static bool IsPointInArea(double x, double y)
        {
            // Проверяет, принадлежит ли точка (x, y) заданной области.
            return ((x <= 0) && (x * x + y * y <= 4)) || ((x >= 0) && (y >= x - 2) && (y <= -x + 2));
        }

        static double CalculateFunc(double a, double b)
        {
            // Вычисляет значение выражения для задачи 3
            double p1 = Math.Pow(a + b, 3) - Math.Pow(a, 3);
            double p2 = Math.Pow(b, 3) + 3 * a * Math.Pow(b, 2) + 3 * Math.Pow(a, 2) * b;
            return p1 / p2;
        }

        static float CalculateFunc(float a, float b)
        {
            // Перегрузка для сравнения с типом float
            float p1 = (float)(Math.Pow(a + b, 3) - Math.Pow(a, 3));
            float p2 = (float)(Math.Pow(b, 3) + 3 * a * Math.Pow(b, 2) + 3 * Math.Pow(a, 2) * b);
            return p1 / p2;
        }

        static void Main(string[] args)
        {
            // Белавин И. А., РИС-24-1бзу
            // Лабораторная работа № 1. Вариант № 8

            // Задача 1
            Console.WriteLine("Задача 1");

            Console.Write("Введите n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите m: ");
            int m = Convert.ToInt32(Console.ReadLine());
            
            if (m == 0)
            {
                Console.WriteLine("Значение 'm' не может быть нулем!");
            }
            else
            {
                int result1 = n / m++;
                Console.WriteLine($"1.1 --> Результат n/m++: {result1}");
            }

            bool isResult2 = m++<--n;
            Console.WriteLine($"1.2 --> Результат m++<--n: {isResult2}");

            //bool result3 = (m/n)++ < n/m;
            Console.WriteLine($"1.3 --> Результат (m/n)++<n/m: Ошибка, нельзя инкремировать результат деления");

            Console.WriteLine($"1.4 --> Результаты функции:");
            double[] testValues = { 1, 0, 2, 5, 7};
            foreach (double x in testValues)
            {
                Console.WriteLine($"x={x}; y={Calculate(x)}"); 
            }

            // Задача 2
            Console.WriteLine();
            Console.WriteLine("Задача 2");
            var testPoints = new[]
            {
                new {x=1.0, y=3.0},
                new {x=0.0, y=-1.0},
                new {x=3.0, y=1.0},
                new {x=3.0, y=7.0}
            };
            foreach (var point in testPoints)
            {
                Console.WriteLine($"x={point.x}; y={point.y}; isIn={IsPointInArea(point.x, point.y)}");
            }


            // Задача 3
            Console.WriteLine();
            Console.WriteLine("Задача 3");

            double aDouble = 1000; double bDouble = 0.0001;
            Console.WriteLine($"a={aDouble}; b={bDouble}");
            Console.WriteLine($"f(double)={CalculateFunc(aDouble, bDouble)}");

            float aFloat = 1000.0f; float bFloat = 0.0001f;
            Console.WriteLine($"f(float)={CalculateFunc(aFloat, bFloat)}");

        }
    }
}
