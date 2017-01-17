using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsoleGame
{
    public class Player
    {
        public List<Card> Cards { get; set;}
        public string Name { get; set; }
        public int Points { get; set; }

        public Player(string name)
        {
            Name = name;
            Points = 0;
            Cards = new List<Card>();
        }

        public void TakeCard(Card card)
        {
            Points += card.Point;
            Cards.Add(card);
        }
    }
}
