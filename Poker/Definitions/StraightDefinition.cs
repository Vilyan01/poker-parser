using Poker.Data;
using Poker.Utils;
using System;
using System.Linq;

namespace Poker.Definitions
{
    class StraightDefinition : IHandDefinition
    {
        public string HandIdentifier => "straight";

        public int PrimaryRank => 4;

        public bool Conforms(Card[] cards)
        {
            // They should be all in a row.
            int currentValue = cards.First().IntegerValue();
            Array.Sort(cards, new CardValueComparer());

            // Skip the first since it's already the first value stored in currentValue
            foreach (Card c in cards.Skip(1))
            {
                if (c.IntegerValue() != currentValue + 1)
                {
                    return false;
                }
                currentValue = c.IntegerValue();
            }

            // It made it all the way through checking each value to make sure it was one
            // higher than the last.
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
            // Check which of the two hands has the highest high card.
            int firstHighestValue = getHighestValue(firstHand);
            int secondHighestValue = getHighestValue(otherHand);

            if (firstHighestValue == -1 || secondHighestValue == -1)
            {
                // Something went wrong, throw the generic hand invalid error.
                throw new InvalidHandException();
            }

            if (firstHighestValue > secondHighestValue)
            {
                return ComparisonResult.Better;
            }
            else if (firstHighestValue == secondHighestValue)
            {
                return ComparisonResult.Same;
            }
            else
            {
                return ComparisonResult.Worse;
            }
        }
    }
}
