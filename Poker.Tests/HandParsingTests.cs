using System.Collections.Generic;
using Xunit;
using Poker.Managers;
using Poker.Data;
using Poker.Definitions;

namespace Poker.Tests
{
    public class HandParsingTests
    {

        private HandManager handManager = new HandManager();
        // Just use the default hand definitions for tests.
        private List<IHandDefinition> definitions = new PokerClient().HandDefinitions;

        [Fact]
        public void HandManager_HandParser_ThrowsInvalidHandErrorNotEnoughCards()
        {
            Card[] cards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Ace),
                new Card(Suit.Spades, CardValue.Two),
            };
            Assert.Throws<InvalidHandException>(() => handManager.ParseHand(definitions, cards));
        }

        [Fact]
        public void HandManager_HandParser_ThrowsInvalidHandErrorTooManyCards()
        {
            Card[] cards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Ace),
                new Card(Suit.Spades, CardValue.Two),
                new Card(Suit.Diamonds, CardValue.Five),
                new Card(Suit.Spades, CardValue.Eight),
                new Card(Suit.Hearts, CardValue.Jack),
                new Card(Suit.Clubs, CardValue.Seven),
            };
            Assert.Throws<InvalidHandException>(() => handManager.ParseHand(definitions, cards));
        }

        [Fact]
        public void HandManager_HandParser_ThrowsInvalidHandErrorSameCardAdded()
        {
           Card[] cards = new Card[]
           {
                new Card(Suit.Hearts, CardValue.Ace),
                new Card(Suit.Spades, CardValue.Two),
                new Card(Suit.Diamonds, CardValue.Five),
                new Card(Suit.Spades, CardValue.Eight),
                new Card(Suit.Spades, CardValue.Eight), // This card already is in the hand.
           };
           Assert.Throws<InvalidHandException>(() => handManager.ParseHand(definitions, cards));
        }

        [Fact]
        public void HandManager_HandParser_FindsHighCard()
        {
            // Ace high.
            Card[] cards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Ace),
                new Card(Suit.Spades, CardValue.Two),
                new Card(Suit.Diamonds, CardValue.Five),
                new Card(Suit.Spades, CardValue.Eight),
                new Card(Suit.Clubs, CardValue.Seven),
            };
            Hand result = handManager.ParseHand(definitions, cards);
            Assert.Equal("high_card", result.Definition.HandIdentifier);
        }

        [Fact]
        public void HandManager_HandParser_FindsPair()
        {
            // Ace high.
            Card[] cards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Ace),
                new Card(Suit.Spades, CardValue.Two),
                new Card(Suit.Diamonds, CardValue.Five),
                new Card(Suit.Spades, CardValue.Eight),
                new Card(Suit.Clubs, CardValue.Eight),
            };
            Hand result = handManager.ParseHand(definitions, cards);
            Assert.Equal("pair", result.Definition.HandIdentifier);
        }

        [Fact]
        public void HandManager_HandParser_FindsTwoPair()
        {
            // Ace high.
            Card[] cards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Ace),
                new Card(Suit.Spades, CardValue.Five),
                new Card(Suit.Diamonds, CardValue.Five),
                new Card(Suit.Spades, CardValue.Eight),
                new Card(Suit.Clubs, CardValue.Eight),
            };
            Hand result = handManager.ParseHand(definitions, cards);
            Assert.Equal("two_pair", result.Definition.HandIdentifier);
        }

        [Fact]
        public void HandManager_HandParser_FindsThreeOfKind()
        {
            // Ace high.
            Card[] cards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Ace),
                new Card(Suit.Spades, CardValue.Five),
                new Card(Suit.Diamonds, CardValue.Eight),
                new Card(Suit.Spades, CardValue.Eight),
                new Card(Suit.Clubs, CardValue.Eight),
            };
            Hand result = handManager.ParseHand(definitions, cards);
            Assert.Equal("three_of_a_kind", result.Definition.HandIdentifier);
        }

        [Fact]
        public void HandManager_HandParser_FindsStraight()
        {
            // Ace high.
            Card[] cards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Two),
                new Card(Suit.Spades, CardValue.Three),
                new Card(Suit.Diamonds, CardValue.Four),
                new Card(Suit.Spades, CardValue.Five),
                new Card(Suit.Clubs, CardValue.Six),
            };
            Hand result = handManager.ParseHand(definitions, cards);
            Assert.Equal("straight", result.Definition.HandIdentifier);
        }

        [Fact]
        public void HandManager_HandParser_RequiresFiveCardsForStraight()
        {
            // Ace high.
            Card[] cards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Two),
                new Card(Suit.Spades, CardValue.Three),
                new Card(Suit.Diamonds, CardValue.Four),
                new Card(Suit.Spades, CardValue.Five),
                new Card(Suit.Clubs, CardValue.Ace),
            };
            Hand result = handManager.ParseHand(definitions, cards);
            Assert.Equal("high_card", result.Definition.HandIdentifier);
        }

        [Fact]
        public void HandManager_HandParser_FindsFlush()
        {
            // Ace high.
            Card[] cards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Ace),
                new Card(Suit.Hearts, CardValue.Three),
                new Card(Suit.Hearts, CardValue.Eight),
                new Card(Suit.Hearts, CardValue.Five),
                new Card(Suit.Hearts, CardValue.Nine),
            };
            Hand result = handManager.ParseHand(definitions, cards);
            Assert.Equal("flush", result.Definition.HandIdentifier);
        }

        [Fact]
        public void HandManager_HandParser_FindsFullHouse()
        {
            // Ace high.
            Card[] cards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Ace),
                new Card(Suit.Spades, CardValue.Ace),
                new Card(Suit.Clubs, CardValue.Ace),
                new Card(Suit.Hearts, CardValue.Five),
                new Card(Suit.Diamonds, CardValue.Five),
            };
            Hand result = handManager.ParseHand(definitions, cards);
            Assert.Equal("full_house", result.Definition.HandIdentifier);
        }

        [Fact]
        public void HandManager_HandParser_FindsFourOfKind()
        {
            // Ace high.
            Card[] cards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Ace),
                new Card(Suit.Spades, CardValue.Ace),
                new Card(Suit.Clubs, CardValue.Ace),
                new Card(Suit.Diamonds, CardValue.Ace),
                new Card(Suit.Diamonds, CardValue.Five),
            };
            Hand result = handManager.ParseHand(definitions, cards);
            Assert.Equal("four_of_a_kind", result.Definition.HandIdentifier);
        }

        [Fact]
        public void HandManager_HandParser_FindsStraightFlush()
        {
            // Ace high.
            Card[] cards = new Card[]
            {
                new Card(Suit.Diamonds, CardValue.Two),
                new Card(Suit.Diamonds, CardValue.Three),
                new Card(Suit.Diamonds, CardValue.Four),
                new Card(Suit.Diamonds, CardValue.Six),
                new Card(Suit.Diamonds, CardValue.Five),
            };
            Hand result = handManager.ParseHand(definitions, cards);
            Assert.Equal("straight_flush", result.Definition.HandIdentifier);
        }
    }
}
