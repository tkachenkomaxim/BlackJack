using System;
using System.Collections.Generic;

namespace BlackjackConsoleGame
{
    public class Deck
    {
        public List<Card> Cards { get; set; }
        public Stack<Card> ShufflingCards { get; set; }
       
        public Deck()
        {
            ShufflingCards = new Stack<Card>();
            Cards = new List<Card>();
            int firstRankNumber = (int)Rank.Two;
            int lastRankNumber = (int)Rank.King;
            int quantitySuits = Enum.GetValues(typeof(Suit)).Length;

            for (int i = firstRankNumber; i <= lastRankNumber; i++)
            {
                for (int j = 0; j < quantitySuits; j++)
                {
                    int points = 0;
                    if (i <= (int)Rank.Ace)
                    {
                        points = i;
                    }
                    if (i > (int)Rank.Ace)
                    {
                        points = i - 10;
                    }
                    Cards.Add(new Card
                    {
                        Rank = (Rank)i,
                        Suit = (Suit)j,
                        Point = points
                    });
                }
            }
        }
    }
}
