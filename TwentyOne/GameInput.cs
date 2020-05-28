using System;

namespace TwentyOne
{
    /// <summary>
    /// Represents Game input for a twenty one game
    /// </summary>
    public static class GameInput
    {
        /// <summary>
        /// A random number seed
        /// </summary>
        /// <returns></returns>
        private static Random rand = new Random();

        /// <summary>
        /// Asks the user to enter the number of players for the game
        /// </summary>
        /// <returns></returns>
        public static int EnterNumberOfPlayers()
        {
            int numberOfPlayers;
            System.Console.WriteLine("Enter the number of players | MIN 1 | MAX 10 players!");
            System.Console.Write("Number of players: ");
            bool correctNumber = int.TryParse(Console.ReadLine(), out numberOfPlayers);

            while(!correctNumber || numberOfPlayers < 1 || numberOfPlayers > 10)
            {
                System.Console.WriteLine("Please enter a number between 1 and 10");
                System.Console.Write("Number of players: ");
                correctNumber = int.TryParse(Console.ReadLine(), out numberOfPlayers);
            }
            return numberOfPlayers;
        }

        /// <summary>
        /// Asks the user to enter a players stop value
        /// </summary>
        /// <param name="playerName"></param>
        /// <returns></returns>
        public static int EnterPlayerStopValue(string playerName)
        {
            int dealerStopValue;
            System.Console.WriteLine($"Enter stop value for {playerName}  | MIN 1 | MAX 21!");
            System.Console.Write("Stop value: ");
            bool correctNumber = int.TryParse(Console.ReadLine(), out dealerStopValue);

            while(!correctNumber || dealerStopValue < 1 || dealerStopValue > 21)
            {
                System.Console.WriteLine("Please enter a number between 1 and 21");
                System.Console.Write("Stop value: ");
                correctNumber = int.TryParse(Console.ReadLine(), out dealerStopValue);
            }
            return dealerStopValue;
        }

        /// <summary>
        /// Asks the user to enter all the players stop values
        /// </summary>
        /// <param name="numberOfPlayers"></param>
        /// <returns></returns>
        public static int[] EnterPlayerStopValues(int numberOfPlayers)
        {
            int[] stopValues = new int[numberOfPlayers];
            System.Console.WriteLine("Do you want to enter player stop values manually or generate random stop values ?");
            bool shouldEnterStopValues = EnterYesOrNoQuestion("Enter player stop values manually");

            if (shouldEnterStopValues)
            {
                for (int i = 0; i < numberOfPlayers; i++)
                {
                    stopValues[i] = EnterPlayerStopValue($"Player {i + 1}");
                }   
            } else
            {
                for (int i = 0; i < numberOfPlayers; i++)
                {
                    stopValues[i] = rand.Next(1, Constants.BustValue + 1);
                }
            }

            return stopValues;
        }

        /// <summary>
        /// Asks the user if they want to enter
        /// the stop values for the player manually or
        /// if the stop values should be randomly generated
        /// 
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        private static bool EnterYesOrNoQuestion(string question)
        {
            bool answerIsYes = false;
            bool answerIsCorrectFormat = false;
            string answer;
            while (!answerIsCorrectFormat)
            {
                System.Console.Write($"{question}?(yes / no): ");
                answer = Console.ReadLine();

                if (answer == "yes" || answer == "no")
                {
                    answerIsYes =  answer == "yes";
                    answerIsCorrectFormat = true;
                }
            }
            
            return answerIsYes;
        }
    }
}