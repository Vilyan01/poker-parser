using Poker.Data;
using Poker.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Definitions
{
    class FlushDefinition : BaseHandDefinition
    {
        public override string HandIdentifier => "flush";

        public override int PrimaryRank => 5;

        public override bool Conforms(Card[] cards)
        {
            // Iterate through the suits and check for any with a value of 5.
            foreach(KeyValuePair<Suit, int> kvp in SuitMap(cards))
            {
                if(kvp.Value == 5)
                {
                    return true;
                }
            }

            return false;
        }

        private int highestValueCard(Hand hand)
        {
            Card[] handCards = hand.Cards;
            Array.Sort(handCards, new CardValueComparer());
            return handCards.Last().IntegerValue();
        }

        public override ComparisonResult EquivelanceComparison(Hand firstHand, Hand otherHand)
        {
            int highestFirst = highestValueCard(firstHand);
            int highestSecond = highestValueCard(otherHand);

            if (highestFirst > highestSecond)
            {
                return ComparisonResult.Better;
            } else if (highestFirst == highestSecond)
            {
                return ComparisonResult.Same;
            } else
            {
                return ComparisonResult.Worse;
            }
        }
    }
}
