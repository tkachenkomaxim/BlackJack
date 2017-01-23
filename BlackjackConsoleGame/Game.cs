using System;
using System.Collections.Generic;

namespace BlackjackConsoleGame
{
    public class Game
    {
        private readonly Player _computer = new Player() { Name = "Dealer" };
        private Player _player;
        private Deck _deck;
        private Dealer _dealer;
        private List<Card> _cards;

        public Game(string playerName)
        {
            _player = new Player();
            if(playerName == null)
            {
                _player.Name = Presenter.GetPlayerName();
            }
            if(playerName != null)
            {
                _player.Name = playerName;
            }
            _deck = new Deck();
            _dealer = new Dealer(_deck);
            CreateCards();
            _dealer.Shuffle(_cards);
            StartGame();
        }

        public Game() : this(null)
        {
            
        }

        void CreateCards()
        {
            _cards = new List<Card>(Deck.quantityCards);
            int firstRankNumber = (int)Rank.Two;
            int lastRankNumber = (int) Rank.Ace;

            for (int i = firstRankNumber; i <= lastRankNumber; i++)
            {
                for (int j = 0; j < Deck.quantitySuits; j++)
                {
                    int points = 0;
                    if(i <= (int) Rank.Ten)
                    {
                        points = i;
                    }
                    if (i > (int)Rank.Ten)
                    {
                        switch ((Rank)i)
                        {
                            case Rank.Jack: points = 2; break;
                            case Rank.Queen: points = 3; break;
                            case Rank.King: points = 4; break;
                            case Rank.Ace: points = 11; break;
                        }
                    }
                        _cards.Add(new Card
                    {
                        Rank = (Rank)i,
                        Suit = (Suit)j,
                        Point = points
                    });
                }
            }
        }

        void StartGame()
        {
            _player.Cards.Add(_dealer.Deal());
            _computer.Cards.Add(_dealer.Deal());
            _player.Cards.Add(_dealer.Deal());
            _computer.Cards.Add(_dealer.Deal());

            CountinueGame();
        }

        void CountinueGame()
        {
            Presenter.GetHandsCards(_computer, _player);
            TakeNext();
            Presenter.ShowWinner(GetWinner());
            if (Presenter.PlayAgain())
            {
                new Game(_player.Name);
            }
        }

        public void TakeNext()
        {
            if (_player.Points < 21 & _computer.Points < 21 & _computer.Points != 21)
            {       
                if (Presenter.TakeCard())
                {
                    _player.Cards.Add(_dealer.Deal());
                    Presenter.GetHandsCards(_computer, _player);
                    TakeNext();
                }
            }
            if (_player.Points <= 21 & _computer.Points < 21 & _player.Points > _computer.Points & _player.Points != 21)
            {
                    while (_computer.Points < _player.Points & _computer.Points < 21|| _computer.Points == 21)
                    {
                    _computer.Cards.Add(_dealer.Deal());
                }
                Presenter.GetHandsCards(_computer, _player);
            }
        }

        public Player GetWinner()
        {
            if(_player.Points == _computer.Points)
            {
                return null;
            }
            if ( _player.Points == 21 & _computer.Points != 21 || _player.Points <= 21 & _player.Points > _computer.Points & _computer.Points < 21 || _computer.Points>21 & _player.Points <= 21)
            {
                return _player;
            } 
                return _computer;          
        }
    }
}
