using System;
using System.Collections.Generic;

namespace SuperMarket1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            shop.Work();
        }
    }

    class Shop
    {
        private List<Product> _products;
        private List<Human> _humans;
        private int _gain;

        public Shop()
        {
            _humans = new List<Human>();
            _products = new List<Product>();
            _gain = 0;
            CreateProducts();
            CreateHumans();
        }

        public void Work()
        {
            foreach (var human in _humans)
            {
                human.EditBag();
                human.ShowInfo();
                _gain += human.SumProducts;               
            }

            Console.WriteLine($"Людей в очереди {_humans.Count}\n Всего заработали {_gain}");
        }

        private void CreateHumans()
        {
            Console.WriteLine("skolko 4elovek v o4eredi?");

            if (Int32.TryParse(Console.ReadLine(), out int humansCount))
            {
                for (int i = 0; i < humansCount; i++)
                {
                    _humans.Add(new Human(_products));
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода , в очереди 1 человек");
                _humans.Add(new Human(_products));
            }
        }

        private void CreateProducts()
        {
            _products.Add(new Product("moloko", 2));
            _products.Add(new Product("tee", 5));
            _products.Add(new Product("apple", 7));
            _products.Add(new Product("шоколад", 6));
            _products.Add(new Product("вода", 1));
            _products.Add(new Product("водка", 10));
            _products.Add(new Product("ручка", 15));
        }
    }

    class Human
    {
        private Random _random;
        private List<Product> _bag;
        private int _money;

        public int SumProducts { get; private set; }

        public Human(List<Product> products)
        {
            _bag = new List<Product>();
            _random = new Random();

            CreateMoney();
            CreateBag(products);
        }

        public void EditBag()
        {
            while(_money < SumProducts)
            {
                DropProduct();
                CreateSumProduct();
            }
        }

        public void ShowInfo()

        {
            Console.WriteLine("Деньги === " + _money);
            Console.WriteLine("Стоимость корзины === " + SumProducts);           

            foreach (var product in _bag)
            {
                product.ShowInfo();
            }
        }

        private void CreateMoney()
        {
            int maxMoney = 50;
            _money = _random.Next(maxMoney);
        }

        private void CreateBag(List<Product> products)
        {
            int maxBagSize = 20;
            int bagSize = _random.Next(maxBagSize);

            for (int i = 0; i < bagSize; i++)
            {
                _bag.Add(products[_random.Next(products.Count)]);
            }

            CreateSumProduct();
        }

        private void DropProduct()
        {
            _bag.RemoveAt(_random.Next(_bag.Count));
        }

        private void CreateSumProduct()
        {
            SumProducts = 0;

            for (int i = 0; i < _bag.Count; i++)
            {
                SumProducts += _bag[i].Price;
            }         
        }        
    }
 
    class Product
    {
        private string _name;

        public int Price { get; private set; }

        public Product(string name, int price)
        {
            _name = name;
            Price = price;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"name = {_name}. price = {Price}");
        }
    }
}
