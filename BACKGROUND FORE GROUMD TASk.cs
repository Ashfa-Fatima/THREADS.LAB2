using System;
using System.Threading;

class Program 
{
    static void Main()
    {
        
            Thread ashfa1 = new Thread(Ashfa);
            ashfa1.IsBackground = true;
            ashfa1.Start();
            
            
            Thread ashfa2 = new Thread(Sehar);
            ashfa2.IsBackground = false;
            ashfa2.Start();
            

            
        
    }

    static void Ashfa()
    {
        for (int i = 1; i <= 3; i++)
        {
            Thread.Sleep(3000);
            Console.WriteLine("Background thread: ");

        }
    }
    static void Sehar()
    {
        for (int i = 1; i <= 3; i++)
        {
            Thread.Sleep(1000);
            Console.WriteLine("Foreground thread: ");
        }
    }
}
