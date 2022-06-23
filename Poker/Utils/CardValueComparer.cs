using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Poker.Data;

namespace Poker.Utils
{
    /// <summary>
    /// Used with a sorter to sort an array of card by value from low to high.
    /// </summary>
    public class CardValueComparer : IComparer<Card>
    {
        public int Compare([AllowNull] Card x, [AllowNull] Card y)
        {
            return x.IntegerValue().CompareTo(y.IntegerValue());
        }
    }
}
