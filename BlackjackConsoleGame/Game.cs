using System;


namespace BlackjackConsoleGame
{ //Вынести
    public class Game
    {
        readonly Player computer = new Player("Dealer");
        private Player player;
        private Deck deck;

        public Game()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.WriteLine(name + ", please press 'Enter' to start game!");
            Console.ReadKey();

            player = new Player(name);

            deck = new Deck();

            StartGame();
        }

        void StartGame()
        {
            player.TakeCard(deck.Deal());
            computer.TakeCard(deck.Deal());
            player.TakeCard(deck.Deal());
            computer.TakeCard(deck.Deal());

            GetHandsCards();

            TakeNext();
            Console.WriteLine(GetWinner());
            Console.ReadKey();
            new Game();
        }

        void GetHandsCards()
        {
            Console.WriteLine(" [{0}]", computer.Name);
            for (int i = 0; i < computer.Cards.Count; i++)
            {
                Console.WriteLine(" Card {0}: {1} of {2}", i + 1, computer.Cards[i].Rank, computer.Cards[i].Suit);
            }
            Console.WriteLine(" Total: {0}", computer.Points);

            Console.WriteLine(new string('-', 80));

            Console.WriteLine(" [{0}]", player.Name);
            for (int i = 0; i < player.Cards.Count; i++)
            {
                Console.WriteLine(" Card {0}: {1} of {2}", i + 1, player.Cards[i].Rank, player.Cards[i].Suit);
            }
            Console.WriteLine(" Total: {0}", player.Points);

        }

        public void TakeNext()
        {
            string takeCard;

            if (player.Points < 21 & computer.Points < 21)
            { 
                    Console.WriteLine("Take next card? y/n");
                    takeCard = Console.ReadLine();
                if (takeCard == "y")
                {
                    player.TakeCard(deck.Deal());
                    GetHandsCards();
                    TakeNext();
                }
                
            }
            if (player.Points <= 21 & computer.Points < 21 & player.Points > computer.Points)
            {
                    while (computer.Points < player.Points & computer.Points < 21|| computer.Points == 21)
                    {
                        computer.TakeCard(deck.Deal());
                    }

                    GetHandsCards();
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
