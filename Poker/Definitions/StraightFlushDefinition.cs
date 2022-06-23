using Poker.Data;
using Poker.Utils;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Poker.Definitions
{
    class StraightFlushDefinition : BaseHandDefinition
    {
        public override string HandIdentifier => "straight_flush";

        public override int PrimaryRank => 8;

        public override bool Conforms(Card[] cards)
        {
            // They should be all in a row.
            int currentValue = cards.First().IntegerValue();
            Array.Sort(cards, new CardValueComparer());

            // Skip the first since it's already the first value stored in currentValue
            foreach(Card c in cards.Skip(1))
            {
                if(c.IntegerValue() != currentValue + 1)
                {
                    return false;
                }
                currentValue = c.IntegerValue();
            }
            
            // It made it through the straight check, so we just need to verify it's a flush too.
            foreach(KeyValuePair<Suit, int> kvp in SuitMap(cards))
            {
                if(kvp.Value == 5)
                {
                    // It's a flush, too!
                    return true;
                }
            }

            // Failed the flush check.
            return false;
        }

        private int getHighestValue(Hand hand)
        {
            int highestValue = 0;
            foreach(Card c in hand.Cards)
            {
                if(c.IntegerValue() > highestValue)
                {
                    highestValue = c.IntegerValue();
                }
            }
            return highestValue;
        }

        public override ComparisonResult EquivelanceComparison(Hand firstHand, Hand otherHand)
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
