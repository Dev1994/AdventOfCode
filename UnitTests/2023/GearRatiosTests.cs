using Day_3_Gear_Ratios;
using Shouldly;

namespace UnitTests._2023;

[TestClass]
public class GearRatiosTests
{
    #region PartOne

    [TestMethod]
    public void SingleLineNoEngineParts()
    {
        // Arrange
        string[] lines = { "416.........................559...............417...............785.......900.......284...........503...796....992.........................." };
        EngineParts engineParts = new();

        // Act
        int sum = engineParts.CalculateGearsSum(lines);

        // Assert
        sum.ShouldBe(0);
    }

    [TestMethod]
    public void SingleLineWithEngineParts()
    {
        // Arrange
        string[] lines = { ".........702*....772............378..569.........&.49..606...14*..............$.453*.........307....*......$.....-.................995......" };
        EngineParts engineParts = new();

        // Act
        int sum = engineParts.CalculateGearsSum(lines);

        // Assert
        sum.ShouldBe(1169);
    }

    [TestMethod]
    public void DoubleLineNoEngineParts()
    {
        // Arrange
        string[] lines =
        {
            "416.........................559...............417...............785.......900.......284...........503...796....992..........................",
            "............470..161......508.....56...170.................................389.....544.....208.....98...............617...884..............."
        };
        EngineParts engineParts = new();

        // Act
        int sum = engineParts.CalculateGearsSum(lines);

        // Assert


        sum.ShouldBe(0);
    }

    [TestMethod]
    public void DoubleLinesWithSpecialAbove()
    {
        // Arrange
        string[] lines =
        {
            "..*.",
            "416."
        };
        EngineParts engineParts = new();

        // Act
        int sum = engineParts.CalculateGearsSum(lines);

        // Assert
        sum.ShouldBe(416);
    }

    [TestMethod]
    public void DoubleLinesWithSpecialBelow()
    {
        // Arrange
        string[] lines =
        {
            "416.",
            "..*."
        };
        EngineParts engineParts = new();

        // Act
        int sum = engineParts.CalculateGearsSum(lines);

        // Assert
        sum.ShouldBe(416);
    }

    [TestMethod]
    public void DoubleLinesWithAdjacentAbove()
    {
        // Arrange
        string[] lines =
        {
            ".../",
            "416."
        };
        EngineParts engineParts = new();

        // Act
        int sum = engineParts.CalculateGearsSum(lines);

        // Assert
        sum.ShouldBe(416);
    }

    [TestMethod]
    public void DoubleLinesWithAdjacentBelow()
    {
        // Arrange
        string[] lines =
        {
            "416.",
            ".../"
        };
        EngineParts engineParts = new();

        // Act
        int sum = engineParts.CalculateGearsSum(lines);

        // Assert
        sum.ShouldBe(416);
    }

    [TestMethod]
    public void MultipleLinesWithSpecialAbove()
    {
        // Arrange
        string[] lines =
        {
            "..*.",
            "416.",
            "....",
            "..*."
        };
        EngineParts engineParts = new();

        // Act
        int sum = engineParts.CalculateGearsSum(lines);

        // Assert
        sum.ShouldBe(416);
    }

    [TestMethod]
    public void MultipleLinesWithSpecialBelow()
    {
        // Arrange
        string[] lines =
        {
            "....",
            "416.",
            "..*.",
            "...."
        };
        EngineParts engineParts = new();

        // Act
        int sum = engineParts.CalculateGearsSum(lines);

        // Assert
        sum.ShouldBe(416);
    }

    [TestMethod]
    public void MultipleLinesWithAdjacentAbove()
    {
        // Arrange
        string[] lines =
        {
            ".../",
            "416.",
            "....",
            "...."
        };
        EngineParts engineParts = new();

        // Act
        int sum = engineParts.CalculateGearsSum(lines);

        // Assert
        sum.ShouldBe(416);
    }

    #endregion

    #region PartTwo 

    [TestMethod]
    public void FindsSingleGearSameLine()
    {
        // Arrange
        string[] lines = { ".....10*10...." };
        EngineParts engineParts = new();

        // Act
        int gearRatio = engineParts.CalculateGearsSum(lines);

        // Assert
        gearRatio.ShouldBe(100);
    }

    [TestMethod]
    public void FindsSingleGearDifferentLines()
    {
        // Arrange
        string[] lines =
        {
            "....",
            ".10.",
            "..*.",
            ".10.",
            "...."
        };
        EngineParts engineParts = new();

        // Act
        int gearRatio = engineParts.CalculateGearsSum(lines);

        // Assert
        gearRatio.ShouldBe(100);
    }

    #endregion
}