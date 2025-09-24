using System;
using System.Threading;

class RainSimulation
{
    static void Main()
    {
        Console.CursorVisible = false;
        Random rand = new Random();
        string[] thunder = { "", "⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡", "" };
        string car = @"
        ____________________________
       /|_||_\`.__                __\
      (   _    _ _\   ASHFA      /  )
      =`-(_)--(_)-'==============='";

        for (int frame = 0; frame < 100; frame++)
        {
            Console.Clear();

            // Thunder flash every few frames
            if (frame % 15 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(thunder[1]);
                Console.ResetColor();
            }

            // Simulate falling rain
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 60; x++)
                {
                    int drop = rand.Next(0, 100);
                    if (drop < 3)
                        Console.Write("|"); // heavy drop
                    else if (drop < 6)
                        Console.Write("."); // light drizzle
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }

            // Display animated SHOWER title
            string title = "SHOWER";
            char letter = title[frame % title.Length];
            Console.WriteLine($"\n     {letter} . . . . . . . . . . . . . . . .");

            // Show car
            Console.WriteLine(car);

            Thread.Sleep(120);
        }

        Console.CursorVisible = true;
    }
}