using System;
using Xunit;
using Poker;

namespace Poker.Tests
{
    public class PokerTests
    {
        private PokerClient Client = new PokerClient();

        [Fact]
        public void PokerClient_Initialization_HasAllHands()
        {
            // Should have nine different types of hand definitions.
            Assert.Equal(9, Client.HandDefinitions.Count);
        }
    }
}
