using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Data
{
    /// <summary>
    /// This error represents an invalid hand. It gets thrown
    /// when not enough cards or too many cards are supplied to the
    /// hand parser.
    /// </summary>
    public class InvalidHandException : Exception { }
}
