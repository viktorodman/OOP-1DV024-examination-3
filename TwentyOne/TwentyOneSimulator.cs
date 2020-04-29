using System;

namespace TwentyOne
{
    public class TwentyOneSimulator
    {
        public void Run()
        {
            try
            {
                Card test = new Card(CardRank.Ace, CardSuit.Spades);

                System.Console.WriteLine(test.ToString());
            }
            catch (Exception e)
            { 
                System.Console.WriteLine(e);
            }
        }
    }
}