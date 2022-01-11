using System;
using System.Collections.Generic;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Battleground battleground = new Battleground();
            battleground.Attack();
        }
    }

    class Battleground
    {
        private List<Fighter> _oneTeam;
        private List<Fighter> _twoTeam;

        public Battleground()
        {
            _oneTeam = new List<Fighter>();
            _twoTeam = new List<Fighter>();
            CreateFighters(_oneTeam);
            CreateFighters(_twoTeam);
        }

        public void Attack()
        {
            int oneFighterIndex = 0;
            int twoFighterIndex = 0;
            int roundIndex = 1;

            while (_oneTeam.Count > 0 && _twoTeam.Count > 0)
            {
                Console.WriteLine("Раунд " + roundIndex);

                ShowInfo();

                if (oneFighterIndex >= _oneTeam.Count)
                    oneFighterIndex = 0;

                if (twoFighterIndex >= _twoTeam.Count)
                    twoFighterIndex = 0;

                _twoTeam[twoFighterIndex].TakeDamage(_oneTeam[oneFighterIndex]);
                _oneTeam[oneFighterIndex].TakeDamage(_twoTeam[twoFighterIndex]);

                oneFighterIndex++;
                twoFighterIndex++;

                TeamHandler(_oneTeam);
                TeamHandler(_twoTeam);

                WinHandler();

                Console.WriteLine("Для следующего раунда нажмите любую кнопку");

                roundIndex++;
            }
        }

        private void WinHandler()
        {
            if (_oneTeam.Count <= 0)
            {
                Console.WriteLine("Victory two team");
            }

            if (_twoTeam.Count <= 0)
            {
                Console.WriteLine("Victory one team");
            }
        }

        private void TeamHandler(List<Fighter> fighters)
        {
            for (int i = 0; i < fighters.Count; i++)
            {
                if (fighters[i].Health <= 0)
                    fighters.RemoveAt(i);
            }
        }

        private void CreateFighters(List<Fighter> fighters)
        {
            int teamSize = 50;

            for (int i = 0; i < teamSize; i++)
            {
                fighters.Add(new Fighter());
            }
        }

        private void ShowInfo()
        {
            Console.WriteLine("Численность первой команды - " + _oneTeam.Count);
            Console.WriteLine("Численность второй команды - " + _twoTeam.Count);
        }
    }

    class Fighter
    {
        private int _armor;
        private Random _random;

        public int Health { get; private set; }
        public int Damage { get; private set; }

        public Fighter()
        {
            _random = new Random();
            CreateStats();
        }

        public void TakeDamage(Fighter fighter)
        {
            Health -= fighter.Damage / _armor;
        }

        private void CreateStats()
        {
            int maxHealth = 2000;
            int minHealth = 300;
            int maxArmor = 5;
            int minArmor = 1;
            int maxDamage = 500;
            int minDamage = 20;

            Health = _random.Next(minHealth, maxHealth);
            _armor = _random.Next(minArmor, maxArmor);
            Damage = _random.Next(minDamage, maxDamage);
        }
    }
}
