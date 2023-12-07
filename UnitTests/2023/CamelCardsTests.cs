using Day_7_Camel_Cards;
using Day_7_Camel_Cards.Enums;
using Shouldly;

namespace UnitTests._2023;

[TestClass]
public class CamelCardsTests
{
    #region PartOne

    [TestMethod]
    public void SetsHigCard()
    {
        // Arrange
        List<char> cards = new() { '2', '3', '4', '5', '6' };

        // Act
        Hand hand = new(cards, default);

        // Assert
        hand.Type.ShouldBe(TYPE.HighCard);
    }

    [TestMethod]
    public void SetsOnePair()
    {
        // Arrange
        List<char> cards = new() { 'A', '2', '3', 'A', '4' };

        // Act
        Hand hand = new(cards, default);

        // Assert
        hand.Type.ShouldBe(TYPE.OnePair);
    }

    [TestMethod]
    public void SetsTwoPair()
    {
        // Arrange
        List<char> cards = new() { '2', '3', '4', '3', '2' };

        // Act
        Hand hand = new(cards, default);

        // Assert
        hand.Type.ShouldBe(TYPE.TwoPair);
    }

    [TestMethod]
    public void SetsThreeOfAKind()
    {
        // Arrange
        List<char> cards = new() { 'T', 'T', 'T', '9', '8' };

        // Act
        Hand hand = new(cards, default);

        // Assert
        hand.Type.ShouldBe(TYPE.ThreeOfAKind);
    }

    [TestMethod]
    public void SetsFullHouse()
    {
        // Arrange
        List<char> cards = new() { '2', '3', '3', '3', '2' };

        // Act
        Hand hand = new(cards, default);

        // Assert
        hand.Type.ShouldBe(TYPE.FullHouse);
    }

    [TestMethod]
    public void SetsFourOfAKind()
    {
        // Arrange
        List<char> cards = new() { 'A', 'A', '8', 'A', 'A' };

        // Act
        Hand hand = new(cards, default);

        // Assert
        hand.Type.ShouldBe(TYPE.FourOfAKind);
    }

    [TestMethod]
    public void SetsFiveOfAKind()
    {
        // Arrange
        List<char> cards = new() { 'A', 'A', 'A', 'A', 'A' };

        // Act
        Hand hand = new(cards, default);

        // Assert
        hand.Type.ShouldBe(TYPE.FiveOfAKind);
    }

    [TestMethod]
    public void SetsHandFromFile()
    {
        // Arrange
        List<string> lines = File.ReadAllLines("./test_input.txt").ToList();

        // Act
        CamelCards camelCards = new(lines);

        // Assert
        camelCards.Hands[0].Cards[0].ShouldBe('3');
        camelCards.Hands[0].Cards[1].ShouldBe('2');
        camelCards.Hands[0].Cards[2].ShouldBe('T');
        camelCards.Hands[0].Cards[3].ShouldBe('3');
        camelCards.Hands[0].Cards[4].ShouldBe('K');
        camelCards.Hands[0].Bet.ShouldBe(765);
    }

    [TestMethod]
    public void OrdersHandsByType()
    {
        // Arrange
        List<string> lines = File.ReadAllLines("./test_input.txt").ToList();

        // Act
        CamelCards camelCards = new(lines);

        // Assert
        camelCards.GetTotalWinnings();
    }

    #endregion
}