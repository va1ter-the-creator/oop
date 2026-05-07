using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace лаб_4
{
    internal class Program
    {
        static int GetInt(string str)
        {
            // Ввод числа и валидация
            while (true)
            {
                Console.Write(str);
                string input = Console.ReadLine();

                try
                {
                    return int.Parse(input);
                }
                catch
                {
                    Console.WriteLine("Ошибка: введите корректное целое число");
                }
            }
        }

        static int[] SetArr()
        {
            // Создание массива и заполнение его случайными числами от 0 до 100
            int n = GetInt("Введите n: ");
            if (n < 1)
            {
                Console.WriteLine("Неверное значение!");
                return null;
            }

            Random a = new Random();
            int[] arr = new int[n];
            for (int i = 0; i < n; i++) arr[i] = a.Next(0, 100);

            PrintArr(arr);
            return arr;
        }

        static void PrintArr(int[] arr)
        {
            // Вывод всех элементов массива в консоль
            if (arr == null)
            {
                Console.WriteLine("Массив: не задан");
                return;
            }
            
            Console.Write("Массив: ");
            for (int i = 0; i < arr.Length; i++) Console.Write(arr[i] + " ");
            Console.WriteLine();

        }

        static int[] DeleteItems(int[] arr)
        {
            // Удаление каждого нечетного элемента в массиве
            if (arr == null)
            {
                Console.WriteLine("Массив: не задан");
                return arr;
            }

            int newSize = (arr.Length + 1) / 2;
            int[] newArr = new int[newSize];

            for (int i = 0, j = 0; i < arr.Length; i += 2, j++)
            {
                newArr[j] = arr[i];
            }

            PrintArr(newArr);
            return newArr;
        }

        static int[] AddItem(int[] arr)
        {
            // Добавление в массив нового элемента по индексу и значению
            if (arr == null)
            {
                Console.WriteLine("Массив: не задан");
                return arr;
            }

            int k = GetInt("Введите номер позиции (K): ");
            int value = GetInt("Введите значение элемента: ");

            if (k < 1 || k > arr.Length + 1)
            {
                Console.WriteLine("Неверный номер элемента!");
                return arr;
            }

            int[] newArr = new int[arr.Length + 1];
            int index = k - 1;

            for (int i = 0; i < index; i++) newArr[i] = arr[i];
            newArr[index] = value;
            for (int i = index; i < arr.Length; i++) newArr[i + 1] = arr[i];

            PrintArr(newArr);
            return newArr;
        }

        static void ReverseArr(int[] arr)
        {
            // Переворачивание массива
            if (arr == null)
            {
                Console.WriteLine("Массив: не задан");
                return;
            }

            for (int i = 0; i < arr.Length / 2; i++)
            {
                int temp = arr[i];
                arr[i] = arr[arr.Length - 1 - i];
                arr[arr.Length - 1 - i] = temp;
            }

            PrintArr(arr);
        }

        static void SortArr(int[] arr)
        {
            // Сортировака массива методом простого выбора
            if (arr == null)
            {
                Console.WriteLine("Массив: не задан");
                return;
            }

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    int temp = arr[i];
                    arr[i] = arr[minIndex];
                    arr[minIndex] = temp;
                }
            }

            PrintArr(arr);
        }


        static void GetAvgElement(int[] arr)
        {
            // Поиск элемента равному среднему арифметического всего массива
            if (arr == null)
            {
                Console.WriteLine("Массив: не задан");
                return;
            }

            // Среднее арифметическое
            double sum = 0;
            for (int i = 0; i < arr.Length; i++) sum += arr[i];
            int avg = (int)Math.Round(sum / arr.Length); // с округлением

            int count = 0;
            int ind = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                count++;
                if (arr[i] == avg)
                {
                    ind = i;
                    break;
                }

            }

            string el;
            if (ind == -1) el = "не найден";
            else el = $"{arr[ind]}";

            Console.WriteLine($"Ср. арифтем.: {avg}, элемент: {el}, кол-во сравнений: {count}");
        }

        static int menu()
        {
            // Вывод меню в консоль
            Console.WriteLine();
            Console.WriteLine("Меню: ");
            Console.WriteLine("1. Задать массив");
            Console.WriteLine("2. Распечатать массив");
            Console.WriteLine("3. Удалить все элементы с нечетными индексами");
            Console.WriteLine("4. Добавить элемент в позицию");
            Console.WriteLine("5. Перевернуть массив");
            Console.WriteLine("6. Сортировать массив");
            Console.WriteLine("7. Найти элемент равный сред. ариф. элементов массива");
            Console.WriteLine("0. Выход");
            int i = GetInt("Выберите номер: ");
            return i;
        }

        static void Main(string[] args)
        {
            // Белавин И. А., РИС-24-1бзу
            // Лабораторная работа № 4. Вариант № 8

            int[] arr = null;
            while (true)
            {
                int ind = menu();

                switch (ind)
                {
                    case 0: return;
                    case 1: arr = SetArr(); break;
                    case 2: PrintArr(arr); break;
                    case 3: arr = DeleteItems(arr); break;
                    case 4: arr = AddItem(arr); break;
                    case 5: ReverseArr(arr); break;
                    case 6: SortArr(arr); break;
                    case 7: GetAvgElement(arr); break;
                    default: Console.WriteLine("Неверный номер!"); break;
                }
            }

        }
    }
}
