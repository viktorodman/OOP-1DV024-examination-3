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

                p.Hit(new Card(CardRank.Ace, CardSuit.Spades));
                p.Hit(new Card(CardRank.Eight, CardSuit.Hearts));
                p.Hit(new Card(CardRank.Four, CardSuit.Diamonds));

                System.Console.WriteLine(p.HandCount());
            }
            catch (Exception e)
            { 
                System.Console.WriteLine(e);
            }
        }
    }
}