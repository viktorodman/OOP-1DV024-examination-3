using System;
using System.Collections.Generic;

namespace TwentyOne
{
    /// <summary>
    /// Represents a Player
    /// </summary>
    public class Player
    {
        protected Hand _hand = new Hand();

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
                if (value <= 0 || value > Constants.BustValue)
                {
                    throw new InvalidOperationException("Stop value must be between 1 and 21");
                }
                
                _stopValue = value;
            } 
        }

        public int Score
        {
            get => _hand.HandValue;
        }

        public bool HasTwentyOne
        {
            get => _hand.HandValue == Constants.BustValue;   
        }

        public bool IsBusted
        {
            get => _hand.HandValue > Constants.BustValue;
        }

        public bool ShouldHit
        {
            get => _hand.HandValue < StopValue && !_hand.IsFull;
        }

        public Player(string name, int stopValue)
        {
            Name = name;
            StopValue = stopValue;
        }

        public List<Card> ThrowCards()
        {
            return _hand.EmptyHand();
        }

        public void ReceiveCard(Card card)
        {
            _hand.AddCard(card);
        }

        public override string ToString() => $"{Name}: {_hand}";
    }
}