using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using forlaba11;
using System.Collections;

namespace lab12
{
    public class Task1
    {
        static Random rnd = new Random();

        internal static Person CreatePerson()
        //для заполнения очереди случайными объектами типа Person
        {
            bool ok = true;
            Person p = null;

            int makeRnd = rnd.Next(1, 5);
            switch (makeRnd)
            {
                case 1:
                    {
                        p = new Person(ok);
                        break;
                    }
                case 2:
                    {
                        p = new Student(ok);
                        break;
                    }
                case 3:
                    {
                        p = new Teacher(ok);
                        break;
                    }
                case 4:
                    {
                        p = new Employee(ok);
                        break;
                    }
            }
            return p;
        }

        static Person AddPerson()
        {
            Console.WriteLine("Введите имя:");
            string name = Console.ReadLine();
            Console.WriteLine("Введите возраст:"); // + проверка

            bool ok;
            int age;
            do
            {
                string buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out age);
                if ((!ok) || (age <= 0))
                    Console.WriteLine("Натуральное число введено неверно. Повторите ввод.");
            } while ((!ok) || (age <= 0));

            return new Person(name, age);
        }

        static void NumberOfStud(Queue QList)
        {
            int count = 0;
            foreach (object elem in QList)
            {
                Person p = elem as Student;
                if (p != null)
                    count++;
            }
            Console.WriteLine("Коллекция содержит {0} студентов", count);
        }

        static void PrintEmployee(Queue QList)
        {
            Console.WriteLine("Вывод сотрудников: ");
            foreach (object elem in QList)
            {
                if (elem is Employee e)
                    Console.WriteLine(e.Show());
            }
        }

        static void SubOfTeachers(Queue QList)
        {
            Console.WriteLine("Вывод дисциплин: ");
            foreach (object elem in QList)
            {
                if (elem is Teacher t)
                    Console.WriteLine("Предмет: {0}", t.subject);
            }
        }

        static void CloneQue(Queue QList)
        {
            Queue ClQueList = new Queue(QList.Count);
            foreach (object elem in QList)
            {
                if (elem is Person p)
                    ClQueList.Enqueue(p.Clone());
            }
            Console.WriteLine("Клонированная коллекция: ");
            PrintQueue(ClQueList);

            //return ClQueList;
        }

        static Queue SortQue(Queue QList)
        //сортировка по возрасту (возрастание)
        {
            Queue SortedQueList = new Queue(QList.Count);
            Person[] mas = new Person[QList.Count];
            int i = 0;
            foreach (object elem in QList)
            {
                if (elem is Person p)
                    mas[i++] = p;
            }
            Array.Sort(mas, new SortByAge());

            for (i = 0; i < mas.Length; i++)
                SortedQueList.Enqueue(mas[i]);
            Console.WriteLine("Отсортированная по возрасту очередь: ");
            PrintQueue(SortedQueList);

            return SortedQueList;
        }

        static void SearchElem(Queue QList)
        {
            Console.WriteLine("Введите номер элемента для поиска: ");
            int num = Int32.Parse(Console.ReadLine());
            int count = 1;
            if ((num > 0) && (num <= QList.Count))
            {
                foreach (object elem in QList)
                {
                    if ((elem is Person p) && (count++ == num))
                        Console.WriteLine("Нужный элемент: " + p.Show());
                }
            }
            else Console.WriteLine("Номер элемента задан неправильно");
        }

        internal static void PrintQueue(IEnumerable myCollection)
        //вывод очереди
        {
            int count = 1;
            foreach (object obj in myCollection)
            {
                if (obj is Person p)
                    Console.WriteLine(count++ + ". " + p.Show());
            }
            Console.WriteLine();
        }

        internal static void Menu(Queue QList)
        {
            bool ok = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Что делать?");
                Console.WriteLine("1. Добавить элемент");
                Console.WriteLine("2. Удалить элемент");
                Console.WriteLine("3. Запросы");
                Console.WriteLine("4. Клонирование");
                Console.WriteLine("5. Сортировка");
                Console.WriteLine("6. Поиск элемента");
                Console.WriteLine("7. Печать очереди");
                Console.WriteLine("8. Выход");

                Console.ForegroundColor = ConsoleColor.Gray;
                var MakeArray = Console.ReadLine();
                switch (MakeArray)
                {
                    case "1":
                        //Добавить элемент
                        QList.Enqueue(AddPerson());
                        break;
                    case "2":
                        //Удалить элемент
                        if (QList.Count != 0)
                        {
                            Person p = QList.Dequeue() as Person;
                            Console.WriteLine("Элемент / {0} / удален из очереди", p.Show());
                        }
                        else Console.WriteLine("Очередь пуста");
                        break;
                    case "3":
                        //запросы: количество студентов, вывод сотрудников, дисциплины преподавателей
                        NumberOfStud(QList);
                        PrintEmployee(QList); //не работает
                        SubOfTeachers(QList);
                        break;
                    case "4":
                        //клонирование
                        CloneQue(QList);
                        break;
                    case "5":
                        //Сортировка
                        QList = SortQue(QList);
                        break;
                    case "6":
                        //Поиск элемента
                        SearchElem(QList);
                        break;
                    case "7":
                        PrintQueue(QList);
                        break;
                    case "8":
                        ok = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неверный номер команды. Повторите ввод ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }
            } while (!ok);
        }

    }
}
