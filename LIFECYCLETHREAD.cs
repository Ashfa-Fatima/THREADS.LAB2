using System;
using System.Runtime.InteropServices;
using System.Threading;

class Program

{
    static void Main()
    {


        Thread life1 = new Thread(Life1);
        Console.WriteLine("State:" + life1.ThreadState);

        life1.Start();
        Console.WriteLine("State:" + life1.ThreadState);

      

        Thread.Sleep(1000);
        Console.WriteLine("State:" + life1.ThreadState);

        life1.Abort();
        Console.WriteLine("State:" + life1.ThreadState);

        life1.Start();
        Console.WriteLine("State:" + life1.ThreadState);

        life1.Join();
        Console.WriteLine("State:" + life1.ThreadState);


    }
    static void Life1()
    {
        Thread.Sleep(5000);

    }
}