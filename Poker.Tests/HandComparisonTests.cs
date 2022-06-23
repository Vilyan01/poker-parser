using System.Collections.Generic;
using Xunit;
using Poker.Managers;
using Poker.Data;
using Poker.Definitions;

namespace Poker.Tests
{
    public class HandComparisonTests
    {
        private HandManager handManager = new HandManager();
        // Just use the default hand definitions for tests.
        private List<IHandDefinition> definitions = new PokerClient().HandDefinitions;

        // Performs a comparison to check whether the first hand is better than the second hand.
        private void performComparison(Card[] firstHandCards, Card[] secondHandCards)
        {
            Hand handOne = handManager.ParseHand(definitions, firstHandCards);
            Hand handTwo = handManager.ParseHand(definitions, secondHandCards);

            Assert.Equal(ComparisonResult.Better, handManager.CompareHands(handOne, handTwo));
        }

        [Fact]
        public void HandComaprison_UsesPrimaryValueFirstPair()
        {
            // Pair of Aces
            Card[] firstHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Ace),
                new Card(Suit.Spades, CardValue.Ace),
                new Card(Suit.Diamonds, CardValue.Five),
                new Card(Suit.Spades, CardValue.Eight),
                new Card(Suit.Hearts, CardValue.Jack),
            };

            // Ace High
            Card[] secondHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Ace),
                new Card(Suit.Spades, CardValue.Seven),
                new Card(Suit.Diamonds, CardValue.Five),
                new Card(Suit.Spades, CardValue.Eight),
                new Card(Suit.Hearts, CardValue.Jack),
            };

            performComparison(firstHandCards, secondHandCards);
        }

        [Fact]
        public void HandComaprison_UsesPrimaryValueFirstTwoPair()
        {
            // Two Pair
            Card[] firstHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Ace),
                new Card(Suit.Spades, CardValue.Ace),
                new Card(Suit.Diamonds, CardValue.Five),
                new Card(Suit.Spades, CardValue.Five),
                new Card(Suit.Hearts, CardValue.Jack),
            };

            // Aces pair
            Card[] secondHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Ace),
                new Card(Suit.Spades, CardValue.Ace),
                new Card(Suit.Diamonds, CardValue.Five),
                new Card(Suit.Spades, CardValue.Eight),
                new Card(Suit.Hearts, CardValue.Jack),
            };

            performComparison(firstHandCards, secondHandCards);
        }

        [Fact]
        public void HandComaprison_UsesPrimaryValueFirstThreeOfKind()
        {
            // Three of a Kind
            Card[] firstHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Ace),
                new Card(Suit.Spades, CardValue.Ace),
                new Card(Suit.Diamonds, CardValue.Ace),
                new Card(Suit.Spades, CardValue.Five),
                new Card(Suit.Hearts, CardValue.Jack),
            };

            // Two Pair
            Card[] secondHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Ace),
                new Card(Suit.Spades, CardValue.Ace),
                new Card(Suit.Diamonds, CardValue.Five),
                new Card(Suit.Spades, CardValue.Five),
                new Card(Suit.Hearts, CardValue.Jack),
            };

            performComparison(firstHandCards, secondHandCards);
        }

        [Fact]
        public void HandComaprison_UsesPrimaryValueFirstStraight()
        {
            // Straight
            Card[] firstHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Two),
                new Card(Suit.Spades, CardValue.Three),
                new Card(Suit.Diamonds, CardValue.Four),
                new Card(Suit.Spades, CardValue.Five),
                new Card(Suit.Hearts, CardValue.Six),
            };

            // Three of a Kind
            Card[] secondHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Ace),
                new Card(Suit.Spades, CardValue.Ace),
                new Card(Suit.Diamonds, CardValue.Ace),
                new Card(Suit.Spades, CardValue.Five),
                new Card(Suit.Hearts, CardValue.Jack),
            };

            performComparison(firstHandCards, secondHandCards);
        }

        [Fact]
        public void HandComaprison_UsesPrimaryValueFirstFlush()
        {
            // Flush
            Card[] firstHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Two),
                new Card(Suit.Hearts, CardValue.Three),
                new Card(Suit.Hearts, CardValue.Nine),
                new Card(Suit.Hearts, CardValue.Eight),
                new Card(Suit.Hearts, CardValue.King),
            };

            // Straight
            Card[] secondHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Two),
                new Card(Suit.Spades, CardValue.Three),
                new Card(Suit.Diamonds, CardValue.Four),
                new Card(Suit.Spades, CardValue.Five),
                new Card(Suit.Hearts, CardValue.Six),
            };

            performComparison(firstHandCards, secondHandCards);
        }

        [Fact]
        public void HandComaprison_UsesPrimaryValueFirstFullHouse()
        {
            // FullHouse
            Card[] firstHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Jack),
                new Card(Suit.Spades, CardValue.Jack),
                new Card(Suit.Diamonds, CardValue.Nine),
                new Card(Suit.Clubs, CardValue.Jack),
                new Card(Suit.Hearts, CardValue.Nine),
            };

            // Flush
            Card[] secondHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Two),
                new Card(Suit.Hearts, CardValue.Three),
                new Card(Suit.Hearts, CardValue.Nine),
                new Card(Suit.Hearts, CardValue.Eight),
                new Card(Suit.Hearts, CardValue.King),
            };

            performComparison(firstHandCards, secondHandCards);
        }

        [Fact]
        public void HandComaprison_UsesPrimaryValueFirstFourOfAKind()
        {
            // 4 of a kind
            Card[] firstHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Jack),
                new Card(Suit.Spades, CardValue.Jack),
                new Card(Suit.Diamonds, CardValue.Jack),
                new Card(Suit.Clubs, CardValue.Jack),
                new Card(Suit.Hearts, CardValue.Nine),
            };

            // Full House
            Card[] secondHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Jack),
                new Card(Suit.Spades, CardValue.Jack),
                new Card(Suit.Diamonds, CardValue.Nine),
                new Card(Suit.Clubs, CardValue.Jack),
                new Card(Suit.Hearts, CardValue.Nine),
            };

            performComparison(firstHandCards, secondHandCards);
        }

        [Fact]
        public void HandComaprison_UsesPrimaryValueFirstStraightFlush()
        {
            // straight flush
            Card[] firstHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Two),
                new Card(Suit.Hearts, CardValue.Four),
                new Card(Suit.Hearts, CardValue.Three),
                new Card(Suit.Hearts, CardValue.Five),
                new Card(Suit.Hearts, CardValue.Six),
            };

            // 4 of a kind
            Card[] secondHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Jack),
                new Card(Suit.Spades, CardValue.Jack),
                new Card(Suit.Diamonds, CardValue.Jack),
                new Card(Suit.Clubs, CardValue.Jack),
                new Card(Suit.Hearts, CardValue.Nine),
            };

            performComparison(firstHandCards, secondHandCards);
        }

        // MARK - Equivelance testing.

        [Fact]
        public void HandComaprison_DeterminesHigherOfTwoHighCards()
        {
            // Ace high
            Card[] firstHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Ace),
                new Card(Suit.Spades, CardValue.Four),
                new Card(Suit.Diamonds, CardValue.Jack),
                new Card(Suit.Clubs, CardValue.King),
                new Card(Suit.Hearts, CardValue.Nine),
            };

            // King high
            Card[] secondHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Two),
                new Card(Suit.Spades, CardValue.Four),
                new Card(Suit.Diamonds, CardValue.Jack),
                new Card(Suit.Clubs, CardValue.King),
                new Card(Suit.Hearts, CardValue.Nine),
            };

            performComparison(firstHandCards, secondHandCards);
        }

        [Fact]
        public void HandComaprison_DeterminesHigherOfTwoPairs()
        {
            // Ace Pair
            Card[] firstHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Ace),
                new Card(Suit.Spades, CardValue.Ace),
                new Card(Suit.Diamonds, CardValue.Jack),
                new Card(Suit.Clubs, CardValue.King),
                new Card(Suit.Hearts, CardValue.Nine),
            };

            // King Pair
            Card[] secondHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.King),
                new Card(Suit.Spades, CardValue.Four),
                new Card(Suit.Diamonds, CardValue.Jack),
                new Card(Suit.Clubs, CardValue.King),
                new Card(Suit.Hearts, CardValue.Nine),
            };

            performComparison(firstHandCards, secondHandCards);
        }

        [Fact]
        public void HandComaprison_DeterminesHigherOfTwoTwoPairs()
        {
            // Ace, King Pair
            Card[] firstHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Ace),
                new Card(Suit.Spades, CardValue.Ace),
                new Card(Suit.Diamonds, CardValue.King),
                new Card(Suit.Clubs, CardValue.King),
                new Card(Suit.Hearts, CardValue.Nine),
            };

            // Ace, Queen Pair
            Card[] secondHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Ace),
                new Card(Suit.Spades, CardValue.Ace),
                new Card(Suit.Diamonds, CardValue.Queen),
                new Card(Suit.Clubs, CardValue.Queen),
                new Card(Suit.Hearts, CardValue.Nine),
            };

            performComparison(firstHandCards, secondHandCards);
        }

        [Fact]
        public void HandComaprison_DeterminesHigherOfTwoThreeOfAKind()
        {
            // Ace trips
            Card[] firstHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Ace),
                new Card(Suit.Spades, CardValue.Ace),
                new Card(Suit.Diamonds, CardValue.Ace),
                new Card(Suit.Clubs, CardValue.King),
                new Card(Suit.Hearts, CardValue.Nine),
            };

            // King trips
            Card[] secondHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Ace),
                new Card(Suit.Spades, CardValue.King),
                new Card(Suit.Diamonds, CardValue.King),
                new Card(Suit.Clubs, CardValue.King),
                new Card(Suit.Hearts, CardValue.Nine),
            };

            performComparison(firstHandCards, secondHandCards);
        }

        [Fact]
        public void HandComaprison_DeterminesHigherOfTwoStraight()
        {
            // 9 high straight
            Card[] firstHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Five),
                new Card(Suit.Spades, CardValue.Six),
                new Card(Suit.Diamonds, CardValue.Seven),
                new Card(Suit.Clubs, CardValue.Eight),
                new Card(Suit.Hearts, CardValue.Nine),
            };

            // 6 high straight
            Card[] secondHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Two),
                new Card(Suit.Spades, CardValue.Three),
                new Card(Suit.Diamonds, CardValue.Four),
                new Card(Suit.Clubs, CardValue.Five),
                new Card(Suit.Hearts, CardValue.Six),
            };

            performComparison(firstHandCards, secondHandCards);
        }

        [Fact]
        public void HandComaprison_DeterminesHigherOfTwoFlush()
        {
            // Jack high flush
            Card[] firstHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Seven),
                new Card(Suit.Hearts, CardValue.Three),
                new Card(Suit.Hearts, CardValue.Nine),
                new Card(Suit.Hearts, CardValue.Five),
                new Card(Suit.Hearts, CardValue.Jack),
            };

            // Ten high Flush
            Card[] secondHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Two),
                new Card(Suit.Hearts, CardValue.Eight),
                new Card(Suit.Hearts, CardValue.Four),
                new Card(Suit.Hearts, CardValue.Ten),
                new Card(Suit.Hearts, CardValue.Six),
            };

            performComparison(firstHandCards, secondHandCards);
        }

        [Fact]
        public void HandComaprison_DeterminesHigherOfTwoFullHouse()
        {
            // Ace trip full house
            Card[] firstHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Ace),
                new Card(Suit.Spades, CardValue.Ace),
                new Card(Suit.Diamonds, CardValue.Ace),
                new Card(Suit.Clubs, CardValue.Jack),
                new Card(Suit.Hearts, CardValue.Jack),
            };

            // Ten trip full house
            Card[] secondHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Ten),
                new Card(Suit.Spades, CardValue.Ten),
                new Card(Suit.Diamonds, CardValue.Ten),
                new Card(Suit.Clubs, CardValue.Three),
                new Card(Suit.Hearts, CardValue.Three),
            };

            performComparison(firstHandCards, secondHandCards);
        }

        [Fact]
        public void HandComaprison_DeterminesHigherOfTwoFourOfKind()
        {
            // Ace quad
            Card[] firstHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Ace),
                new Card(Suit.Spades, CardValue.Ace),
                new Card(Suit.Diamonds, CardValue.Ace),
                new Card(Suit.Clubs, CardValue.Ace),
                new Card(Suit.Hearts, CardValue.Jack),
            };

            // Ten quad
            Card[] secondHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Ten),
                new Card(Suit.Spades, CardValue.Ten),
                new Card(Suit.Diamonds, CardValue.Ten),
                new Card(Suit.Clubs, CardValue.Ten),
                new Card(Suit.Hearts, CardValue.Three),
            };

            performComparison(firstHandCards, secondHandCards);
        }

        [Fact]
        public void HandComaprison_DeterminesHigherOfTwoStraightFlush()
        {
            // Jack High SF
            Card[] firstHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Seven),
                new Card(Suit.Hearts, CardValue.Eight),
                new Card(Suit.Hearts, CardValue.Nine),
                new Card(Suit.Hearts, CardValue.Ten),
                new Card(Suit.Hearts, CardValue.Jack),
            };

            // Six High SF
            Card[] secondHandCards = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Two),
                new Card(Suit.Hearts, CardValue.Three),
                new Card(Suit.Hearts, CardValue.Four),
                new Card(Suit.Hearts, CardValue.Five),
                new Card(Suit.Hearts, CardValue.Six),
            };

            performComparison(firstHandCards, secondHandCards);
        }
    }
}
