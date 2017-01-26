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
            _dealer.Shuffle();
            StartGame();
        }

        public Game() : this(null)
        {
            
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
            if (!EndGame())
            {
                while ( !EndGame() && Presenter.TakeCard() )
                {
                    TakeNext(_player);
                }
            }

            if (!EndGame())
            {
                while (!EndGame() && _computer.Points < _player.Points )
                {
                    TakeNext(_computer);
                }
            }

            Presenter.ShowWinner(GetWinner());
            if (Presenter.PlayAgain())
            {
                new Game(_player.Name);
            }
        }

        public void TakeNext(Player player)
        {
            player.Cards.Add(_dealer.Deal());
            Presenter.GetHandsCards(_computer, _player);
        }

        public bool EndGame()
        {
            if (_player.Points >= 21 || _computer.Points >= 21)
            {
                return true;
            }
            return false;
        }

        public Player GetWinner()
        {
            if(_player.Points == _computer.Points)
            {
                return null;
            }
            
            if ( _player.Points == 21 || _player.Points < 21 & _player.Points > _computer.Points || _computer.Points > 21)
            {
                return _player;
            } 
                return _computer;          
        }
    }
}
