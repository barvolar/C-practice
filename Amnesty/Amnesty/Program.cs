using System;
using System.Collections.Generic;
using System.Linq;

namespace Amnesty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Jail jail = new Jail();
            jail.ShowInfo();

            Console.WriteLine("Для проведения амнистии нажмите любую кнопку");

            Console.ReadKey();
            Console.Clear();
            jail.ExecutionAmnesty();
            jail.ShowInfo();
        }
    }

    class Jail
    {
        private List<Prisoner> _prisoners;

        public Jail()
        {
            _prisoners = new List<Prisoner>();
            Create();
        }

        public void ExecutionAmnesty()
        {
            var newPrisoners = _prisoners.Where(prisoner => prisoner.Crime != "Антиправительственное").ToList();
            _prisoners=newPrisoners;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Количество осужденных в колонии - {_prisoners.Count}\n============");

            foreach (var prisoner in _prisoners)
            {
                prisoner.ShowInfo();
            }
        }

        private void Create()
        {
            int prisonersCount = 1720;

            for (int i = 0; i < prisonersCount; i++)
            {
                _prisoners.Add(new Prisoner());
            }
        }       
    }

    class Prisoner
    {
        private NameDatabase _nameDatabase;
        private CrimeDatabase _crimeDatabase;
        private string _name;

        public string Crime { get; private set; }

        public Prisoner()
        {
            _nameDatabase = new NameDatabase();
            _crimeDatabase = new CrimeDatabase();
            _name = _nameDatabase.ReturnName();
            Crime = _crimeDatabase.ReturnCrime();
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{_name} преступление : {Crime}");
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

    class CrimeDatabase
    {
        private List<string> _crimeTypes;
        private Random _random;

        public CrimeDatabase()
        {
            _crimeTypes = new List<string>();
            _random=new Random();
            Create();
        }

        public string ReturnCrime()
        {
            int crimeTypeIndex = _random.Next(_crimeTypes.Count);
            return _crimeTypes[crimeTypeIndex];
        }

        private void Create()
        {
            _crimeTypes.Add("Убийство");
            _crimeTypes.Add("Кража");
            _crimeTypes.Add("Грабёж");
            _crimeTypes.Add("Разбой");
            _crimeTypes.Add("Хулиганство");
            _crimeTypes.Add("Антиправительственное");
            _crimeTypes.Add("Терроризм");
            _crimeTypes.Add("Мошенничество");
        }
    }
}
