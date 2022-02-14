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
            detective.Work();
        }
    }

    class Detective
    {
        private List<Offender> _offenders;
        private bool _isWork;
        private int _requestedWeight;
        private int _requestedHeight;
        private int _requestedAge;
        private int _maxOffenders;

        public Detective()
        {
            _maxOffenders = 10000;
            _offenders = new List<Offender>();
            _isWork = true;
            CreateOffenders(_maxOffenders);         
        }

        public void Work()
        {
            while (_isWork)
            {
                
                Console.WriteLine($"Добро пожаловать в вашей базе данных {_offenders.Count} человек");
                Console.WriteLine($"======\n1: Показать всех\n2: Найти человека по 3 параметрам\n3: Найти человека по 1 параметру\n4: Выход");

                switch (Console.ReadLine())
                {
                    case "1":
                        foreach (var offender in _offenders)
                            offender.ShowInfo();
                        break;
                    case "2":
                        FindOffendersThreeParameters();                      
                        break;
                    case "3":
                        FindOffendersOneParameter();
                        break;
                    case "4":
                        _isWork = false;
                        break;
                }
                Console.WriteLine("Для продолжения нажмите кнопку");
                Console.ReadKey();
                Console.Clear();
            }
        }
          
        private void FindOffendersOneParameter()
        {
            string userInput;
            Console.WriteLine($"1: Найти по имени\n2: Найти по национальности\n3: Найти по росту\n4: Найти по весу\n5: Найти по возрасту");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Введите имя");
                    userInput = Console.ReadLine();
                    var foundByName = _offenders.Where(offender => offender.Name == userInput && offender.IsArrested == false);

                    foreach (var offender in foundByName)
                        offender.ShowInfo();
                    break;
                case "2":
                    Console.WriteLine("Введите национальность");
                    userInput = Console.ReadLine();
                    var foundByNationality = _offenders.Where(offender => offender.Nationality == userInput && offender.IsArrested == false);

                    foreach (var offender in foundByNationality)
                        offender.ShowInfo();
                    break;
                case "3":
                    Console.WriteLine("Введите рост");
                    userInput = Console.ReadLine();
                    if (Int32.TryParse(userInput, out int valueHeight))
                    {
                        var foundByHeight = _offenders.Where(offender => offender.Height == valueHeight && offender.IsArrested == false);

                        foreach (var offender in foundByHeight)
                            offender.ShowInfo();
                    }
                    else
                        Console.WriteLine("Ошибка");
                    break;
                case "4":
                    Console.WriteLine("Введите Вес");
                    userInput = Console.ReadLine();
                    if (Int32.TryParse(userInput, out int valueWeight))
                    {
                        var foundByWeight = _offenders.Where(offender => offender.Height == valueWeight && offender.IsArrested == false);

                        foreach (var offender in foundByWeight)
                            offender.ShowInfo();
                    }
                    else
                        Console.WriteLine("Ошибка");
                    break;
                case "5":
                    Console.WriteLine("Введите Возраст");
                    userInput = Console.ReadLine();
                    if (Int32.TryParse(userInput, out int valueAge))
                    {
                        var foundByAge = _offenders.Where(offender => offender.Height == valueAge && offender.IsArrested == false);

                        foreach (var offender in foundByAge)
                            offender.ShowInfo();
                    }
                    else
                        Console.WriteLine("Ошибка");
                    break;
            }
        }
        
        private void FindOffendersThreeParameters()
        {       
            Console.WriteLine("Укажите рост");
            SortHandler(out _requestedHeight);

            Console.WriteLine("Укажите вес");
            SortHandler(out _requestedWeight);

            Console.WriteLine("Укажите возраст");
            SortHandler(out _requestedAge);

            var result = _offenders.Where(offendr => offendr.Height == _requestedHeight && offendr.Weight == _requestedWeight && offendr.Age == _requestedAge && offendr.IsArrested == false);
            if (result.Count() > 0)
            {
                foreach (var offender in result)
                    offender.ShowInfo();
            }

            else
                Console.WriteLine("Человек с такими параметрами не найден");
        }

        private void SortHandler(out int valueType )
        {
            string userInput = Console.ReadLine();
            if(Int32.TryParse(userInput,out valueType))           
                Console.WriteLine("Значиение принято");
            else { SortHandler(out valueType); }
            
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

        public string Name { get; private set; }
        public string Nationality { get; private set; }
        public int Age { get; private set; }
        public int Weight { get; private set; }
        public int Height { get; private set; }
        public bool IsArrested { get; private set; }

        public Offender()
        {
            _nameDatabase = new NameDatabase();
            _nationalityDatabase = new NationalityDatabase();
            _random = new Random();
            ArrestedHandler();
            Create();
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} , {Nationality} , рост: {Height} , вес: {Weight} , возраст {Age} , находится под стражей {IsArrested}");
        }

        private void Create()
        {
            int minAgeValue = 14;
            int maxAgeValue = 70;
            Age = _random.Next(minAgeValue, maxAgeValue);

            int minWeightValue = 50;
            int maxWeightValue = 170;
            Weight = _random.Next(minWeightValue, maxWeightValue);

            int minHeightValue = 140;
            int maxHeightValue = 220;
            Height = _random.Next(minHeightValue, maxHeightValue);

            Name = _nameDatabase.ReturnName();
            Nationality = _nationalityDatabase.ReturnNationality();
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
