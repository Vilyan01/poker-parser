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
        /// Compares two hands and returns a comparison result enum that describes wether the
        /// first hand is better than, the same as, or worse than the second hand.
        /// </summary>
        /// <param name="firstHand">The first hand retrieved from the ParseHand method.</param>
        /// <param name="secondHand">The second hand to compare the first hand to</param>
        /// <returns>How the first hand compares to the second hand. Better, Same, or Worse.</returns>
        public ComparisonResult CompareHands(Hand firstHand, Hand secondHand)
        {
            return handManager.CompareHands(firstHand, secondHand);
        }
    }
}
