using System;
using System.Collections.Generic;

namespace TwentyOne
{
    /// <summary>
    /// Represents a Player
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Represents the players hand
        /// </summary>
        /// <returns></returns>
        protected Hand _hand = new Hand();

        /// <summary>
        /// Represents the name of the player
        /// </summary>
        private string _name;

        /// <summary>
        /// Represents the stop value of the player
        /// </summary>
        private int _stopValue;

        /// <summary>
        /// Gets and sets the name of the player
        /// </summary>
        /// <value></value>
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

        /// <summary>
        /// Gets and Sets the stop values for the player
        /// </summary>
        /// <value></value>
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

        /// <summary>
        /// Gets the score of the current hand
        /// </summary>
        /// <value></value>
        public int Score
        {
            get => _hand.HandValue;
        }

        /// <summary>
        /// Checks if the player has five cards on the hand
        /// </summary>
        /// <value></value>
        public bool HasFiveCards
        {
            get => _hand.IsFull;
        }

        /// <summary>
        /// Checks if the player has twenty one on the hand
        /// </summary>
        /// <value></value>
        public bool HasTwentyOne
        {
            get => _hand.HandValue == Constants.BustValue;   
        }

        /// <summary>
        /// Checks if the players has a hand value greater than 21
        /// </summary>
        /// <value></value>
        public bool IsBusted
        {
            get => _hand.HandValue > Constants.BustValue;
        }

        /// <summary>
        /// Checks if the player should hit
        /// </summary>
        /// <value></value>
        public bool ShouldHit
        {
            get => _hand.HandValue < StopValue && !_hand.IsFull;
        }

        /// <summary>
        /// Initializes a new instance of Player
        /// </summary>
        /// <param name="name"></param>
        /// <param name="stopValue"></param>
        public Player(string name, int stopValue)
        {
            Name = name;
            StopValue = stopValue;
        }

        /// <summary>
        /// Removes and returns the cards on the players hand
        /// </summary>
        /// <returns></returns>
        public List<Card> ThrowCards()
        {
            return _hand.EmptyHand();
        }

        /// <summary>
        /// Adds the passed card to the players hand
        /// </summary>
        /// <param name="card"></param>
        public void ReceiveCard(Card card)
        {
            _hand.AddCard(card);
        }

        /// <summary>
        /// A string representation of the player
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{Name, -9}{" : ", -3}{_hand, -40}{"Score: " + Score}";
    }
}