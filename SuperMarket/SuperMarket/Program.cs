using System;
using System.Collections.Generic;

namespace SuperMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();           
            shop.SellProducts();
        }
    }

    class Shop
    {
        private List<Product> _allProducts;
        private Queue<Human> _queue;
        private int _shopMoney;

        public Shop()
        {
            _shopMoney = 0;
            _allProducts = new List<Product>();
            _queue = new Queue<Human>();
            CreateProducts();
            CreateQueue();
        }

        public void SellProducts()
        {
            foreach (var human in _queue)
            {
                human.BuyHandler();
                _shopMoney += human.SumBuy;                
            }          

            Console.WriteLine("Сегодна магазин заработал " + _shopMoney);
        }

        private void CreateProducts()
        {
            _allProducts.Add(new Product("яблоко", 10));
            _allProducts.Add(new Product("Молоко", 4));
            _allProducts.Add(new Product("Хлеб", 5));
            _allProducts.Add(new Product("Спички", 3));
            _allProducts.Add(new Product("Шоколадка", 7));
            _allProducts.Add(new Product("Волосы", 16));
            _allProducts.Add(new Product("Кости", 21));
            _allProducts.Add(new Product("Рыба", 49));
            _allProducts.Add(new Product("Мясо", 45));
            _allProducts.Add(new Product("Бриллиант", 100000));
            _allProducts.Add(new Product("Пыль", 1));
        }

        private void CreateQueue()
        {
            Console.WriteLine("Сколько человек в магазине ?");

            if(Int32.TryParse(Console.ReadLine(), out int humanCount))
            {
                for (int i = 0; i < humanCount; i++)
                {
                    _queue.Enqueue(new Human(_allProducts));
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода, создан 1 человек");
                _queue.Enqueue(new Human(_allProducts));
            }
        }
    }

    class Human
    {
        private List<Product> _bag;
        private List<Product> _allProducts;
        private int _moneyValue;        
        private bool _isBuy;

        public int SumBuy { get; private set; }

        public Human(List<Product> allProducts)
        {
            _isBuy = SumBuy <= _moneyValue;
            SumBuy = 0;
            _bag = new List<Product>();
            _allProducts = allProducts;
            CreateBag();
            CreateMoney();
        }

        public void BuyHandler()
        {
            Random random = new Random();
            int indexProduct = random.Next(0, _bag.Count);

            while (!_isBuy)
            {               
                SumBuy -= _bag[indexProduct].Price;               
                _bag.RemoveAt(indexProduct);
            }          
        }

        private void CreateBag()
        {
            int countProducts;
            int maxProductsCount=20;
            Random random = new Random();
            countProducts = random.Next(maxProductsCount);

            for (int i = 0; i < countProducts; i++)
            {                
                _bag.Add(_allProducts[random.Next(_allProducts.Count)]);
            }

            foreach (Product product in _bag)
            {
                SumBuy += product.Price;
            }
        }
        
        private void CreateMoney()
        {
            Random random = new Random();
            int maxMoney = 120;
            _moneyValue = random.Next(maxMoney);
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
            Console.WriteLine($"{_name}: {Price}");
        }
    }
}
