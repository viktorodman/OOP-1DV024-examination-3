using System;

namespace TwentyOne
{
    /// <summary>
    /// Represents a tewnty on games result output
    /// </summary>
    public static class GameView
    {

        /// <summary>
        /// Displays the result of a round of twenty one
        /// </summary>
        /// <param name="winner">A player or dealer</param>
        /// <param name="loser">A player or dealer</param>
        public static void DisplayResult(Player winner, Player loser)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            System.Console.WriteLine(   
                                        $"{ResultDivider()}" + 
                                        $"{"Winner ", -7}{CreatePlayerString(winner)}\n" + 
                                        $"(stop value: {winner.StopValue})\n" +
                                        $"─────────────────────────────────────────────────────────────────────────────\n" +
                                        $"{"Loser ", -6} {CreatePlayerString(loser)}\n" +
                                        $"(stop value: {loser.StopValue})\n" +
                                        $"{ResultDivider()}"
                                    );
        }

        /// <summary>
        /// Creates a string that represents the result of a player or dealer
        /// </summary>
        /// <param name="player">A player or dealer</param>
        /// <returns></returns>
        private static string CreatePlayerString (Player player)
        {
            string busted = player.IsBusted ? " BUSTED!": "";
            return $"{player}{(player.IsBusted ? " BUSTED!": "")}";
        }
        
        /// <summary>
        /// return a line that divides the results
        /// </summary>
        /// <returns></returns>
        private static string ResultDivider() => $"═════════════════════════════════════════════════════════════════════════════\n";
    }
}