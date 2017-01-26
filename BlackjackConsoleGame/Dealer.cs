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

        public void Shuffle()
        {
            for (int i = _deck.Cards.Count; i != 0; i--)
            {
                int randNumber = _rand.Next(0, i);
                _deck.ShufflingCards.Push(_deck.Cards[randNumber]);
                _deck.Cards.Remove(_deck.Cards[randNumber]);
            }
        }

        public Card Deal()
        {
            return _deck.ShufflingCards.Pop();
        }
    }
}
