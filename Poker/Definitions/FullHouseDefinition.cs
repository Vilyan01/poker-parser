using Poker.Data;
using System;
using System.Collections.Generic;

namespace Poker.Definitions
{
    class FullHouseDefinition : BaseHandDefinition
    {
        public override string HandIdentifier => "full_house";

        public override int PrimaryRank => 6;

        public override bool Conforms(Card[] cards)
        {
            // There will be a three of a kind and a pair.
            bool trip = false;
            bool pair = false;

            // Go through passed in cards and see if the three of a kind and pair are present.
            foreach (KeyValuePair<CardValue, int> kvp in HandMap(cards))
            {
                if (kvp.Value == 3)
                {
                    trip = true;
                }
                if (kvp.Value == 2)
                {
                    pair = true;
                }
            }

            // If both are found, it conforms.
            return trip && pair;
        }

        private int getTripValue(Hand hand)
        {
            foreach(KeyValuePair<CardValue, int> kvp in HandMap(hand.Cards))
            {
                if(kvp.Value == 3)
                {
                    return (int)kvp.Key;
                }
            }
            return -1; // Something went wrong
        }

        private int getPairValue(Hand hand)
        {
            foreach (KeyValuePair<CardValue, int> kvp in HandMap(hand.Cards))
            {
                if (kvp.Value == 2)
                {
                    return (int)kvp.Key;
                }
            }
            return -1; // Something went wrong
        }

        public override ComparisonResult EquivelanceComparison(Hand firstHand, Hand otherHand)
        {
            int firstTrip = getTripValue(firstHand);
            int secondTrip = getTripValue(otherHand);

            int firstPair = getPairValue(firstHand);
            int secondPair = getPairValue(otherHand);

            // If any of these conditions are met, something went wrong with the parsing, and we should
            // throw an exception.
            if(firstTrip == -1 || secondTrip == -1 || firstPair == -1 || secondPair == -1)
            {
                throw new InvalidHandException();
            }

            if(firstTrip > secondTrip)
            {
                return ComparisonResult.Better;
            } else if (firstTrip == secondTrip)
            {
                if(firstPair > secondPair)
                {
                    return ComparisonResult.Better;
                } else if (firstPair == secondPair)
                {
                    return ComparisonResult.Same;
                } else
                {
                    return ComparisonResult.Worse;
                }
            } else
            {
                return ComparisonResult.Worse;
            }
        }
    }
}
