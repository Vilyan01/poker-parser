# Poker Parser

This project provides functionality to take an array of cards and be able to parse it into a hand which provides information such as an ID and a generic rank based on standard poker hands.

## Useage

There are two steps involved in the process, the first being creating a `Hand` object. To do this, an array of five cards is passed into the `ParseHand` method of the client, which will validate the input to ensure five cards are present, and no duplicate cards are passed in to assume only one deck is being used. It is then checked against a set of definitions of standard poker hands to determine the highest hand that it conforms to.

```
var client = new PokerClient();
var cards =  new Card[] {
  new Card(Suit.Hearts, CardValue.Seven),
  new Card(Suit.Hearts, CardValue.Eight),
  new Card(Suit.Hearts, CardValue.Nine),
  new Card(Suit.Hearts, CardValue.Ten),
  new Card(Suit.Hearts, CardValue.Jack),
};

Hand hand = client.ParseHand(cards);
// hand.Definition.HandIdentifier == "straight_flush";
```

Once a hand is created, it can then be compared to other hands by calling the `CompareHands` method and passing in two hands. This will return a `ComparisonResult` enum with a value of either `Better`, `Same`, or `Worse` with regards to how the first hand passed in compares to the second hand.

```
Hand firstHand = ... // two pair
Hand secondHand = ... // three of a kind

ComparisonResult result = client.CompareHands(firstHand, secondHand);
// result == ComparisonResult.Worse
```
