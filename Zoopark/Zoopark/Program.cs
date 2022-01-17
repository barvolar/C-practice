using System;
using System.Collections.Generic;

namespace Zoopark
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            Zoopark zoopark = new Zoopark();
            zoopark.ShowMenu();
        }
    }

    class Zoopark
    {
        private List<Animal> _lionCage;
        private List<Animal> _wolfCage;
        private List<Animal> _foxCage;
        private List<Animal> _epephantCage;
        private bool _isWork;
       
        public Zoopark()
        {          
            _lionCage = CreateCage(7, new Lion(true), 6, new Lion(false));
            _wolfCage = CreateCage(10, new Wolf(true),3,new Wolf(false));
            _foxCage = CreateCage(2, new Fox(true), 4, new Fox(false));
            _epephantCage = CreateCage(1, new Elephant(true), 1, new Elephant(false));
            _isWork = true;          
        }


        public void ShowMenu()
        {
            while (_isWork)
            {
                Console.WriteLine($"Добро пожаловать в зоопарк! Выбирайте куда отправимся\n1 - Посмотрим на львов\n2 - Посмотрим на волков\n3 - Посмотрим на лис\n4 - Посмотрим на слонов\n5 уйти домой");
                switch (Console.ReadLine())
                {
                    case "1":
                        ShowInfo(_lionCage);
                        break;
                    case "2":
                        ShowInfo(_wolfCage);
                        break;
                    case "3":
                        ShowInfo(_foxCage);
                        break;
                        
                    case "4":
                        ShowInfo(_epephantCage);
                        break;
                    case "5":
                        _isWork = false;
                        break;
                    default:
                        Console.WriteLine("такой вальер не найден");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }            
        }

        private void ShowInfo(List<Animal> animals)
        {
            Console.WriteLine($"В вальере находется {animals[0].Type} в количестве - {animals.Count}");

            foreach (var animal in animals)
            {
                animal.ShowInfo();
            }
        }

        private List<Animal> CreateCage(int maleGendorCount, Animal animalMaleType, int famaleGenderCount, Animal animalsFamaleType)
        {
            List<Animal> animals = new List<Animal>();

            for (int i = 0; i < maleGendorCount; i++)
                animals.Add(animalMaleType);


            for (int i = 0; i < famaleGenderCount; i++)
                animals.Add(animalsFamaleType);

            return animals;
        }
    }

    class Animal
    {
        protected string Name;
        protected string Voice;
        protected string Gender;

        public string Type { get; protected set; }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"{Name}, {Gender}, издаёт звук {Voice}");
        }
    }

    class Lion : Animal
    {     
        public Lion(bool isMaleGender)
        {
            Type = "Львы";           
            Create(isMaleGender);
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
        }

        private void Create(bool isMaleGender)
        {
            if (isMaleGender)
            {
                Name = "Лев";
                Voice = "Мужыцки львины рык";
                Gender = "Самец";
            }
            else
            {
                Name = "Львица";
                Voice = "Рык самки льва";
                Gender = "Самка";
            }
        }
    }

    class Wolf : Animal
    {
        public Wolf(bool isMaleGender)
        {
            Type = "Волки";
            Create(isMaleGender);
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
        }

        private void Create(bool isMaleGender)
        {
            if (isMaleGender)
            {
                Name = "Волк";
                Voice = "Ауфф самца";
                Gender = "Самец";
            }
            else
            {
                Name = "Львица";
                Voice = "*Воет как самка волка*";
                Gender = "Самка";
            }
        }
    }

    class Fox : Animal
    {
        public Fox(bool isMaleGender)
        {
            Type = "Лисы";
            Create(isMaleGender);
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
        }

        private void Create(bool isMaleGender)
        {
            if (isMaleGender)
            {
                Name = "Лис";
                Voice = "*Рев лИса*";
                Gender = "Самец";
            }
            else
            {
                Name = "Лиса";
                Voice = "*фур фур фур*";
                Gender = "Самка";
            }
        }
    }

    class Elephant : Animal
    {
        public Elephant(bool isMaleGender)
        {
            Type = "Слоны";
            Create(isMaleGender);
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
        }

        private void Create(bool isMaleGender)
        {
            if (isMaleGender)
            {
                Name = "Слон";
                Voice = "*Ор мужыцкого слона*";
                Gender = "Самец";
            }
            else
            {
                Name = "Слониха";
                Voice = "*Ор слонихи*";
                Gender = "Самка";
            }
        }
    }
}
