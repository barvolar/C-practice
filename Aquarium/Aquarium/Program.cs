using System;
using System.Collections.Generic;

namespace Aquarium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Aquarium aquarium = new Aquarium();
            aquarium.ShowMenu();
        }
    }

    class Aquarium
    {
        private List<Fish> _fish;
        private int _maxAgeFish;
        private int _maxFishCount;
        private int _fishNumber;
        private bool _isWork;

        public Aquarium()
        {
            _fish = new List<Fish>();
            _isWork = true;
            _maxAgeFish = 70;
            _maxFishCount = 10;
            _fishNumber = 1;
        }

        public void ShowMenu()
        {
            while (_isWork)
            {
                ShowInfo();
                Console.WriteLine("1 - Добавить рыбку\n2 - Убрать рыбку\n3 - Ничего не делать\n4 - Выход");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddFish();
                        break;

                    case "2":
                        RemoveFish();
                        break;

                    case "4":
                        _isWork = false;
                        break;

                    case "3":
                    default:
                        break;

                }
                Console.WriteLine("Для продолжения нажмите любую кнопку");
                Console.ReadKey();
                SkipTime();
                Console.Clear();
            }
        }

        private void SkipTime()
        {
            for (int i = 0; i < _fish.Count; i++)
            {
                _fish[i].IncreasingAge();
                if (_fish[i].Age > _maxAgeFish)
                    _fish.RemoveAt(i);
            }
        }

        private void AddFish()
        {
            if (_fish.Count <= _maxFishCount)
            {
                _fish.Add(new Fish(_fishNumber));
                _fishNumber++;
                Console.WriteLine("Рыбка добавлена");
            }

            else
            {
                Console.WriteLine("В аквариуме нету места");
            }
        }

        private void RemoveFish()
        {
            int tempFishCount = _fish.Count;
            Console.WriteLine("Укажите номер рыбки");

            if (Int32.TryParse(Console.ReadLine(), out int valueInput))
            {
                for (int i = 0; i < _fish.Count; i++)
                {
                    if (_fish[i].FishNumber == valueInput)
                    {
                        _fish.RemoveAt(i);
                    }
                }

                if (tempFishCount == _fish.Count)
                {
                    Console.WriteLine("Рыбка с таким номером не найдена");
                }

                else
                {
                    Console.WriteLine("Рыбка удалена");
                }
            }

            else
            {
                Console.WriteLine("Ошибка");
            }

        }

        private void ShowInfo()
        {
            for (int i = 0; i < _fish.Count; i++)
            {
                _fish[i].ShowInfo();
            }

            Console.WriteLine($"Количество рыб в аквариуме - {_fish.Count}");
        }
    }

    class Fish
    {
        private Random _random;
        private int _minAge;
        private int _maxAge;

        public int FishNumber { get; private set; }

        public int Age { get; private set; }

        public Fish(int fishNumber)
        {
            _random = new Random();
            _minAge = 1;
            _maxAge = 7;
            Age = _random.Next(_minAge, _maxAge);
            AssignFishNumber(fishNumber);
        }

        public void IncreasingAge()
        {
            Age++;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Житель аквариума № {FishNumber} возраст рыбки - {Age}");
        }

        private void AssignFishNumber(int value)
        {
            FishNumber = value;
        }
    }
}
