using System;

namespace TwentyOne
{
    public class TwentyOneSimulator
    {
        public void Run()
        {
            try
            {
                Player p = new Player("Pelle");

                p.Hit(new Card(CardRank.Ten, CardSuit.Spades));
                p.Hit(new Card(CardRank.Nine, CardSuit.Hearts));
                p.Hit(new Card(CardRank.Two, CardSuit.Diamonds));

                System.Console.WriteLine(p.HandCount());
            }
            catch (Exception e)
            { 
                System.Console.WriteLine(e);
            }
        }
    }
}