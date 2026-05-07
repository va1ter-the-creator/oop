using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Белавин И. А., РИС-24-1бзу
            // Лабораторная работа № 2. Вариант № 8

            // Задача 1 (8)
            Console.WriteLine("Задача 1");
            Console.Write("Введите n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int minValue = int.MaxValue;
            int minIndex = -1;
            for (int i = 1; i <= n; i++)
            {
                int num;
                Console.Write($"Введите {i}-й элемент: ");
                num = Convert.ToInt32(Console.ReadLine());

                if (num < minValue)
                {
                    minValue = num;
                    minIndex = i;
                }
            }

            Console.WriteLine($"Номер минимального элемента: {minIndex} ({minValue})");

            // Задача 2 (27)
            Console.WriteLine();
            Console.WriteLine("Задача 2");

            int minV = int.MaxValue;
            int maxV = int.MinValue;

            // Способ while
            //Console.WriteLine("Ввод чисел через Enter (0 для завершения):");
            //while ((num = Convert.ToInt32(Console.ReadLine())) != 0)
            //{
            //    if (num < min) min = num;
            //    if (num > max) max = num;
            //}

            // Способ do while
            int number;
            do
            {
                Console.Write("Введите число (0 для завершения): ");
                number = Convert.ToInt32(Console.ReadLine());

                if (number != 0)
                {
                    if (number < minV) minV = number;
                    if (number > maxV) maxV = number;
                }
            } while (number != 0);

            Console.WriteLine($"Сумма ({minV} + {maxV}): {minV + maxV}");

            // Задача 3 (42)
            Console.WriteLine();
            Console.WriteLine("Задача 3");

            Console.Write("Введите x: ");
            double x = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите глубину вложенности d: ");
            int d = Convert.ToInt32(Console.ReadLine());

            double result = 0;
            for (int k=d; k >= 1; k--)
            {
                double coeff = k * x;
                if (k % 2 != 0) result = Math.Sin(coeff + result);
                else result = Math.Cos(coeff - result);
            }
            Console.WriteLine($"Сумма (S) = {result}");

        }
    }
}
