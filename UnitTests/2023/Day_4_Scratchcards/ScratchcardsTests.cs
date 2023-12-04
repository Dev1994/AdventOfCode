using Day_4_Scratchcards;
using Shouldly;

namespace UnitTests._2023.Day_4_Scratchcards;

[TestClass]
public class ScratchcardsTests
{
    #region PartOne

    [TestMethod]
    public void GetsTheCardIdFromScratchcard()
    {
        // Arrange
        string[] lines = { "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53" };

        // Act
        ScratchCard card = new (lines[0]);

        // Assert
        card.Id.ShouldBe(1);
    }

    [TestMethod]
    public void GetsTheWinningNumbersFromScratchcard()
    {
        // Arrange
        string[] lines = { "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53" };

        // Act
        ScratchCard card = new (lines[0]);

        // Assert
        card.WinningNumbers[0].ShouldBe(41);
        card.WinningNumbers[1].ShouldBe(48);
        card.WinningNumbers[2].ShouldBe(83);
        card.WinningNumbers[3].ShouldBe(86);
        card.WinningNumbers[4].ShouldBe(17);
    }

    [TestMethod]
    public void GetsTheScratchNumbersFromScratchcard()
    {
        // Arrange
        string[] lines = { "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53" };

        // Act
        ScratchCard card = new (lines[0]);

        // Assert
        card.ScratchNumbers[0].ShouldBe(83);
        card.ScratchNumbers[1].ShouldBe(86);
        card.ScratchNumbers[2].ShouldBe(6);
        card.ScratchNumbers[3].ShouldBe(31);
        card.ScratchNumbers[4].ShouldBe(17);
        card.ScratchNumbers[5].ShouldBe(9);
        card.ScratchNumbers[6].ShouldBe(48);
        card.ScratchNumbers[7].ShouldBe(53);
    }

    [TestMethod]
    public void SetTheMatchingNumbersOfAScratchcard()
    {
        // Arrange
        string[] lines = { "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53" };

        // Act
        ScratchCard card = new (lines[0]);

        // Assert
        card.MatchingNumbers[0].ShouldBe(48);
        card.MatchingNumbers[1].ShouldBe(83);
        card.MatchingNumbers[2].ShouldBe(86);
        card.MatchingNumbers[3].ShouldBe(17);
    }

    [TestMethod]
    public void SetTheMatchingNumbersPointsOfAScratchcard()
    {
        // Arrange
        string[] lines = { "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53" };

        // Act
        ScratchCard card = new (lines[0]);

        // Assert
        card.Points.ShouldBe(8);
    }

    [TestMethod]
    public void CalculatesTheSumOfMatchingNumbersPointsOfAScratchcards()
    {
        // Arrange
        string[] lines =
        {
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
            "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
        };
        ScratchcardChecker scorecardChecker = new();

        // Act
        int sumOfPoints = scorecardChecker.GetSumOfPoints(lines);

        // Assert
        sumOfPoints.ShouldBe(13);
    }

    #endregion

    #region PartTwo

    [TestMethod]
    public void SetsInstancesBasedOnMatchingNumbersOfAScratchcard()
    {
        // Arrange
        string[] lines = {
            // 1 Instances
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
            // 2 Instances
            "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
            // 4 Instances
            "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
            // 8 Instances
            "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
            // 14 Instances
            "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
            // 1 Instances
            "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
        };
        ScratchcardChecker scorecardChecker = new();

        // Act
        int totalScratchcards = scorecardChecker.GetTotalScratchcards(lines);

        // Assert
        totalScratchcards.ShouldBe(30);
    }

    #endregion

}