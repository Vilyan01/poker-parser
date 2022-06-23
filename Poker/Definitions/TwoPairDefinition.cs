using Poker.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Definitions
{
    class TwoPairDefinition : BaseHandDefinition
    {
        public override string HandIdentifier => "two_pair";

        public override int PrimaryRank => 2;

        public override bool Conforms(Card[] cards)
        {
            int pairCount = 0;
            foreach (KeyValuePair<CardValue, int> pair in HandMap(cards)) {
                if(pair.Value == 2) {
                    pairCount++;
                }
            }
            return pairCount == 2;
        }

        private int[] getSortedPairValues(Hand hand)
        {
            List<int> pairs = new List<int>();
            // Determine the card values of the pairs.
            foreach (KeyValuePair<CardValue, int> kvp in HandMap(hand.Cards))
            {
                if (kvp.Value == 2)
                {
                    pairs.Add((int)kvp.Key);
                }
            }
            int[] handArray = pairs.ToArray();
            Array.Sort(handArray);
            return handArray;
        }

        public override ComparisonResult EquivelanceComparison(Hand firstHand, Hand otherHand)
        {
            int[] firstHandArray = getSortedPairValues(firstHand);
            int[] secondHandArray = getSortedPairValues(otherHand);

            int firstHighest = firstHandArray.Last();
            int secondHighest = secondHandArray.Last();

            int firstLowest = firstHandArray.First();
            int secondLowest = secondHandArray.First();

            // Check the two pairs.
            if(firstHighest > secondHighest)
            {
                return ComparisonResult.Better;
            } else if(firstHighest == secondHighest)
            {
                // Fall back to second pair.
                if(firstLowest > secondLowest)
                {
                    return ComparisonResult.Better;
                } else if (firstLowest == secondLowest)
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
