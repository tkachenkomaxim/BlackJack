using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsoleGame
{ // Вынести  конструктор и все то что делают над сущность.
    
    public class Deck
    {
        private const int quantityCards = 52;
        private const int quantityRanks = quantityCards / 4;
        private const int quantitySuits = 4;
         
        private Stack<Card> shufflingCards = new Stack<Card>(quantityCards);
        private Random rand = new Random();

        public Deck()
        {
            List<Card> cards = new List<Card>(quantityCards);
           
            for(int i = 0; i < quantityRanks; i++)
            {
                for (int j = 0; j < quantitySuits; j++)
                {
                    int points;

                    switch ((Ranks)i)
                    {
                        case Ranks.Two: points = 2; break;
                        case Ranks.Three: points = 3; break;
                        case Ranks.Four: points = 4; break;
                        case Ranks.Five: points = 5; break;
                        case Ranks.Six: points = 6; break;
                        case Ranks.Seven: points = 7; break;
                        case Ranks.Eight: points = 8; break;
                        case Ranks.Nine: points = 9; break;
                        case Ranks.Ace: points = 11; break;
                        default: points = 10; break;
                    }

                    cards.Add(new Card { Rank = (Ranks)i,
                                         Suit = (Suits)j,
                                         Point = points
                    });
                }
            }

            Shuffle(cards);
        }

        public void Shuffle(List<Card> cards)
        {
            Console.WriteLine(cards.Count);
          
            for(int i = quantityCards; i != 0; i--)
            {
                int randNumber = rand.Next(0, i);
                shufflingCards.Push(cards[randNumber]);
                cards.Remove(cards[randNumber]);
                
            }
        }

        public Card Deal()
        {
            return shufflingCards.Pop();
        }
          
    }
}
