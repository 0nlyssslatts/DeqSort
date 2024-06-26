using System;
using System.Diagnostics;


namespace DeqSort
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Stopwatch sw = Stopwatch.StartNew();
            Random rnd = new Random();
            Sort testDeq = new Sort();

            for (int i = 0; i < 20; i++)
            {
                testDeq.PushLeft(new Item(rnd.Next(0, 1000)));
            }

            testDeq.Print();
            Sort.SelectionSort(20, testDeq);
            testDeq.Print();
            


            //-------------------------------------------------------


            Sort deq = new Sort();
            Deque.Nop = 0;
            int N = 100;

           

            for (int i = 0;i < 10; i++)
            { 
                for(int j = N - 100; j < N; j++)
                {
                    deq.PushRight(new Item(rnd.Next(0,1000)));
                }


                sw.Start();
                Sort.SelectionSort(N, deq);
                sw.Stop();
                double elapsedTime = sw.Elapsed.TotalSeconds;
                sw.Restart();

                Console.WriteLine($"Номер сортировки {i + 1}");
                Console.WriteLine($"Количество элементов {N}");
                Console.WriteLine($"Время выполнения метода: {elapsedTime}");
                Console.WriteLine($"Количество выполненных операций {Deque.Nop}");

                N += 100;
                Deque.Nop = 0;

            }

            Console.ReadKey();
        }
    }
}
