using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using forlaba11;
using System.Collections;

namespace lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Создать коллекцию, в которую добавить объекты созданной иерархии классов. + task 1
            int size = 10;
            Queue QList = new Queue(size);
            for (int i = 0; i < size; i++)
                QList.Enqueue(Task1.CreatePerson());
            Console.WriteLine("Начальный список");
            Task1.PrintQueue(QList);
            Task1.Menu(QList);

            ///////

            //2. 


        }

    }
}
