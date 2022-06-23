using Poker;
using Poker.Data;
using Xunit;

namespace Poker.Tests
{
    public class ClientTests
    {
        PokerClient client = new PokerClient();

        [Fact]
        public void Client_Roundtrip_DeterminesBestHands()
        {
            Card[] first = new Card[]
            {
                new Card(Suit.Hearts, CardValue.Two),
                new Card(Suit.Diamonds, CardValue.Two),
                new Card(Suit.Spades, CardValue.Eight),
                new Card(Suit.Clubs, CardValue.Eight),
                new Card(Suit.Diamonds, CardValue.Jack),
            };

            Card[] second = new Card[]
            {
                new Card(Suit.Hearts, CardValue.King),
                new Card(Suit.Diamonds, CardValue.King),
                new Card(Suit.Spades, CardValue.Four),
                new Card(Suit.Clubs, CardValue.Nine),
                new Card(Suit.Diamonds, CardValue.Queen),
            };

            Hand firstHand = client.ParseHand(first);
            Hand secondHand = client.ParseHand(second);

            Assert.Equal("two_pair", firstHand.Definition.HandIdentifier);
            Assert.Equal("pair", secondHand.Definition.HandIdentifier);

            Hand betterHand = client.CompareHands(firstHand, secondHand);
            Assert.Equal("two_pair", betterHand.Definition.HandIdentifier);
        }
    }
}
