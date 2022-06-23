using System.Collections.Generic;
using Poker.Definitions;
using Poker.Data;
using Poker.Managers;

namespace Poker
{
    public class PokerClient
    {
        private HandManager handManager;

        /// <summary>
        /// Set of all poker hand definitions in order from highest to lowest.
        /// </summary>
        public List<IHandDefinition> HandDefinitions
        {
            get
            {
                return new List<IHandDefinition>()
                {
                    new StraightFlushDefinition(),
                    new FourOfKindDefinition(),
                    new FullHouseDefinition(),
                    new FlushDefinition(),
                    new StraightDefinition(),
                    new ThreeOfKindDefinition(),
                    new TwoPairDefinition(),
                    new OnePairDefinition(),
                    new HighCardDefinition(),
                };
            }
        }

        /// <summary>
        /// Default PokerClient constructor.
        /// </summary>
        public PokerClient()
        {
            handManager = new HandManager();
        }

        /// <summary>
        /// Parses an array of cards into a proper hand object, which will classify
        /// the hand as a pair, two pair, straight, etc.
        /// </summary>
        /// <param name="cards">An array of 5 cards to be passed in.</param>
        /// <returns>The parsed hand object containing a definition and the cards.</returns>
        public Hand ParseHand(Card[] cards)
        {
            return handManager.ParseHand(HandDefinitions, cards);
        }

        /// <summary>
        /// Compares two hands and returns the higher of the two hands.
        /// </summary>
        /// <param name="firstHand">The first hand retrieved from the ParseHand method.</param>
        /// <param name="secondHand">The second hand to compare the first hand to</param>
        /// <returns>The higher of the two hands.</returns>
        public Hand CompareHands(Hand firstHand, Hand secondHand)
        {
            ComparisonResult result = handManager.CompareHands(firstHand, secondHand);
            switch (result)
            {
                case ComparisonResult.Better:
                    return firstHand;
                case ComparisonResult.Worse:
                    return secondHand;
                default:
                    return null; // Same case falls into this.
            }
        }
    }
}
