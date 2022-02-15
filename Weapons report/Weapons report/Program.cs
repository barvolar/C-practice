using System;
using System.Collections.Generic;
using System.Linq;

namespace Weapons_report
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    class WeaponDatabase
    {
        private List<string> _weapons;
        private Random _random;

        public WeaponDatabase()
        {

        }

        private AddWeapon() { }
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

    // Существует класс солдата.В нём есть поля: имя, вооружение, звание, срок службы(в месяцах).
    //Написать запрос, при помощи которого получить набор данных состоящий из имени и звания.
    // Вывести все полученные данные в консоль.
    // (Не менее 5 записей)
}
