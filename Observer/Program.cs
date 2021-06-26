using System;
using System.Collections.Generic;
using Observer.Publisher;
using Observer.Subscriber;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            // In this game you are a sprinter and you have to get to the endline as fast as possible.
            // You get to see how much it takes you to get to the endline.
            // There are three lines each has a lineWatcher which will raise a flag when you cross the line.

            // Play the game by pressing Enter.

            Sprinter sprinter = new Sprinter();

            LineWatcher FirstLineWatcher = new LineWatcher("First Line Watcher", 7, ConsoleColor.Blue);

            LineWatcher SecondLineWatcher = new LineWatcher("Second Line Watcher", 15, ConsoleColor.Red);

            sprinter.subscribe(FirstLineWatcher);
            sprinter.subscribe(SecondLineWatcher);

            GameManager GM = new GameManager(sprinter);

            // draw start
            GM.DrawStart();

            // draw game path
            GM.DrawPath();

        }
    }
}
