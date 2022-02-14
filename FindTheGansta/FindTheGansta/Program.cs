using System;
using System.Collections.Generic;
using System.Linq;

namespace FindTheGansta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Detective detective = new Detective();
            //detective.Work();
        }
    }

    class Detective
    {
        private List<Offender> _offenders;
        private bool _isWork;
        private int _requestedWeight;
        private int _requestedHeight;
        private int _requestedAge;

        public Detective()
        {
            _offenders = new List<Offender>();
            _isWork = true;
            CreateOffenders(500);
            //int input = Convert.ToInt32(Console.ReadLine());
            string nameinput = Console.ReadLine();
            var resul = _offenders.Where(offender => offender.Name==nameinput);
            foreach (var offender in resul)
                offender.ShowInfo();
        }

        public void Work()
        {
            while (_isWork)
            {
                Console.WriteLine($"Добро пожаловать в вашей базе данных {_offenders.Count} человек");
                Console.WriteLine($"======\n1: Показать всех\n2: Добавить фильтр\n3: Выход");

                switch (Console.ReadLine())
                {
                    case "1":
                        foreach (var offender in _offenders)
                            offender.ShowInfo();
                        break;
                    case "2":
                        Sort();
                        var result = _offenders.Where(offendr => offendr.Height == _requestedHeight /*&& offendr.Weight==_requestedWeight&&offendr.Age==_requestedAge*/);
                        foreach (var offender in result)
                            offender.ShowInfo();

                        Console.WriteLine(result.Count());
                        break;
                    case "3":
                        _isWork = false;
                        break;
                }
            }
        }

        private void SortHandler(out int valueType )
        {
            string userInput = Console.ReadLine();
            if(Int32.TryParse(userInput,out valueType))           
                Console.WriteLine("Значиение принято");
            else { userInput = Console.ReadLine(); }
            
        }

        private void Sort()
        {       
            Console.WriteLine("Укажите рост");
            SortHandler(out _requestedHeight);

            Console.WriteLine("Укажите вес");
            SortHandler(out _requestedWeight);

            Console.WriteLine("Укажите возраст");
            SortHandler(out _requestedAge);
        }

        private void CreateOffenders(int maxOffendersCount)
        {
            for (int i = 0; i < maxOffendersCount; i++)
            {
                _offenders.Add(new Offender());
            }
        }
    }

    class Offender
    {
        private NameDatabase _nameDatabase;
        private NationalityDatabase _nationalityDatabase;
        private Random _random;

        public string Name { get => _nameDatabase.ReturnName(); }
        public string Nationality { get => _nationalityDatabase.ReturnNationality(); }
        public int Age { get => Create(14, 70); }
        public int Weight { get => Create(40, 170); }
        public int Height { get => Create(140, 220); }
        public bool IsArrested { get; private set; }



        public Offender()
        {
            _nameDatabase = new NameDatabase();
            _nationalityDatabase = new NationalityDatabase();
            _random = new Random();
            ArrestedHandler();
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} , {Nationality} , рост: {Height} , вес: {Weight} , возраст {Age} , находится под стражей {IsArrested}");
        }

        private void ArrestedHandler()
        {
            int arrestedIndex = 3;
            int maxIndex = 4;
            if (_random.Next(maxIndex) == arrestedIndex)
                IsArrested = true;
            else
                IsArrested = false;
        }

        private int Create(int minValue, int maxValue)
        {
            int result = _random.Next(minValue, maxValue);
            return result;
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

    class NationalityDatabase
    {
        private List<string> _nationalities;
        private Random _random;

        public NationalityDatabase()
        {
            _random = new Random();
            _nationalities = new List<string>();
            Create();
        }

        public string ReturnNationality()
        {
            int nationalityIndex = _random.Next(_nationalities.Count);
            return _nationalities[nationalityIndex];
        }

        private void Create()
        {
            _nationalities.Add("Беларус");
            _nationalities.Add("Русский");
            _nationalities.Add("Украинец");
            _nationalities.Add("Эстонец");
            _nationalities.Add("Француз");
        }
    }

    //У нас есть список всех преступников.
    //В преступнике есть поля: ФИО, заключен ли он под стражу, рост, вес, национальность.
    //Вашей программой будут пользоваться детективы.
    //У детектива запрашиваются данные(рост, вес, национальность), и детективу выводятся все преступники, которые подходят под эти параметры, но уже заключенные под стражу выводиться не должны.
}
