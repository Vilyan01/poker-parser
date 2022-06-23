using Poker.Data;

namespace Poker.Definitions
{
    // Contains information about a specific hand.
    public interface IHandDefinition
    {
        // A unique identifier to refernce a type of hand.
        string HandIdentifier { get; }

        // A ranking in standard format from highest to lowest for comparison purposes.
        // i.e. Straight Flush = 8, Four of a Kind = 7, etc.
        int PrimaryRank { get; }

        /// <summary>
        /// Determins whether a set of cards conforms to a certain hand definition or not.
        /// </summary>
        /// <param name="cards">The list of five cards to check against</param>
        /// <returns>True if the hand conforms, false if not.</returns>
        bool Conforms(Card[] cards);

        /// <summary>
        /// In the event two hands are of the same type, this method will be used to
        /// determine which of the two hands are better.
        /// </summary>
        /// <param name="firstHand">The hand to use as a basis.</param>
        /// <param name="otherHand">The hand to compare the base hand to.</param>
        /// <returns>A result of how the firstHand compares to the otherHand</returns> 
        ComparisonResult EquivelanceComparison(Hand firstHand, Hand otherHand);
    }
}
