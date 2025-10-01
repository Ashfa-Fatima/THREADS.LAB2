using System;
using System.Threading;

class Fruit
{
    public void Apple()
    {
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Fruit: Apple");
            Thread.Sleep(1000);
        }
    }

    public void Lichi()
    {
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Fruit: Lichi");
            Thread.Sleep(1500);
        }
    }

    public void Anar()
    {
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Fruit: Anar");
            Thread.Sleep(2000);
        }
    }

    static void Main()
    {
        Fruit fruit = new Fruit();  

        Thread t1 = new Thread(new ThreadStart(fruit.Apple));
        Thread t2 = new Thread(new ThreadStart(fruit.Lichi));
        Thread t3 = new Thread(new ThreadStart(fruit.Anar));

        t1.Start();
        t2.Start();
        t3.Start();

        t1.Join();
        t2.Join();
        t3.Join();
    }
}
