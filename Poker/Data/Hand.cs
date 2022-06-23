using System;
using System.Collections.Generic;
using System.Text;
using Poker.Definitions;

namespace Poker.Data
{
    /// <summary>
    /// Contains data about a specific hand.
    /// </summary>
    public class Hand
    {
        public IHandDefinition Definition { get; private set; }
        public Card[] Cards { get; private set; }

        public Hand(IHandDefinition definition, Card[] cards)
        {
            this.Definition = definition;
            this.Cards = cards;
        }
    }
}
