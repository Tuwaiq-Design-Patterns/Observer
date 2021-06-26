using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Observer.Subscriber;

namespace Observer.Publisher
{
    public class Sprinter
    {
        public List<ILineWatcher> LinesWatchers { get; set; }
        public int Distance { get; set; }
        public Sprinter()
        {
            Distance = 0;
            LinesWatchers = new List<ILineWatcher>();
        }
        public void subscribe(ILineWatcher lineWatcher)
        {
            LinesWatchers.Add(lineWatcher);
        }

        public void unsubscribe(ILineWatcher lineWatcher)
        {
            LinesWatchers.Remove(lineWatcher);
        }

        public void move()
        {
            Distance++;
        }
        public void notify(int PainterStep, int timeDiffrence)
        {
            foreach(var lw in LinesWatchers)
            {
                if(lw.Distance < Distance)
                {
                    lw.RaiseTheFlag(PainterStep, timeDiffrence);
                }
            }
        }
    }
}
