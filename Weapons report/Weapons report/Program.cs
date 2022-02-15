using System;
using System.Collections.Generic;
using System.Linq;

namespace Weapons_report
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Battalion battalion = new Battalion();
            battalion.Work();
        }
    }

    class Battalion
    {
        private List<Soldier> _soldiers;

        public Battalion()
        {
            _soldiers = new List<Soldier>();
            AddSoldiersToList(40);
        }

        public void Work()
        {
            Console.WriteLine("Показать всех:\n1) Автоматчиков\n2) Пистолетчиков\n3) Гранатометчиков\n4) Пулеметчиков\n5) Снайперов");

            switch (Console.ReadLine())
            {
                case "1":
                    FindSoldiersByArms("Автомат");
                    break;
                case "2":
                    FindSoldiersByArms("Пистолет");
                    break;
                case "3":
                    FindSoldiersByArms("Гранатомет");
                    break;
                case "4":
                    FindSoldiersByArms("Пулемет");
                    break;
                case "5":
                    FindSoldiersByArms("Снайперская винтовка");
                    break;
                default:
                    Console.WriteLine("Такого оружия у нас нет");
                    break;
            }
        }

        private void FindSoldiersByArms(string weaponType)
        {
            var soldiers = _soldiers.Where(soldier => soldier.Weapon == weaponType);

            foreach (var soldier in soldiers)
                soldier.ShowNameAndRank();
        }

        private void AddSoldiersToList(int soldiersCount)
        {
            for (int i = 0; i < soldiersCount; i++)
            {
                _soldiers.Add(new Soldier());
            }
        }
    }

    class Soldier
    {
        private RankDatabase _rankDatabase;
        private NameDatabase _nameDatabase;
        private WeaponDatabase _weaponDatabase;
        private Random _random;

        public int PeriodOfService { get;private set; }
        public string Rank { get; private set; }
        public string Name { get; private set; }
        public string Weapon { get; private set; }

        public Soldier()
        {
            _random = new Random();
            _rankDatabase = new RankDatabase();
            Rank = _rankDatabase.ReturnRank();
            _nameDatabase = new NameDatabase();
            Name = _nameDatabase.ReturnName();
            _weaponDatabase = new WeaponDatabase();
            Weapon = _weaponDatabase.ReturnWeapon();
            CreatePeriodOfService();
        }

        public void ShowNameAndRank()
        {
            Console.WriteLine($"{Name} звание {Rank} срок службы {PeriodOfService} мес.");
        }

        private void CreatePeriodOfService()
        {
            int minPeriodOfService = 3;
            int maxPeriodOfService = 2400;

            PeriodOfService=_random.Next(minPeriodOfService, maxPeriodOfService);
        }
    }

    class RankDatabase
    {
        private List<string> _rank;
        private Random _random;

        public RankDatabase()
        {
            _random = new Random();
            _rank = new List<string>();
            AddRankToList();
        }

        public string ReturnRank()
        {
            int rankIndex = _random.Next(_rank.Count);
            return _rank[rankIndex];
        }

        private void AddRankToList()
        {
            _rank.Add("рядовой");
            _rank.Add("мл. сержант");
            _rank.Add("сержант");
            _rank.Add("ст. сержант");
            _rank.Add("старшина");
            _rank.Add("прапорщик");
            _rank.Add("ст прапорщик");
            _rank.Add("мл. лейтенант");
            _rank.Add("лейтенант");
            _rank.Add("ст. лейтенант");
            _rank.Add("капитан");
            _rank.Add("майор");
        }
    }

    class WeaponDatabase
    {
        private List<string> _weapons;
        private Random _random;

        public WeaponDatabase()
        {
            _weapons = new List<string>();
            _random = new Random();
            AddWeaponToList();
        }

        public string ReturnWeapon()
        {
            int weaponIndex = _random.Next(_weapons.Count);
            return _weapons[weaponIndex];
        }

        private void AddWeaponToList()
        {
            _weapons.Add("Автомат");
            _weapons.Add("Пистолет");
            _weapons.Add("Гранатомет");
            _weapons.Add("Пулемет");
            _weapons.Add("Снайперская винтовка");
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
