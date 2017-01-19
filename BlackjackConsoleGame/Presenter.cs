using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            answer = Console.ReadLine();

            if (answer == "y" || answer == "Y")
                return true;
            else return false;
            
        }

        public static void ShowWinner(string winner)
        {
            Console.WriteLine(winner);
            PlayAgain();

        }

        public static void PlayAgain()
        {
            string answer;
            Console.WriteLine("Want play again? y/n");
            answer = Console.ReadLine();

            if (answer == "y" || answer == "Y")
            {
                new Game();
            }
        }


    }
}
