using System;

namespace TwentyOne
{
    public class TwentyOneSimulator
    {
        public void Run()
        {
            try
            {
                Deck d = new Deck();

                d.Shuffle();

                System.Console.WriteLine(d.ToString());
            }
            catch (Exception e)
            { 
                System.Console.WriteLine(e);
            }
        }
    }
}