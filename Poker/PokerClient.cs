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

        public PokerClient()
        {
            handManager = new HandManager();
        }

        public Hand ParseHand(Card[] cards)
        {
            return handManager.ParseHand(HandDefinitions, cards);
        }
    }
}
