using Poker.Data;
using System;

namespace Poker.Definitions
{
    class HighCardDefinition : IHandDefinition
    {
        public string HandIdentifier => "high_card";

        public int PrimaryRank => 0;

        public bool Conforms(Card[] cards)
        {
            // There is always a high card.
            return true;
        }

        private int getHighestValue(Hand hand)
        {
            int highestValue = 0;
            foreach (Card c in hand.Cards)
            {
                if (c.IntegerValue() > highestValue)
                {
                    highestValue = c.IntegerValue();
                }
            }
            return highestValue;
        }

        public ComparisonResult EquivelanceComparison(Hand firstHand, Hand otherHand)
        {
            int highestValueFirst = getHighestValue(firstHand);
            int highestValueSecond = getHighestValue(otherHand);

            if(highestValueFirst > highestValueSecond)
            {
                return ComparisonResult.Better;
            } else if (highestValueFirst == highestValueSecond)
            {
                return ComparisonResult.Same;
            } else
            {
                return ComparisonResult.Worse;
            }
        }
    }
}
