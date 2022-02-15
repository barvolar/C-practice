using System;
using System.Collections.Generic;
using System.Linq;

namespace Top_Players
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            Console.WriteLine("Топ 3 уровня игроки !!!!");
            game.ShowTop3LvL();

            Console.WriteLine("Топ 3 мощи игроки !!!!");
            game.ShowTop3Power();
        }
    }

    class Game
    {
        private List<Player> _players;

        public Game()
        {
            _players = new List<Player>();
            CreatePlayer();
        }

        public void ShowTop3Power()
        {
            var topPlayers = _players.OrderByDescending(player => player.Power).Take(3);

            foreach (var player in topPlayers)
                player.ShowInfo();
        }

        public void ShowTop3LvL()
        {           
            var topPlayers = _players.OrderByDescending(player => player.Level).Take(3);

            foreach (var player in topPlayers)
                player.ShowInfo();
        }

        private void CreatePlayer()
        {
            int playersCount = 200;

            for (int i = 0; i < playersCount; i++)
                _players.Add(new Player());
        }
    }

    class Player
    {
        private string _name;
        private NameDatabase _nameDatabase;
        private Random _random;

        public int Level { get; private set; }
        public int Power { get; private set; }

        public Player()
        {
            _random = new Random();
            _nameDatabase = new NameDatabase();
            _name = _nameDatabase.ReturnName();
            CreateLevel();
            CreatePower();
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{_name}::::: LVL = {Level}  Power = {Power}");
        }

        private void CreatePower()
        {
            int minPowerCount = 100;
            int maxPowerCount = 40000;

            Power = _random.Next(minPowerCount, maxPowerCount);
        }

        private void CreateLevel()
        {
            int minLevelCount = 1;
            int maxLevelCount = 85;

            Level = _random.Next(minLevelCount, maxLevelCount);
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
}
//У нас есть список всех игроков(минимум 10). У каждого игрока есть поля: имя, уровень, сила.
//    Требуется написать запрос для определения топ 3 игроков по уровню и топ 3 игроков по силе, после чего вывести каждый топ.
//2 запроса получится.
