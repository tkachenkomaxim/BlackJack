using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsoleGame
{
    public class Player
    {
        public List<Card> Cards { get; set; }
        public string Name { get; set; }
        public int Points
        {
            get
            {
                int points = 0;
                foreach (Card item in Cards)
                {
                    points += item.Point;
                }
                return points;
            }
        }

        public Player(string name)
        {
            Name = name;
            Cards = new List<Card>();
        }
    }
}
