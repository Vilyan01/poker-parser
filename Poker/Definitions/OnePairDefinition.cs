using Poker.Data;
using System;
using System.Collections.Generic;

namespace Poker.Definitions
{
    class OnePairDefinition : BaseHandDefinition
    {
        public override string HandIdentifier => "pair";

        public override int PrimaryRank => 1;

        public override bool Conforms(Card[] cards)
        {
            int pairCount = 0;
            foreach (KeyValuePair<CardValue, int> pair in HandMap(cards))
            {
                if (pair.Value == 2)
                {
                    pairCount++;
                }
            }
            return pairCount == 1;
        }

        private int getPairValue(Hand hand)
        {
            // Determine the card values of the pairs.
            foreach (KeyValuePair<CardValue, int> kvp in HandMap(hand.Cards))
            {
                if (kvp.Value == 2)
                {
                    return (int)kvp.Key;
                }
            }
            // Something went wrong, key was not found.
            return -1;
        }

        public override ComparisonResult EquivelanceComparison(Hand firstHand, Hand otherHand)
        {
            int firstHighestValue = getPairValue(firstHand);
            int secondHighestValue = getPairValue(otherHand);

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
