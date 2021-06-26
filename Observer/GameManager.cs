using Observer.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class GameManager
    {
        public Sprinter PSprinter { get; set; }
        public DateTime StartTime { get; set; }
        public GameManager(Sprinter sprinter)
        {
            PSprinter = sprinter;
        }
        public void DrawStart(int count = 3)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Sprint will start after: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(count);
            System.Threading.Thread.Sleep(1000);
            Console.Clear();

            if (count == 1)
            {
                StartTime = DateTime.Now;
                return;
            }

            count--;
            DrawStart(count);
        }
        public void DrawPath()
        {
            repaint:

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---- GO!! ----");

            Console.WriteLine();
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            for (int i = 0; i < 20; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                string path = "|   |";
                if (i == PSprinter.Distance)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    path = "| ↓ |";
                }

                Console.Write(path);
                PSprinter.notify(i, DateTime.Now.Subtract(StartTime).Seconds);
                Console.WriteLine();
            }

            if (PSprinter.Distance < 20)
            {
                Console.ReadLine();
                Console.Clear();
                PSprinter.move();

                goto repaint;
            }

            Console.WriteLine();
            Console.WriteLine("Finished in: " + DateTime.Now.Subtract(StartTime).Seconds + "s");
            Console.WriteLine("Thanks for playing");
        }
    }
}
