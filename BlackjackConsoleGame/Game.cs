using System;
using System.Collections.Generic;

namespace BlackjackConsoleGame
{
    public class Game
    {
        readonly Player computer = new Player("Dealer");
        private Player player;
        private Deck deck;
        private Dealer dealer;
        private List<Card> cards;
        public Game()
        {
            player = new Player(Presenter.GetPlayerName());

            deck = new Deck();
            dealer = new Dealer(deck);
            CreateCards();
            dealer.Shuffle(cards);
            StartGame();
        }

        void CreateCards()
        {
            cards = new List<Card>(Deck.quantityCards);

            for (int i = 0; i < Deck.quantityRanks; i++)
            {
                for (int j = 0; j < Deck.quantitySuits; j++)
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

                    cards.Add(new Card
                    {
                        Rank = (Ranks)i,
                        Suit = (Suits)j,
                        Point = points
                    });
                }
            }
        }

        void StartGame()
        {
            player.Cards.Add(dealer.Deal());
            computer.Cards.Add(dealer.Deal());
            player.Cards.Add(dealer.Deal());
            computer.Cards.Add(dealer.Deal());

            Presenter.GetHandsCards(computer,player);

            TakeNext();
            Presenter.ShowWinner(GetWinner());
        }

        public void TakeNext()
        {
            if (player.Points < 21 & computer.Points < 21 & computer.Points != 21)
            {       
                if (Presenter.TakeCard())
                {
                    player.Cards.Add(dealer.Deal());
                    Presenter.GetHandsCards(computer, player);
                    TakeNext();
                }
            }
            if (player.Points <= 21 & computer.Points < 21 & player.Points > computer.Points & player.Points != 21)
            {
                    while (computer.Points < player.Points & computer.Points < 21|| computer.Points == 21)
                    {
                    computer.Cards.Add(dealer.Deal());
                }
                Presenter.GetHandsCards(computer, player);
            }
        }

        public string GetWinner()
        {
            if ( player.Points == 21 & computer.Points != 21 || player.Points <= 21 & player.Points > computer.Points & computer.Points < 21 || computer.Points>21 & player.Points <= 21)
            {
                return "PLAYER WIN";
            } else
                {
                return "DEALER WIN";
                }            
        }
    }
}
