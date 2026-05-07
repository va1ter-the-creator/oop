using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocsLib
{
    public interface IInit
    {
        void Init();
        void RandomInit();
    }

    public class Person : IInit
    {
        public string Name { get; set; }
        public int Age{ get; set; }

        public void Init()
        {
            Console.Write("Введите имя: ");
            Console.Write("Введите возраст: "); Name = Console.ReadLine();
            if (int.TryParse(Console.ReadLine(), out int id)) Age = id;
        }

        public void RandomInit()
        {
            Random rnd = new Random();
            Name = $"Человек_{rnd.Next(1, 99)}";
            Age = rnd.Next(18, 60);
        }
    }

    public class Document : IInit, IComparable<Document>, ICloneable
    {
        public string Number { get; set; } // номер документа
        public DateTime Date { get; set; } // дата создания документа
        public string Issuer { get; set; } // эмитент (отправитель)
        protected static readonly Random Rnd = new Random(); // генератор рандома

        // Метод для сравнений
        public int CompareTo(Document other)
        {
            if (other == null) return 1;
            return string.Compare(this.Number, other.Number, StringComparison.Ordinal);
        }

        // Конструкторы
        public Document()
        {
            Number = "Unknown";
            Date = DateTime.Now;
            Issuer = "Unknown";
        }

        public Document(string number, DateTime date, string issuer)
        {
            Number = number;
            Date = date;
            Issuer = issuer;
        }

        public Document(Document other)
        {
            Number = other.Number;
            Date = other.Date;
            Issuer = other.Issuer;
        }

        // Методы
        public override string ToString()
        {
            return $"Документ № {Number} от {Date.ToShortDateString()}, отправитель: {Issuer}";
        }

        public virtual void Show()
        {
            Console.WriteLine(this.ToString());
        }

        public void ShowType()
        {
            Console.Write($"Тип: Документ, ");
        }

        public virtual void Init()
        {
            Console.Write("Введите номер документа: ");
            Number = Console.ReadLine();

            Console.Write("Введите дату (dd.mm.yyyy): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime d)) Date = d;

            Console.Write("Введите отправителя: ");
            Issuer = Console.ReadLine();
        }

        public virtual void RandomInit()
        {
            Number = $"D-{Rnd.Next(1, 9999)}-{Rnd.Next(0, 365)}";
            Date = DateTime.Now.AddDays(-Rnd.Next(0, 365));
            Issuer = $"BLOCK{Rnd.Next(1, 20)}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Document doc)
            {
                return Number == doc.Number && Date == doc.Date && Issuer == doc.Issuer;
            }

            return false;
        }

        public virtual object Clone()
        {
            return new Document(this);
        }

        public virtual Document ShallowCopy()
        {
            return (Document)this.MemberwiseClone();
        }
    }

    public class Receipt : Document
    {
        public decimal Amount { get; set; }

        public Receipt() : base()
        { 
            Amount = 0;
        }

        public Receipt(string number, DateTime date, string issuer, decimal amount) : base(number, date, issuer)
        {
            Amount = amount;
        }

        public Receipt(Receipt other) : base(other)
        {
            Amount = other.Amount;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Сумма: {Amount}";
        }

        public new void ShowType()
        {
            Console.WriteLine($"Тип: Квитанция, ");
        }

        public override void Init()
        {
            base.Init();
            Console.Write("Введите сумму: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal a)) Amount = a;
        }

        public override void RandomInit()
        {
            base.RandomInit();
            Number = $"R-{Rnd.Next(1, 9999)}-{Rnd.Next(0, 365)}";
            Amount = Rnd.Next(0, 1000000) / 100m;
        }

        public override bool Equals(object obj)
        {
            if (obj is Receipt rec && base.Equals(obj))
            {
                return Amount == rec.Amount;
            }
            return false;
        }

        public override object Clone()
        {
            return new Receipt(this);
        }
    }

    public class Invoice : Document
    {
        public string Recipient { get; set; }
        public int ItemCount { get; set; }

        public Invoice() : base()
        { 
            Recipient = "";
            ItemCount = 0;
        }

        public Invoice(string number, DateTime date, string issuer, string recipient, int count) : base(number, date, issuer)
        {
            Recipient = recipient;
            ItemCount = count;
        }

        public Invoice(Invoice other) : base(other)
        {
            Recipient = other.Recipient;
            ItemCount = other.ItemCount;
        }
        public override string ToString()
        {
            return $"{base.ToString()}, Получатель: {Recipient}, Кол-во товаров: {ItemCount}";
        }

        public new void ShowType()
        {
            Console.WriteLine($"Тип: Накладная, ");
        }

        public override void Init()
        {
            base.Init();
            Console.Write("Введите получателя: ");
            Recipient = Console.ReadLine();
            Console.Write("Введите кол-во товаров: ");
            if (int.TryParse(Console.ReadLine(), out int c)) ItemCount = c;
        }

        public override void RandomInit()
        {
            base.RandomInit();

            Recipient = $"Клиент №{Rnd.Next(1, 99)}";
            Number = $"I-{Rnd.Next(1, 9999)}-{Rnd.Next(0, 365)}";
            ItemCount = Rnd.Next(1, 100);
        }

        public override bool Equals(object obj)
        {
            if (obj is Invoice inv && base.Equals(obj))
            {
                return Recipient == inv.Recipient && ItemCount == inv.ItemCount;
            }
            return false;
        }

        public override object Clone()
        {
            return new Invoice(this);
        }
    }

    public class Check : Receipt
    {
        public string StoreName { get; set; }

        public Check() : base()
        {
            StoreName = "";
        }

        public Check(string number, DateTime date, string issuer, decimal amount, string store)
            : base(number, date, issuer, amount)
        {
            StoreName = store;
        }

        public Check(Check other) : base(other)
        {
            StoreName = other.StoreName;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Магазин: {StoreName}";
        }

        public new void ShowType()
        {
            Console.WriteLine($"Тип: Чек, ");
        }

        public override void Init()
        {
            base.Init();
            Console.Write("Введите название магазина: ");
            StoreName = Console.ReadLine();
        }

        public override void RandomInit()
        {
            base.RandomInit();
            Number = $"C-{Rnd.Next(1, 9999)}-{Rnd.Next(0, 365)}";
            StoreName = Rnd.Next(0, 2) == 0 ? "Пятерочка" : "Магнит";
        }

        public override bool Equals(object obj)
        {
            if (obj is Check chk && base.Equals(obj))
            {
                return StoreName == chk.StoreName;
            }
            return false;
        }

        public override object Clone()
        {
            return new Check(this);
        }
    }
}
