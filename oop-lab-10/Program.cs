using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;



namespace oop_lab_10
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task1
            Console.WriteLine();
            Console.WriteLine("Task1");
            Console.WriteLine();
            Console.WriteLine("Создать необобщенную коллекцию ArrayList.");

            var Task1 = new ArrayList();
            Console.WriteLine("a. Заполните ее 5 - ю случайными целыми числами");
            Random random = new Random();
            //for(int i=1;i<=5;i++)
            //{
            //    Task1.Add(random.Next(0,200));
            //}
            Task1.AddRange(new int[] { random.Next(0, 10), random.Next(10, 20), random.Next(20, 30), random.Next(30, 40), random.Next(40, 50) });

            printTask1();

            Console.WriteLine("b.Добавьте к ней строку");
            Task1.Add("b. String for Task1");
            printTask1();



            Console.WriteLine("c. Добавьте объект типа Student ");
            Student student = new Student();
            Task1.Add(student);
            Task1.Reverse();
            Task1.Add(new Student());
            Task1.Reverse();

            printTask1();

            Console.WriteLine("d. Удалите заданный элемент");
            Task1.RemoveAt(3);
            Task1.Remove(student);

            printTask1();

            if (Task1.Contains("b. String for Task1"))
            {
                Console.WriteLine("Содержит");
            }
            else
            {
                Console.WriteLine("Не содержит");
            }


            void printTask1()
            {
                Console.WriteLine("Вывод Task1\nРазмер {0}", Task1.Count);
                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (object i in Task1)
                {
                    Console.WriteLine(i);
                }
                Console.ResetColor();
            }
            #endregion

            #region Task2
            Console.WriteLine();
            Console.WriteLine("Task2");
            Console.WriteLine();
            Console.WriteLine("Создать обобщенную коллекцию в соответствии с вариантом задания и заполнить ее данными, тип которых определяется вариантом задания(колонка – первый тип).  ");

            LinkedList<char> CharLinkedList = new LinkedList<char>();
            Console.WriteLine("c.Добавьте другие элементы(используйте все возможные методы добавления для вашего типа коллекции).");
            CharLinkedList.AddLast('B');
            CharLinkedList.AddFirst('a');
            CharLinkedList.AddLast('c');
            for (int i = 0; i < 3; i++)
            {
                CharLinkedList.AddLast('c');
                CharLinkedList.AddBefore(CharLinkedList.First, (char)('A' + i));
                CharLinkedList.AddLast((char)('Z' + i));
            }
            CharLinkedList.AddBefore(CharLinkedList.Find('c'), 'C');
            CharLinkedList.AddAfter(CharLinkedList.Find('B'), 'b');
            CharLinkedList.AddAfter(CharLinkedList.Find('B'), 'b');


            Console.WriteLine("a.Вывести коллекцию на консоль");
            printCharLinkedList();

            Console.WriteLine("\nb.Удалите из коллекции n последовательных элементов");

            int number;
            if (int.TryParse(Console.ReadLine(), out number))
            {
                if (number < CharLinkedList.Count)
                {
                    for (int i = 1; i <= number; i++)
                    {
                        //CharLinkedList.RemoveFirst();
                        CharLinkedList.RemoveLast();
                    }
                }
            }
            printCharLinkedList();

            Console.WriteLine(" d.Создайте вторую коллекцию(см.таблицу) и заполните ее данными из первой коллекции.\n e.Выведите вторую коллекцию на консоль.");

            HashSet<char> CharHashSet = new HashSet<char>();
            CharHashSet.UnionWith(CharLinkedList);
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (char i in CharHashSet)
            {
                Console.Write(i + "  ");
            }
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("f.Найдите во второй коллекции заданное значение.");
            Console.WriteLine("Введите символ для поиска в CharLinkedList");

            char symbol;
            symbol = (char)Console.Read();
            if (CharHashSet.Contains(symbol))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0} содержит символ {1}", "CharLinkedList", symbol);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} не содержит символ {1}", "CharLinkedList", symbol);
            }
            Console.ResetColor();
            void printCharLinkedList()
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (char i in CharLinkedList)
                {
                    Console.Write(i + "  ");
                }
                Console.WriteLine();
                Console.ResetColor();
            }
            #endregion
            #region Task3
            Console.WriteLine("Task3");
            LinkedList<Monitor> MonitorLinkedList = new LinkedList<Monitor>();

            Monitor mon2 = new Monitor("mon2", "RB", 1500, "2", 1567);
            Monitor mon4 = new Monitor("mon4", "RB", 2500, "2", 15);         

            MonitorLinkedList.AddFirst(new Monitor("mon1", "RB", 5700, "2", 156));
            MonitorLinkedList.AddFirst(new Monitor("mon3", "RB", 5020, "2", 15556));
            MonitorLinkedList.AddFirst(mon4);
            MonitorLinkedList.AddFirst(mon4);
            MonitorLinkedList.AddLast(mon2);
            MonitorLinkedList.AddLast(mon2);
            MonitorLinkedList.AddLast(mon2);
            MonitorLinkedList.AddLast(mon2);
            
            MonitorLinkedList.AddBefore(MonitorLinkedList.Find(mon2), mon4);
            MonitorLinkedList.AddAfter(MonitorLinkedList.Find(mon4), mon2);
            PrintMonitorLinkedList();

            Console.WriteLine("\nУдалите из коллекции n последовательных элементов");

            int num;
            if (int.TryParse(Console.ReadLine(), out num))
            {
                if (num < MonitorLinkedList.Count)
                {
                    for (int i = 1; i <= num; i++)
                    {

                        MonitorLinkedList.RemoveFirst();
                    }
                }
            }
            PrintMonitorLinkedList();

            HashSet<Monitor> MonitorHashSet = new HashSet<Monitor>(MonitorLinkedList);

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (Monitor i in MonitorHashSet)
            {
                Console.Write(i + "  ");
            }
            Console.WriteLine();
            Console.ResetColor();


            void PrintMonitorLinkedList()
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (Monitor i in MonitorLinkedList)
                {
                    Console.Write(i + "  ");
                }
                Console.WriteLine();
                Console.ResetColor();
            }

           
            if (MonitorHashSet.Contains(mon4))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0} содержит {1}", "MonitorLinkedList", mon4);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} не содержит {1}", "MonitorLinkedList", mon4);
            }
            Console.ResetColor();


            #endregion
            #region Task 4
            #endregion
            Console.WriteLine("Task4");
            ObservableCollection<Monitor> MonitorObservableCollection = new ObservableCollection<Monitor>(MonitorHashSet);
            MonitorObservableCollection.CollectionChanged += TryToChangeMonitorObservableCollection;
            void print()
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (Monitor i in MonitorObservableCollection)
                {
                    Console.Write(i + "  ");
                }
                Console.WriteLine();
                Console.ResetColor();
            }
            MonitorObservableCollection.Add(mon2);
            print();
            MonitorObservableCollection.Remove(mon2);
            print();
        }

        public static void TryToChangeMonitorObservableCollection(object sender, NotifyCollectionChangedEventArgs e)
        {
            Debug.Assert(false, "Вы изменили MonitorObservableCollection");
        }

    }
}
