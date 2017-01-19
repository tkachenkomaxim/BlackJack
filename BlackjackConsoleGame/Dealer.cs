using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsoleGame
{
    class Dealer
    {
        private Deck deck;
        private Random rand = new Random();

        public Dealer(Deck deck)
        {
            this.deck = deck;
        }

        public void Shuffle(List<Card> cards)
        {
            for (int i = Deck.quantityCards; i != 0; i--)
            {
                int randNumber = rand.Next(0, i);
                deck.shufflingCards.Push(cards[randNumber]);
                cards.Remove(cards[randNumber]);
            }
        }

        public Card Deal()
        {
            return deck.shufflingCards.Pop();
        }
    }
}
