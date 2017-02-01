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
            CreateCards();
            
        }

        private void CreateCards()
        {
            int firstRankNumber = 0;
            int lastRankNumber = 12;
            int firstSuitNumber = 0;
            int lastSuitNumber = 3;
            int aceRankNumber = (int)Rank.Ace;

            for (int i = firstRankNumber; i <= lastRankNumber; i++)
            { 
                for (int j = firstSuitNumber; j <= lastSuitNumber; j++)
                {
                    int points = 0;
                    if (i <= aceRankNumber)
                    {
                        points = i + 2;
                    }
                    if (i > aceRankNumber)
                    {
                        points = i - 8;
                    }
                    Card card = new Card();
                    card.Rank = (Rank)i;
                    card.Suit = (Suit)j;
                    card.Point = points;
                    
                    Cards.Add(card);
                }
            }
        }
    }
}
