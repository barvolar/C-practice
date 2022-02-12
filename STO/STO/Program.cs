using System;
using System.Collections.Generic;

namespace STO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Workshop workshop = new Workshop();
            workshop.Work();
        }

        class Workshop
        {
            private List<Component> _components;
            private Queue<Car> _cars;
            private Random _random;
            private int _money;
            private int _numberClient;
         
            public Workshop()
            {         
                _money = 0;
                _numberClient = 0;
                _random = new Random();
                _components = new List<Component>();
                CreateComponents();
                _cars = new Queue<Car>();
                CreateCars();
            }

            public void Work()
            {
                while (_cars.Count > 0)
                {
                    Car car = _cars.Dequeue();
                    _numberClient++;

                    while (car.CheckDefect())
                    {
                        Console.Clear();
                        Console.WriteLine("Клиент номер - " + _numberClient);
                        Console.WriteLine($"Количество клиентов - {_cars.Count}\nЗаработано денег - {_money}");

                        car.ShowInfo();

                        Console.WriteLine("====================\nВведите название детали для ремонат \nДля завершения работы введите Exit\nДля отказа клиенту введите Next");

                        Component componentForRepair = null;
                        string inputUser = Console.ReadLine();

                        if (inputUser == "Next")
                        {
                            Console.WriteLine("Вы отказали клиенту и вам пришлось заплатить компенсацию");
                            _money -= car.CalculatePenalty();
                            break;
                        }

                        if (inputUser == "Exit")
                        {
                            _cars.Clear();
                            break;
                        }


                        if (car.CheckComponentDefect(inputUser))
                        {                         
                            RepairHandler(inputUser, car, componentForRepair);
                        }

                        else
                            Console.WriteLine("Этот компонент не повреждён");

                        Console.Clear();
                    }
                }              
                Console.WriteLine($"Сегодня вы обслужили {_numberClient} клиентов и заработали {_money}");
            }

            private void RepairHandler(string nameComponent, Car car, Component component)
            {
                if (car.CheckComponentDefect(nameComponent))
                {
                    for (int i = 0; i < _components.Count; i++)
                    {
                        if (nameComponent == _components[i].Name)
                        {
                            component = _components[i];
                            _money += car.Repair(component);
                            _components.RemoveAt(i);
                            Console.WriteLine("Успешный ремонт");
                            break;
                        }

                        if (component == null)
                        {
                            Console.WriteLine("У вас нет такой детали");
                        }

                        component = null;
                    }

                    Console.ReadKey();
                    Console.Clear();
                }
            }

            private void CreateCars()
            {
                int maxCarsValue = 50;
                int carsValue = _random.Next(maxCarsValue);

                for (int i = 0; i < carsValue; i++)
                {
                    _cars.Enqueue(new Car());
                }
            }
           
            private void CreateComponents()
            {
                AllComponents allComponents = new AllComponents();
                List<Component> tempComponents = allComponents.CreateComponents();

                int maxComponents = 40;

                for (int i = 0; i < maxComponents; i++)
                {
                    _components.Add(tempComponents[_random.Next(tempComponents.Count)]);
                    _components[i].Repair();
                }
            }
        }

        class Car
        {
            private List<Component> _carComponents;
            private AllComponents _allComponents;
            private int _repairsPrice;
            private Random _random;

            public Car()
            {
                _random = new Random();
                _allComponents = new AllComponents();
                _carComponents = _allComponents.CreateComponents();
                CreateRepairsPrice();
            }

            public int CalculatePenalty()
            {
                int penaltyCount = 0;

                foreach (var component in _carComponents)
                {
                    if (component.Defect)
                        penaltyCount += component.Price;
                }

                return penaltyCount;
            }

            public bool CheckComponentDefect(string name)
            {
                bool isDefect = false;

                foreach (var component in _carComponents)
                {
                    if (component.Name == name)
                    {
                        if (component.Defect == true)
                            isDefect = true;
                        break;
                    }
                }

                return isDefect;
            }

            public int Repair(Component component)
            {
                int repairPrice = 0;

                for (int i = 0; i < _carComponents.Count; i++)
                {
                    if (component.Name == _carComponents[i].Name && _carComponents[i].Defect)
                    {
                        repairPrice = _repairsPrice + component.Price;
                        _carComponents[i] = component;

                    }
                }

                return repairPrice;
            }

            public void ShowInfo()
            {
                Console.WriteLine($"======\nЦена починки автомобиля {_repairsPrice}\nСостояние деталей:");

                foreach (var component in _carComponents)
                {
                    component.ShowInfo();
                }
            }

            public bool CheckDefect()
            {
                bool isDefect = false;

                foreach (var component in _carComponents)
                    if (component.Defect)
                        isDefect = true;

                return isDefect;
            }

            private void CreateRepairsPrice()
            {
                int maxRepairsPrice = 900;
                _repairsPrice = _random.Next(maxRepairsPrice);
            }
        }

        class AllComponents
        {

            public List<Component> CreateComponents()
            {
                List<Component> components = new List<Component>();

                components.Add(new Component("двигатель", 300));
                components.Add(new Component("трансмиссия", 200));
                components.Add(new Component("тормоза", 130));
                components.Add(new Component("подвеска", 100));
                components.Add(new Component("бампер", 50));
                components.Add(new Component("колесо", 35));
                components.Add(new Component("стекло", 15));

                return components;
            }
        }

        class Component
        {
            private Random _random;

            public bool Defect { get; private set; }
            public int Price { get; private set; }
            public string Name { get; private set; }

            public Component(string name, int price)
            {
                Name = name;
                Price = price;
                Create();
            }
        
            public void Repair()
            {
                Defect = false;
            }

            public void ShowInfo()
            {
                Console.WriteLine($"{Name} стоимость: {Price}, поломка: {Defect}");
            }

            private void Create()
            {
                _random = new Random();
                int defectChanceValue = 1;
                int maxValue = 3;
                Defect = defectChanceValue == _random.Next(maxValue);
            }
        }
    }
}
