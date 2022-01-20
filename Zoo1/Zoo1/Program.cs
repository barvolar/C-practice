using System;
using System.Collections.Generic;

namespace Zoo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();           
            zoo.Work();
        }
    }

    class Zoo
    {
        private List<Cage> _cage;
        private Random _random;
        private bool _isWork;
        private bool _isVisitCage;

        public Zoo()
        {
            _random = new Random();
            _isWork = true;
            _isVisitCage = false;
            _cage = Create();
        }

        public void Work()
        {
            while (_isWork)
            {
                if (_cage.Count > 0)
                {                   
                    ShowStartMenu();

                    switch (Console.ReadLine())
                    {
                        case "1":
                            _isVisitCage = true;

                            while (_isVisitCage)
                            {
                                ShowCage();

                                Console.WriteLine("Выберите клетку - что бы рассмотреть поближе, для выхода возвращения к выходу введите Exit");

                                HandlerUserInput();

                                Console.ReadKey();
                            }
                            break;
                        case "2":
                            _isWork = false;
                            break;                   
                    }
                }

                else
                {
                    Console.WriteLine($"Закрыто!!!");
                }
            }
        }

        private void HandlerUserInput()
        {           
            string userInput = Console.ReadLine();

            if (Int32.TryParse(userInput, out int numberCage) && numberCage > 0 && numberCage <= _cage.Count)
            {
                _cage[numberCage - 1].ShowInfo();
            }
            else if (userInput == "Exit")
            {
                _isVisitCage = false;
            }
            else
            {
                Console.WriteLine("Что-то не то");
            }
        }

        private void ShowCage()
        {
            Console.Clear();

            for (int i = 0; i < _cage.Count; i++)
            {
                Console.WriteLine($"{i+1} - Количество зверей {_cage[i].CageSize}");
            }          
        }

        private void ShowStartMenu()
        {
            Console.WriteLine($"Добро пожаловать в зоопарк , сегодня у нас {_cage.Count} вальера(ов)");
            Console.WriteLine("1 - Посмотреть на зверей\n2 - Уйти");
        }

        private List<Cage> Create()
        {
            List<Cage> allCage = new List<Cage>()
            {
                new Cage(new Lion(true), new Lion(false)),
                new Cage(new Wolf(true), new Wolf(false)),
                new Cage(new Fox(true), new Fox(false)),
                new Cage(new Elephant(true), new Elephant(false)),
                new Cage(new Bear(true), new Bear(false)),
                new Cage(new Monkey(true), new Monkey(false))
            };
            List<Cage> returnedCage = new List<Cage>();

            int maxCageCount = 10;
            int cageCount = _random.Next(maxCageCount);

            for (int i = 0; i < cageCount; i++)
            {
                returnedCage.Add(allCage[_random.Next(allCage.Count)]);
            }

            return returnedCage;
        }
    }

    class Cage
    {
        private List<Animal> _animals;
        private Random _random;
        public int CageSize { get; private set; }
        
        public Cage(Animal maleAnimalType, Animal famaleAnimalType)
        {
            _random = new Random();
            _animals = Create(maleAnimalType, famaleAnimalType);
        }

        public void ShowInfo()
        {
            if (_animals.Count > 0)
            {
                Console.WriteLine($"В вальере {CageSize} зверей типа {_animals[0].Type}\n");

                foreach (var animal in _animals)
                {
                    animal.ShowInfo();
                }
            }
            else
                Console.WriteLine("Пустой вальер");

            Console.WriteLine("-------------");
        }

        private List<Animal> Create(Animal maleAnimalType, Animal famaleAnimalType)
        {
            int maxSizeCage = 10;
            int genderCount = 2;
            int maleGenderValue = 1;
            int genderCreatedAnimal;

            CageSize = _random.Next(maxSizeCage);
            List<Animal> animals = new List<Animal>();

            for (int i = 0; i < CageSize; i++)
            {
                genderCreatedAnimal = _random.Next(genderCount);

                if (genderCreatedAnimal == maleGenderValue)
                {
                    animals.Add(maleAnimalType);
                }
                else
                {
                    animals.Add(famaleAnimalType);
                }
            }

            return animals;
        }
    }

    class Animal
    {
        protected string Name;
        protected string Voice;
        protected string Gendor;

        public string Type { get; protected set; }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"{Name} , {Gendor} , издаёт звук {Voice}");
        }
    }

    class Lion : Animal
    {
        public Lion(bool isMaleGendor)
        {
            Type = "Львы";
            Create(isMaleGendor);
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
        }

        private void Create(bool isMaleGendor)
        {
            if (isMaleGendor)
            {
                Name = "Лев";
                Voice = "Рык льва";
                Gendor = "Самец";
            }
            else
            {
                Name = "Львица";
                Voice = "Рык львицы";
                Gendor = "Самка";
            }
        }
    }

    class Wolf : Animal
    {
        public Wolf(bool isMaleGendor)
        {
            Type = "Волки";
            Create(isMaleGendor);
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
        }

        private void Create(bool isMaleGendor)
        {
            if (isMaleGendor)
            {
                Name = "Волк";
                Voice = "Ауфф Самца";
                Gendor = "Самец";
            }
            else
            {
                Name = "Волчица";
                Voice = "Ауфф самки";
                Gendor = "Самка";
            }
        }
    }

    class Fox : Animal
    {
        public Fox(bool isMaleGendor)
        {
            Type = "Лисы";
            Create(isMaleGendor);
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
        }

        private void Create(bool isMaleGendor)
        {
            if (isMaleGendor)
            {
                Name = "Лис";
                Voice = "Фыр фыр фыр самца";
                Gendor = "Самец";
            }
            else
            {
                Name = "Лисица";
                Voice = "Фыр фыр фыр самки";
                Gendor = "Самка";
            }
        }
    }

    class Elephant : Animal
    {
        public Elephant(bool isMaleGendor)
        {
            Type = "Слоны";
            Create(isMaleGendor);
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
        }

        private void Create(bool isMaleGendor)
        {
            if (isMaleGendor)
            {
                Name = "Cлон";
                Voice = "*Что-то на слоновьем*";
                Gendor = "Самец";
            }
            else
            {
                Name = "Слониха";
                Voice = "*Что-то на слоновьем*";
                Gendor = "Самка";
            }
        }
    }

    class Bear : Animal
    {
        public Bear(bool isMaleGendor)
        {
            Type = "Медведи";
            Create(isMaleGendor);
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
        }

        private void Create(bool isMaleGendor)
        {
            if (isMaleGendor)
            {
                Name = "Медведь";
                Voice = "Рык медведя";
                Gendor = "Самец";
            }
            else
            {
                Name = "Медведица";
                Voice = "Рык медведицы";
                Gendor = "Самка";
            }
        }
    }

    class Monkey : Animal
    {
        public Monkey(bool isMaleGendor)
        {
            Type = "Обезьяны";
            Create(isMaleGendor);
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
        }

        private void Create(bool isMaleGendor)
        {
            if (isMaleGendor)
            {
                Name = "Обезьян";
                Voice = "А о у а у а о";
                Gendor = "Самец";
            }
            else
            {
                Name = "Обезяна";
                Voice = "У а э о а у";
                Gendor = "Самка";
            }
        }
    }
}
