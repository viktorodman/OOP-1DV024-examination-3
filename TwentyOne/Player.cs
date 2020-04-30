using System;

namespace TwentyOne
{
    /// <summary>
    /// Represents a Player
    /// </summary>
    public class Player
    {
        private Hand _hand = new Hand();

        private string _name;

        public string Name
        {
            get => _name;

            private set => _name = value;
        }

        public int HandCount()
        {
            return _hand.HandValue;
        }

        public void Hit(Card card)
        {
            _hand.AddCard(card);
        }

        public Player(string name)
        {
            Name = name;
        }

        public override string ToString() => $"{Name}: {_hand}";
    }
}