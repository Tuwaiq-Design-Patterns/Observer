using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.Subscriber
{
    public class LineWatcher : ILineWatcher
    {
        public int Distance { get; set; }
        public ConsoleColor FlagColor { get; set; }
        public string Message { get; set; }
        public int? TimeDiffrence { get; set; }
        public LineWatcher(string message, int distance, ConsoleColor color)
        {
            Message = message;
            Distance = distance;
            FlagColor = color;
        }

        public void RaiseTheFlag(int PainterDistance, int timeDiffrence)
        {
            if(TimeDiffrence == null)
            {
                TimeDiffrence = timeDiffrence;
            }

            if(PainterDistance == Distance)
            {
                Console.BackgroundColor = FlagColor;
                Console.Write(Message + ", Crossed in: " + TimeDiffrence + "s");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
    }
}
