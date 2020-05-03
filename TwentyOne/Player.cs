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

        private int _stopValue;

        public string Name
        {
            get => _name;

            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidOperationException("Name cant be null or empty");
                }
                _name = value;
            }
        }

        public int StopValue
        {
            get => _stopValue;

            private set 
            {
                if (value <= 0 || value > 21)
                {
                    throw new InvalidOperationException("Stop value must be between 1 and 21");
                }
                
                _stopValue = value;
            } 
        }

        public bool IsDone
        {
            get => _hand.HandValue < StopValue && !_hand.IsFull;
        }

        public int HandCount()
        {
            return _hand.HandValue;
        }

        public void Hit(Card card)
        {
            _hand.AddCard(card);
        }

        public Player(string name, int stopValue)
        {
            Name = name;
            StopValue = stopValue;
        }

        public override string ToString() => $"{Name}: {_hand}";
    }
}