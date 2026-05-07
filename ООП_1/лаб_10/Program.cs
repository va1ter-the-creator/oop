using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocsLib;

namespace лаб_10
{
    public class DateComparer : IComparer<Document>
    {   
        // Класс для сортировки по дате
        public int Compare(Document x, Document y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            return x.Date.CompareTo(y.Date);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Белавин И. А., РИС-24-1бзу
            // Лабораторная работа № 10. Вариант № 8

            Document[] docs = new Document[10];
            Random rnd = new Random();

            for (int i = 0; i < docs.Length; i++)
            {
                switch (rnd.Next(0,4)) {
                    case 0: docs[i] = new Document(); break;
                    case 1: docs[i] = new Receipt(); break;
                    case 2: docs[i] = new Invoice(); break;
                    case 3: docs[i] = new Check(); break;
                }
                docs[i].RandomInit();
                docs[i].ShowType();
                docs[i].Show();
            }

            // Часть 2
            // Запрос 1
            Console.WriteLine();
            Console.WriteLine("Подсчет кол-ва типов:");
            int docCount = 0, receiptCount = 0, invoiceCount = 0, checkCount = 0;
            foreach (Document d in docs)
            {
                if (d is Check) checkCount++;
                else if (d is Invoice) invoiceCount++;
                else if (d is Receipt) receiptCount++;
                else if (d is Document) docCount++;
            }

            Console.WriteLine($"Документов: {docCount}, Квитанций: {receiptCount}, Накладных: {invoiceCount}, Чеков: {checkCount},");

            // Запрос 2
            decimal limit = 0m;
            Console.WriteLine();
            Console.Write("Введите минимальную стоимость квитанции: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal l)) limit = l;

            Console.WriteLine($"Квитанции с суммой больше {limit}:");
            foreach (Document d in docs)
            {
                Receipt r = d as Receipt;
                if (r != null) 
                {
                    if (r.Amount > limit)
                    {
                        Console.WriteLine($"Квитанция №{r.Number} на сумму {r.Amount}");
                    }
                }
            }

            // Запрос 3
            Console.WriteLine();
            Console.WriteLine("Чеки из Пятерочки:");

            foreach (Document d in docs)
            {
                if (d is Check checkObj)
                {
                    if (checkObj.StoreName.Contains("Пятерочка"))
                    {
                        Console.WriteLine($"Чек из '{checkObj.StoreName}' " +
                            $"№{checkObj.Number} на сумму {checkObj.Amount} " +
                            $"от {checkObj.Date.ToShortDateString()}");
                    }
                }
            }

            // Часть 3
            // Сортировка (2)
            Console.WriteLine();
            Console.Write("Номера документов до сортировки: ");
            foreach (Document d in docs) Console.Write($"{d.Number}, ");
            Array.Sort(docs);
            Console.WriteLine();
            Console.Write("Номера документов после сортировки: ");
            foreach (Document d in docs) Console.Write($"{d.Number}, ");
            Console.WriteLine();

            // Сортировка (3)
            Console.WriteLine();
            Console.Write("Документы до сортировки по дате: ");
            foreach (Document d in docs) Console.Write($"{d.Number} ({d.Date.ToShortDateString()}), ");
            Array.Sort(docs, new DateComparer());
            Console.WriteLine();
            Console.Write("Документы после сортировки по дате: ");
            foreach (Document d in docs) Console.Write($"{d.Number} ({d.Date.ToShortDateString()}), ");
            Console.WriteLine();

            // Бинарный поиск (4)
            Console.WriteLine();
            Console.Write("Введите номер искомого документа: ");
            string searchNumber = Console.ReadLine();
            Document keyDoc = new Document(searchNumber, DateTime.Now, "");
            Array.Sort(docs);
            int index = Array.BinarySearch(docs, keyDoc);
            if (index > 0) Console.WriteLine($"Индекс документа: {index}");
            else Console.WriteLine("Документ с таким номером не найден");


            // Массив IInit (6)
            Console.WriteLine();
            IInit[] iinitArray = new IInit[5];
            iinitArray[0] = new Document();
            iinitArray[1] = new Receipt();
            iinitArray[2] = new Invoice();
            iinitArray[3] = new Check();
            iinitArray[4] = new Person();

            foreach (var item in iinitArray)
            {
                item.RandomInit();

                if (item is Document doc) Console.WriteLine($"Документ №{doc.Number}");
                else Console.WriteLine("Объект типа IInit");
            }


            // Клонирование (7)
            Console.WriteLine();
            Check newCheck = new Check();
            newCheck.RandomInit();
            Console.Write("Оригинальный чек: "); newCheck.Show();

            Console.WriteLine();
            Console.WriteLine("После клонирования");
            Check copyCheck = (Check)newCheck.Clone();
            copyCheck.Number = "Изменено";
            Console.Write("Оригинальный чек: "); newCheck.Show();
            Console.Write("Копия чека: "); copyCheck.Show();

            Console.WriteLine();
            Console.WriteLine("После поверхностного копирования");
            Check shallowCheck = (Check)newCheck.ShallowCopy();
            shallowCheck.Number = "Изменено";
            Console.Write("Оригинальный чек: "); newCheck.Show();
            Console.Write("Копия чека: "); shallowCheck.Show();
        }
    }
}
