using Day_6_Wait_For_It;
using Shouldly;

namespace UnitTests._2023;

[TestClass]
public class WaitForIt
{
    #region PartOne

    [TestMethod]
    public void SetsRaceTimeAndDistance()
    {
        // Arrange
        string[] lines = File.ReadAllLines("./test_input.txt");

        // Act
        BoatRaceProcessor boatRaceProcessor = new (lines.ToList());

        // Assert
        boatRaceProcessor.Races.Count.ShouldBe(3);
        boatRaceProcessor.Races[0].Time.ShouldBe(7);
        boatRaceProcessor.Races[0].CurrentRecord.ShouldBe(9);

        boatRaceProcessor.Races[1].Time.ShouldBe(15);
        boatRaceProcessor.Races[1].CurrentRecord.ShouldBe(40);

        boatRaceProcessor.Races[2].Time.ShouldBe(30);
        boatRaceProcessor.Races[2].CurrentRecord.ShouldBe(200);
    }

    [TestMethod]
    public void GetsTheCorrectPossibleWinningRounds()
    {
        // Arrange
        string[] lines = File.ReadAllLines("./test_input.txt");
        BoatRaceProcessor boatRaceProcessor = new (lines.ToList());

        // Act
        long possibleWaysToWin = boatRaceProcessor.Races[0].GetNumberOfPossibleWaysToWin();

        // Assert
        possibleWaysToWin.ShouldBe(4);
    }

    [TestMethod]
    public void GetsTheCorrectPossibleWinningMultiplied()
    {
        // Arrange
        string[] lines = File.ReadAllLines("./test_input.txt");
        BoatRaceProcessor boatRaceProcessor = new (lines.ToList());

        // Act
        long waysToWinMultiplied = boatRaceProcessor.GetWaysToWinMultiplied();

        // Assert
        waysToWinMultiplied.ShouldBe(288);
    }

    #endregion


    #region PartTwo

    [TestMethod]
    public void SetsRaceTimeAndDistanceCombined()
    {
        // Arrange
        string[] lines = File.ReadAllLines("./test_input.txt");

        // Act
        BoatRaceProcessor boatRaceProcessor = new (lines.ToList());

        // Assert
        boatRaceProcessor.Race.Time.ShouldBe(71530);
        boatRaceProcessor.Race.CurrentRecord.ShouldBe(940200);
    }

    [TestMethod]
    public void GetsLongerRacePossibleWinCount()
    {
        // Arrange
        string[] lines = File.ReadAllLines("./test_input.txt");
        BoatRaceProcessor boatRaceProcessor = new (lines.ToList());

        // Act
        long numberOfPossibleWaysToWin = boatRaceProcessor.Race.GetNumberOfPossibleWaysToWin();

        // Assert
        numberOfPossibleWaysToWin.ShouldBe(71503);
    }

    #endregion
}