using System;
using System.Collections.Generic;

namespace BlackjackConsoleGame
{
    public static class Presenter
    {
        public static string GetPlayerName()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.WriteLine(name + ", please press 'Enter' to start game!");
            Console.ReadKey();
            return name;
        }

        public static void GetHandsCards(Player computer,Player player)
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

        public static bool TakeCard()
        {
            string answer;
            Console.WriteLine("Take next card? y/n");
            answer = Console.ReadLine().ToUpper();

            if (answer == "Y")
            {
                return true;
            }
            return false;
        }

        public static void ShowWinner(Player winner)
        {
            if (winner != null)
            {
                Console.WriteLine("{0} WIN!", winner.Name);
            }
            if (winner == null)
            {
                Console.WriteLine("DRAW!");
            }
        }

        public static bool PlayAgain()
        {
            string answer;
            Console.WriteLine("Want play again? y/n");
            answer = Console.ReadLine().ToUpper();
            
            if (answer == "Y")
            {
                return true;
            }
            return false;
        }
    }
}
