using System;
using System.Threading;

class Program
{
        static void Main()
        {
            Console.Write("Please enter your name: ");
            string username = Console.ReadLine();
            for (int i = 5; i >= 0; i--)
            {
                Console.WriteLine(i);
                if (i == 5)
                {
                    Thread.Sleep(500);
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
            Console.WriteLine($"Welcome {username}!");
        Console.ReadLine();

        }
 }
