using System;
using System.Collections.Generic;
using Poker.Data;
using Poker.Definitions;

namespace Poker.Managers
{
    public class HandManager
    {
        /// <summary>
        /// Parses a hand based on an input of five cards.
        /// </summary>
        /// <param name="definitions">The definitions to use for parsing.</param>
        /// <param name="cards">The cards to check</param>
        /// <returns></returns>
        public Hand ParseHand(List<IHandDefinition> definitions, Card[] cards)
        {
            // Validate that the hand has the correct amount of cards.
            if(cards.Length != 5)
            {
                throw new InvalidHandException();
            }

            // Validate that there are no duplicates.
            for(int i = 0; i < cards.Length; i++)
            {
                // Check the current card against the rest of the cards.
                for(int k = i + 1; k < cards.Length; k++)
                {
                   if(cards[i].CardSuit == cards[k].CardSuit && cards[i].Value == cards[k].Value)
                    {
                        throw new InvalidHandException();
                    }
                }
            }

            // Iterate through the definitions to find what hand
            foreach (var def in definitions)
            {
                if(def.Conforms(cards))
                {
                    return new Hand(def, cards);
                }
            }

            // Fallback return. It should have found something by now as the high card
            // definition is in the passed in definitions as well, but in the case
            // it is not, the hand should be a high card hand.
            return new Hand(new HighCardDefinition(), cards);
        }

        public ComparisonResult CompareHands(Hand firstHand, Hand secondHand)
        {
            // Check value of the definitions.
            if (firstHand.Definition.PrimaryRank > secondHand.Definition.PrimaryRank)
            {
                return ComparisonResult.Better;
            }
            else if (firstHand.Definition.PrimaryRank == secondHand.Definition.PrimaryRank)
            {
                // Rely on the definition to determine whether a hand is better or not
                // since it. We can use either first or second hand to invoke the equivelance
                // comparison.
                return firstHand.Definition.EquivelanceComparison(firstHand, secondHand);
            }
            else
            {
                // We can assume at this point it's worse, no need to check again
                return ComparisonResult.Worse;
            }
        }
    }
}
