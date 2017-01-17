using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsoleGame
{
    public struct Card
    {
        public Ranks Rank { get;  set; }
        public Suits Suit { get;  set; }
        public int Point { get;  set; } 
    }
}
