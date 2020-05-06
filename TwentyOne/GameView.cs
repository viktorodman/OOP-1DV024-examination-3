using System;

namespace TwentyOne
{
    public class GameView
    {
        public void DisplayResult(Player winner, Player loser)
        {
            System.Console.WriteLine($"Winner: {winner} Score: {winner.Score}");
            System.Console.WriteLine("");
            System.Console.WriteLine($"Loser: {loser} Score: {loser.Score}");
            System.Console.WriteLine($"_______________________________");
        }
    }
}