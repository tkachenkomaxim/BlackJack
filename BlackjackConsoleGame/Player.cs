using System;
using System.Collections.Generic;

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

        public Player()
        {
            Cards = new List<Card>();
        }
    }
}
