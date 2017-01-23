using System;
using System.Collections.Generic;

namespace BlackjackConsoleGame
{
    class Dealer
    {
        private Deck _deck;
        private Random _rand = new Random();

        public Dealer(Deck deck)
        {
            _deck = deck;
        }

        public void Shuffle(List<Card> cards)
        {
            for (int i = Deck.quantityCards; i != 0; i--)
            {
                int randNumber = _rand.Next(0, i);
                _deck.shufflingCards.Push(cards[randNumber]);
                cards.Remove(cards[randNumber]);
            }
        }

        public Card Deal()
        {
            return _deck.shufflingCards.Pop();
        }
    }
}
