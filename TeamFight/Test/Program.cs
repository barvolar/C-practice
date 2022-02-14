using System;
using System.Collections.Generic;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Battleground battleground = new Battleground();
            battleground.ProcessingBattle();
        }
    }

    class Battleground
    {
        private List<Fighter> _oneTeam;
        private List<Fighter> _twoTeam;

        public Battleground()
        {
            _oneTeam = CreateFighters();
            _twoTeam = CreateFighters();         
        }

        public void ProcessingBattle()
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

                _twoTeam[twoFighterIndex].TakeDamage(_oneTeam[oneFighterIndex].Damage);
                _oneTeam[oneFighterIndex].TakeDamage(_twoTeam[twoFighterIndex].Damage);

                oneFighterIndex++;
                twoFighterIndex++;

                RemovingDeadFighters(_oneTeam);
                RemovingDeadFighters(_twoTeam);

                ChekVictory();
               
                roundIndex++;
            }
        }

        private void ChekVictory()
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

        private void RemovingDeadFighters(List<Fighter> fighters)
        {
            for (int i = 0; i < fighters.Count; i++)
            {
                if (fighters[i].Health <= 0)
                    fighters.RemoveAt(i);
            }
        }
    
        private List<Fighter> CreateFighters()
        {
            List<Fighter> fighters = new List<Fighter>();
            int teamSize = 50;

            for (int i = 0; i < teamSize; i++)
                fighters.Add(new Fighter());

            return fighters;
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
        
        public void TakeDamage(int damageValue)
        {
            Health -= damageValue / _armor;
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
