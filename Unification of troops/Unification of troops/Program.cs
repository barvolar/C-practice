using System;
using System.Collections.Generic;
using System.Linq;

namespace Unification_of_troops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class SurnameDatabase
    {
        private List<string> _surnames;
        private Random _random;

        public SurnameDatabase()
        {
            _surnames = new List<string>();
            _random = new Random();
        }

        public string ReturnSurname()
        {
            int indexSurname = _random.Next(_surnames.Count);
            return _surnames[indexSurname];
        }

        private void AddSurnameToList()
        {
            _surnames.Add("Петров");
            _surnames.Add("Иванов");
            _surnames.Add("Горячий");
            _surnames.Add("Холодный");
            _surnames.Add("Лапшунов");
            _surnames.Add("Анпилогов");
            _surnames.Add("Дарожкин");
            _surnames.Add("Дроздов");
            _surnames.Add("Коленин");
            _surnames.Add("Прядкин");
            _surnames.Add("Маголин");
            _surnames.Add("Семашко");
            _surnames.Add("Николаев");
            _surnames.Add("Савицкий");
            _surnames.Add("Лысенко");
            _surnames.Add("Плеснев");
        }
    }

    class NameDatabase
    {
        private List<string> _names;
        private Random _random;

        public NameDatabase()
        {
            _names = new List<string>();
            _random = new Random();
            Create();
        }

        public string ReturnName()
        {
            int nameIndex = _random.Next(_names.Count);
            return _names[nameIndex];
        }

        private void Create()
        {
            _names.Add("Дмитрий");
            _names.Add("Виктор");
            _names.Add("Константин");
            _names.Add("Александр");
            _names.Add("Алексей");
            _names.Add("Виталий");
            _names.Add("Екатерина");
            _names.Add("Ольга");
            _names.Add("Елена");
            _names.Add("Аркадий");
            _names.Add("Лиза");
            _names.Add("Иван");
            _names.Add("Георгий");
            _names.Add("Григорий");
            _names.Add("Кристина");
            _names.Add("Наталья");
            _names.Add("Василий");
            _names.Add("Анна");
        }
    }
}
