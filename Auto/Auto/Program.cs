using System;
using System.Collections.Generic;

namespace Auto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<Component> list = new List<Component>();
            //for (int i = 0; i < 10; i++)
            //{
            //    list.Add(new Component());
                
            //}

            STO sto = new STO();
          
        }
    }

    class STO
    {
        private List<Component> _components;
        
        private int _money;
        private int maxComponents;
        private Random _random;

        public STO()
        {   
            _random = new Random();
            _components = new List<Component>();
            _money = 0;
            maxComponents = 30;
            CreateComponents();
        }

        //public void Show()
        //{
        //    foreach (var item in _components)
        //    {
        //        Console.WriteLine(item.Name);
        //    }
        //}

        private void CreateComponents()
        {
            AllComponents allComponents = new AllComponents();
            List<Component> list = new List<Component>();
            list = allComponents.ReturnComponents();

            for (int i = 0; i < maxComponents; i++)
            {
                _components.Add(list[_random.Next(list.Count)]);
            }
        }      
    }

    class Car
    {
        
        private List <Component> _components;
        private int _money;
        private Random _random;

        public Car()
        {          
            _random = new Random();
            _components = Create();
            CreateMoney();
        }

        public List<Component> Repair()
        {
            return _components;
        }

        private List<Component> Create()
        {
            List<Component> list = new List<Component>()
            {
                new Component("двигатель", 300),
                new Component("каробка передач", 100),
                new Component("свечи", 30),
                new Component("аккумулятор", 55),
                new Component("подвеска", 130),
                new Component("двери", 70),
            };

            return list;
        }

        private void CreateMoney()
        {
            int maxMoney = 700;
            _money = _random.Next(maxMoney);
        }
    }

    class Component
    {
        private Random _random;

        public string Name { get; private set; }
        public int Price { get;private set; }
        public bool IsBroken { get; private set; }

        public Component(string name, int price)
        {
            _random = new Random();
            Name = name;
            Price = price;
            Create();
        }

        public Component()
        {
            _random = new Random();
            Create();
            Console.WriteLine(IsBroken);
        }

        public void Repair()
        {
            IsBroken = false;
        }

        private void Create()
        {
            int brokenIndex = 1;
            int maxIndex = 2;
            if(_random.Next(maxIndex) == brokenIndex)
            {
                IsBroken = true;
            }
            else
            {
                IsBroken = false;
            }
        }
    }

    class AllComponents
    {
        private List<Component> _components;

        public AllComponents()
        {
            _components = Create();
        }

        public List<Component> ReturnComponents()
        {
            return _components;
        }

        private List<Component> Create()
        {
            List<Component> list = new List<Component>()
            {
                new Component("двигатель", 300),
                new Component("каробка передач", 100),
                new Component("свечи", 30),
                new Component("аккумулятор", 55),
                new Component("подвеска", 130),
                new Component("двери", 70),
            };

            return list;
        }
    }

}
