using System;
using System.Collections.Generic;

namespace Zoopark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Cage
    {
        private List<Animal> _animals;
        private string _maleGender;
        private string _famaleGender;

        public Cage(int maleCount, int famaleCount)
        {
            _maleGender = "Самец";
            _famaleGender = "Cамка";
            _animals = new List<Animal>();
            CreateAnimals(5, "Бизон", "aaaa", _maleGender);
        }

        private void CreateAnimals(int value, string name, string voice,string gender)
        {
            for (int i = 0; i < value; i++)
            {
                _animals.Add(new Animal(name, voice, gender));
            }
        }
    }

    class Animal
    {
        protected string Name;
        protected string Voice;
        private string Gender;

        public Animal(string name, string voice ,string gender)
        {
            Name = name;
            Voice = voice;
            Gender = gender;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} : пол - {Gender}, издаёт звук - {Voice}");
        }
    }
}
