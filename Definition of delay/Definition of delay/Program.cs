using System;
using System.Collections.Generic;

namespace Definition_of_delay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Warehous
    {
        private List<Eat> _eat;

        public Warehous()
        {
            _eat = new List<Eat>();
        }

        private void CreateEat()
        {           
            CreateHandler(10, "Суровая тушонка", 40);
            CreateHandler(7, "Деревенская", 14);
        }

        private void CreateHandler(int eatCount, string eatName, int expirationTime)
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
        public int ExpirationTime { get;private set; }

        public Eat(string name, int expirationTime)
        {
            _random = new Random();
            _name = name;
            ExpirationTime = expirationTime;
            CreateYearProduction();
        }

        private void CreateYearProduction()
        {
            int minYearCount = 1920;
            int maxYearCount = 1999;

            YearProduction = _random.Next(minYearCount, maxYearCount);
        }
    }

    class NameDatabase
    {
        private List<string> _names;
        private Random _random;

        public NameDatabase()
        {
            _random = new Random();
            _names = new List<string>();
        }

        public void ReturnName()
        {

        }

        private void Create()
        {
            _names.Add("Cуровая");
        }
    }

    //Есть набор тушенки.У тушенки есть название, год производства и срок годности.
    // Написать запрос для получения всех просроченных банок тушенки.
    //Чтобы не заморачиваться, можете думать, что считаем только года, без месяцев.
}
