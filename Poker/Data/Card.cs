using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Data
{
    /*
     * This class is responsible for  
     */
    public class Card
    {
        public Suit CardSuit { get; private set; }
        
        public CardValue Value { get; private set; }

        // Create a new card object from human readable methods.
        public Card(Suit suit, CardValue value)
        {
            this.CardSuit = suit;
            this.Value = value;
        }

        // Returns the integer value of the Value property for comparison purposes.
        public int IntegerValue()
        {
            // Cast the enum as its raw integer value.
            return (int)Value;
        }
    }
}
