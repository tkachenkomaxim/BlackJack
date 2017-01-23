using System;
using System.Collections.Generic;

namespace BlackjackConsoleGame
{ 
    public class Deck
    {
        public const int quantityCards = 52;
        public const int quantityRanks = quantityCards / 4;
        public const int quantitySuits = 4;
         
        public Stack<Card> shufflingCards = new Stack<Card>(quantityCards);
    }
}
