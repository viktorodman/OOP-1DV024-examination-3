using System;

namespace TwentyOne
{
    public class TwentyOneSimulator
    {
        public void Run()
        {
            try
            {
               /*  Player p = new Player("Pelle", 15);

                p.Hit(new Card(CardRank.Ten, CardSuit.Spades));
                p.Hit(new Card(CardRank.Nine, CardSuit.Hearts));
                p.Hit(new Card(CardRank.Two, CardSuit.Diamonds));

                System.Console.WriteLine(p.HandCount()); */

                Game game = new Game(20);

                game.RunGame();
            }
            catch (Exception e)
            { 
                System.Console.WriteLine(e);
            }
        }
    }
}