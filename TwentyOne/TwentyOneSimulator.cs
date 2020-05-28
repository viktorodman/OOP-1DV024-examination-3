using System;
using System.Text.Encodings;

namespace TwentyOne
{
    /// <summary>
    /// Represents a twenty one simulator
    /// </summary>
    public class TwentyOneSimulator
    {
        /// <summary>
        /// Starts a new game of twenty one
        /// </summary>
        public void Run()
        {
            try
            {
                int numberOfPlayers = GameInput.EnterNumberOfPlayers();
                int dealerStopValue = GameInput.EnterPlayerStopValue("dealer");

                int[] playerStopValues = GameInput.EnterPlayerStopValues(numberOfPlayers);


                Game game = new Game(numberOfPlayers, dealerStopValue, playerStopValues);
                game.RunGame();
            }
            catch (Exception e)
            { 
                System.Console.WriteLine(e);
            }
        }
    }
}