using Poker;
using Poker.Utils;
using Poker.Data;
using Xunit;
using System;

namespace Poker.Tests
{
    public class UtilTests
    {
        [Fact]
        public void CardValueComparer_SortsCardsCorrectly()
        {
            Card[] cardArray = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Ace),
                new Card(Suit.Diamonds, CardValue.Eight),
            };

            // This should place ace higher than eight.
            Array.Sort(cardArray, new CardValueComparer());
            Assert.Equal(CardValue.Eight, cardArray[0].Value);
        }
    }
}
