using Poker.Data;
using System.Collections.Generic;

namespace Poker.Definitions
{
    abstract class BaseHandDefinition : IHandDefinition
    {
        public virtual string HandIdentifier { get; }

        public virtual int PrimaryRank { get; }

        public abstract bool Conforms(Card[] cards);

        public abstract ComparisonResult EquivelanceComparison(Hand firstHand, Hand otherHand);

        /// <summary>
        /// Helper method to sort card in terms of value and determin how many cards there are.
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        protected Dictionary<CardValue, int> HandMap(Card[] cards)
        {
            Dictionary<CardValue, int> counter = new Dictionary<CardValue, int>()
            {
                { CardValue.Ace, 0 },
                { CardValue.Two, 0 },
                { CardValue.Three, 0 },
                { CardValue.Four, 0 },
                { CardValue.Five, 0 },
                { CardValue.Six, 0 },
                { CardValue.Seven, 0 },
                { CardValue.Eight, 0 },
                { CardValue.Nine, 0 },
                { CardValue.Ten, 0 },
                { CardValue.Jack, 0 },
                { CardValue.Queen, 0 },
                { CardValue.King, 0 },
            };

            foreach (Card card in cards)
            {
                counter[card.Value]++;
            }

            return counter;
        }

        protected Dictionary<Suit, int> SuitMap(Card[] cards)
        {
            Dictionary<Suit, int> counter = new Dictionary<Suit, int>()
            {
                { Suit.Clubs, 0 },
                { Suit.Diamonds, 0 },
                { Suit.Hearts, 0 },
                { Suit.Spades, 0 },
            };

            foreach (Card card in cards)
            {
                counter[card.CardSuit]++;
            }

            return counter;
        }
    }
}
