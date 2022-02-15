using System;
using System.Collections.Generic;
using System.Linq;

namespace Anarchy_in_the_hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();
            hospital.Work();
        }

        class Hospital
        {
            private List<Patient> _patients;
            private DiseaseDatabase _diseasesDatabase;
            private bool _isWork;

            public Hospital()
            {
                _isWork = true;
                _patients = new List<Patient>();
                CreatePatients();
                _diseasesDatabase = new DiseaseDatabase();
            }

            public void Work()
            {
                while (_isWork)
                {
                    Console.WriteLine($"1)Отсортировать всех больных по Имени\n2)Отсортировать всех больных по возрасту\n3)Вывести больных с определенным заболеванием\n4)Выход ");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            SortByName();
                            ShowInfo();
                            break;
                        case "2":
                            SortByAge();
                            ShowInfo();
                            break;
                        case "3":
                            FindByDisease();
                            break;
                        case "4":
                            _isWork = false;
                            break;
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            private void FindByDisease()
            {
                Console.WriteLine("Список существующих в нашем мире болезней\n===============");
                _diseasesDatabase.ShowInfo();
                Console.WriteLine("======\nВведите название болезни");

                string disease = Console.ReadLine();
                var patients = _patients.Where(patient => patient.Disease == disease);

                if (patients.Count() > 0)
                {
                    foreach (var patient in patients)
                        patient.ShowInfo();
                }

                else
                    Console.WriteLine("Таких у нас нет");
            }

            private void SortByAge()
            {
                var patients = _patients.OrderBy(patient => patient.Age).ToList();
                _patients = patients;
            }

            private void SortByName()
            {
                var patients = _patients.OrderBy(patient => patient.Name).ToList();
                _patients = patients;
            }

            private void ShowInfo()
            {
                foreach (var patient in _patients)
                    patient.ShowInfo();
            }

            private void CreatePatients()
            {
                int patientsCount = 34;

                for (int i = 0; i < patientsCount; i++)
                {
                    _patients.Add(new Patient());
                }
            }
        }

        class Patient
        {
            private NameDatabase _nameDatabase;
            private DiseaseDatabase _diseaseDatabase;
            private Random _random;

            public string Name { get; private set; }
            public string Disease { get; private set; }
            public int Age { get; private set; }

            public Patient()
            {
                _random = new Random();
                _nameDatabase = new NameDatabase();
                Name = _nameDatabase.ReturnName();
                _diseaseDatabase = new DiseaseDatabase();
                Disease = _diseaseDatabase.ReturnDisease();
                CreateAge();
            }

            public void ShowInfo()
            {
                Console.WriteLine($"{Name} --- Заболевание: {Disease}. Возраст: {Age}");
            }

            private void CreateAge()
            {
                int minAgeCount = 14;
                int maxAgeCount = 80;

                Age = _random.Next(minAgeCount, maxAgeCount);
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

        class DiseaseDatabase
        {
            private List<string> _diseases;
            private Random _random;

            public DiseaseDatabase()
            {
                _diseases = new List<string>();
                _random = new Random();
                Create();
            }

            public void ShowInfo()
            {
                foreach (var diseases in _diseases)
                    Console.WriteLine(diseases);
            }

            public string ReturnDisease()
            {
                int DiseaseIndex = _random.Next(_diseases.Count);
                return _diseases[DiseaseIndex];
            }

            private void Create()
            {
                _diseases.Add("ОРВ");
                _diseases.Add("Гипогликемия");
                _diseases.Add("Актиномикоз");
                _diseases.Add("Бубонная чума");
                _diseases.Add("Вибриоз");
                _diseases.Add("Вульводиния");
                _diseases.Add("Герпес");
                _diseases.Add("Демиелинизация");
                _diseases.Add("Долихоколон");
                _diseases.Add("Злокачественный нейролептический синдром");
                _diseases.Add("Игровое расстройство");
                _diseases.Add("Инфекционный эндокардит");
                _diseases.Add("Кокцидиоз");
                _diseases.Add("Лимфостаз");
                _diseases.Add("Меторхоз");
                _diseases.Add("Нанофиетоз");
                _diseases.Add("Опухоли головы и шеи");
                _diseases.Add("Спидорак мозга");
                _diseases.Add("Острая лучевая болезнь");
                _diseases.Add("ЗэтИксЦэГуль");
            }
        }
    }

    //    У вас есть список больных(минимум 10 записей)
    //Класс больного состоит из полей: ФИО, возраст, заболевание.
    //Требуется написать программу больницы, в которой перед пользователем будет меню со следующими пунктами:
    //1)Отсортировать всех больных по фио
    //2)Отсортировать всех больных по возрасту
    //3)Вывести больных с определенным заболеванием
    //(название заболевания вводится пользователем с клавиатуры)
}
