using System;
using System.Threading;
class Program
{
    static void Main()
    {
        string line = "...................................................................................................";
        int length = line.Length;
        for (int i = 0; i < length; i++)
        {
            Console.Write("\r" + new string(' ',i) + "Sehar" + line.Substring(i + 1));
            Thread.Sleep(200);
            Console.Write("\r" + new string(' ', i + 1) + line.Substring(i + 1));
            Thread.Sleep(250);

        }
        Console.Write("\r" + new string(' ', length) + "Sehar");
        Console.WriteLine("\n\n Game Over Dear! PAC MAN ate all the dots like sehar ate Ants!");
        Console.ReadLine();
    }
}
