using System;
using System.Collections.Generic;
using System.Linq;

namespace Definition_of_delay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Warehous warehous = new Warehous();
            warehous.ShowAllEat();
            warehous.ShowSuitableEat(warehous.CheckExpirationDate());
        }
    }

    class Warehous
    {
        private List<Eat> _eat;
        private int _currentYear;

        public Warehous()
        {
            _eat = new List<Eat>();
            CreateEat();
        }

        public void ShowAllEat()
        {
            Console.WriteLine("Вся имеющаяся еда");
            foreach (var eat in _eat)
                eat.ShowInfo();
        }

        public List<Eat> CheckExpirationDate()
        {           
            var suitableEat = _eat.Where(eat => eat.ExpirationDate + eat.YearProduction <= _currentYear).ToList();
            return suitableEat;
        }

        public void ShowSuitableEat(List<Eat> list)
        {
            Console.WriteLine("Пригодная для употребления еда");

            foreach (var eat in list)
            {
                Console.Write($"Осталось {_currentYear - (eat.ExpirationDate + eat.YearProduction)} лет до истечения срока годности.  ");
                eat.ShowInfo();
            }
        }

        private void CreateEat()
        {           
            AddEatToList(10, "Суровая", 40);
            AddEatToList(7, "Деревенская", 14);
            AddEatToList(16, "Элитная", 42);
        }

        private void AddEatToList(int eatCount, string eatName, int expirationTime)
        {
            for (int i = 0; i < eatCount; i++)
            {
                _eat.Add(new Eat(eatName, expirationTime));
            }
        }
    }

    class Eat
    {
        private string _name;
        private Random _random;

        public int YearProduction { get;private set; }
        public int ExpirationDate { get;private set; }

        public Eat(string name, int expirationTime)
        {
            _random = new Random();
            _name = name;
            ExpirationDate = expirationTime;
            CreateYearProduction();
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Тушонка '{_name}' , срок годности {ExpirationDate} , сделана в {YearProduction} году");
        }

        private void CreateYearProduction()
        {
            int minYearCount = 1920;
            int maxYearCount = 1999;

            YearProduction = _random.Next(minYearCount, maxYearCount);
        }
    }    
}
