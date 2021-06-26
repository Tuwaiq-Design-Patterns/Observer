using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.Subscriber
{
    public interface ILineWatcher
    {
        public int Distance { get; set; }
        public ConsoleColor FlagColor { get; set; }
        public string Message { get; set; }
        public void RaiseTheFlag(int PainterDistance, int timeDiffrence);
    }
}
