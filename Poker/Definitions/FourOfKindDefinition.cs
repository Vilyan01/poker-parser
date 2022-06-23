using Poker.Data;
using System;
using System.Collections.Generic;

namespace Poker.Definitions
{
    class FourOfKindDefinition : BaseHandDefinition
    {
        public override string HandIdentifier => "four_of_a_kind";

        public override int PrimaryRank => 7;

        public override bool Conforms(Card[] cards)
        {
            foreach (KeyValuePair<CardValue, int> kvp in HandMap(cards))
            {
                // If there are any with four, its a four of a kind.
                if(kvp.Value == 4)
                {
                    return true;
                }
            }
            return false;
        }

        private int getHighestValue(Hand hand)
        {
            foreach (KeyValuePair<CardValue, int> pair in HandMap(hand.Cards))
            {
                if (pair.Value == 4)
                {
                    return (int)pair.Key;
                }
            }
            return -1;
        }

        public override ComparisonResult EquivelanceComparison(Hand firstHand, Hand otherHand)
        {
            // Given that there is only one deck it is not possible to have the same
            // three of a kind values between two hands, so this will be a easy case of higher wins.
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
