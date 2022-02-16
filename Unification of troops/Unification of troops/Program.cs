using System;
using System.Collections.Generic;
using System.Linq;

namespace Unification_of_troops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Battalion battalion = new Battalion();
            battalion.ShowAllSoldiers();
            battalion.TransferOfSoldiers();
            battalion.ShowAllSoldiers();
        }
    }

    class Battalion
    {
        private List<Soldier> _division1;
        private List<Soldier> _division2;

        public Battalion()
        {
            _division1 = CreateAndReturnList(10);
            _division2 = CreateAndReturnList(15);
        }

        public void TransferOfSoldiers()
        {
            char transferIndex = 'Б';          
            _division2 = _division1.Where(soldier => soldier.Surname.StartsWith(transferIndex)).Concat(_division2).ToList();
            _division1 = _division1.Except(_division2).ToList();
        }

        public void ShowAllSoldiers()
        {
            Console.WriteLine("1 Div\n=========");
            ShowInfo(_division1);

            Console.WriteLine("2 Div\n=========");
            ShowInfo(_division2);
        }

        private void ShowInfo(List<Soldier> list)
        {
            foreach (var soldier in list)
                soldier.ShowInfo();
        }

        private List<Soldier> CreateAndReturnList(int numberOfSoldiers)
        {
            List<Soldier> soldiers = new List<Soldier>();

            for (int i = 0; i < numberOfSoldiers; i++)
            {
                soldiers.Add(new Soldier());
            }

            return soldiers;
        }
    }

    class Soldier
    {       
        private NameAndSurnameDatabase _nameAndSurnameDatabase;

        public string Name { get; private set; }
        public string Surname { get; private set; }

        public Soldier()
        {
            _nameAndSurnameDatabase = new NameAndSurnameDatabase();
            Name = _nameAndSurnameDatabase.ReturnName();
            Surname = _nameAndSurnameDatabase.ReturnSurname();
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} - {Surname}");
        }
    }

   
    class NameAndSurnameDatabase
    {
        private List<string> _names;
        private List<string> _surnames;
        private Random _random;

        public NameAndSurnameDatabase()
        {
            _names = new List<string>();
            _surnames= new List<string>();
            _random = new Random();
            AddNamesToList();
            AddSurnameToList();
        }

        public string ReturnName()
        {
            int nameIndex = _random.Next(_names.Count);
            return _names[nameIndex];
        }

        public string ReturnSurname()
        {
            int indexSurname = _random.Next(_surnames.Count);
            return _surnames[indexSurname];
        }

        private void AddNamesToList()
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

        private void AddSurnameToList()
        {
            _surnames.Add("Бетров");
            _surnames.Add("Бванов");
            _surnames.Add("Горячий");
            _surnames.Add("Холодный");
            _surnames.Add("Лапшунов");
            _surnames.Add("Анпилогов");
            _surnames.Add("Дарожкин");
            _surnames.Add("Дроздов");
            _surnames.Add("Боленин");
            _surnames.Add("Прядкин");
            _surnames.Add("Баголин");
            _surnames.Add("Семашко");
            _surnames.Add("Николаев");
            _surnames.Add("Савицкий");
            _surnames.Add("Лысенко");
            _surnames.Add("Плеснев");
        }
    }
}
