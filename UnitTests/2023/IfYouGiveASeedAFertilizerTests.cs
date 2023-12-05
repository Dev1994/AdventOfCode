using Day_5_If_You_Give_A_Seed_A_Fertilizer;
using Shouldly;

namespace UnitTests._2023;

[TestClass]
public class IfYouGiveASeedAFertilizerTests
{
    #region PartOne

    [TestMethod]
    public void SetsSeedsList()
    {
        // Arrange
        string[] lines = { "seeds: 79 14 55 13", "seed-to-soil map:", "50 98 2" };

        // Act
        Almanac almanac = new (lines);

        // Assert
        almanac.Seeds[0].ShouldBe(79);
        almanac.Seeds[1].ShouldBe(14);
        almanac.Seeds[2].ShouldBe(55);
        almanac.Seeds[3].ShouldBe(13);
    }

    [TestMethod]
    public void SetsSeedToSoilInputMaps()
    {
        // Arrange
        string[] lines = { "seeds: 79 14 55 13", " ", "seed-to-soil map:", "50 98 2", "52 50 48" };

        // Act
        Almanac almanac = new (lines);

        // Assert
        almanac.SeedToSoil.InputMaps[0].Source.ShouldBe(98);
        almanac.SeedToSoil.InputMaps[0].Destination.ShouldBe(50);
        almanac.SeedToSoil.InputMaps[0].Range.ShouldBe(2);

        almanac.SeedToSoil.InputMaps[1].Source.ShouldBe(50);
        almanac.SeedToSoil.InputMaps[1].Destination.ShouldBe(52);
        almanac.SeedToSoil.InputMaps[1].Range.ShouldBe(48);
    }

    [TestMethod]
    public void SetsSoilToFertilizerInputMaps()
    {
        // Arrange
        string[] lines = { "seeds: 79 14 55 13", " ", "soil-to-fertilizer map:", "0 15 37", "37 52 2", "39 0 15", " " };

        // Act
        Almanac almanac = new (lines);

        // Assert
        almanac.SoilToFertilizer.InputMaps[0].Source.ShouldBe(15);
        almanac.SoilToFertilizer.InputMaps[0].Destination.ShouldBe(0);
        almanac.SoilToFertilizer.InputMaps[0].Range.ShouldBe(37);

        almanac.SoilToFertilizer.InputMaps[1].Source.ShouldBe(52);
        almanac.SoilToFertilizer.InputMaps[1].Destination.ShouldBe(37);
        almanac.SoilToFertilizer.InputMaps[1].Range.ShouldBe(2);

        almanac.SoilToFertilizer.InputMaps[2].Source.ShouldBe(0);
        almanac.SoilToFertilizer.InputMaps[2].Destination.ShouldBe(39);
        almanac.SoilToFertilizer.InputMaps[2].Range.ShouldBe(15);
    }

    [TestMethod]
    public void SetsFertilizerToWaterInputMaps()
    {
        // Arrange
        string[] lines = { "seeds: 79 14 55 13", " ", "fertilizer-to-water map:", "49 53 8", "0 11 42", "42 0 7", "57 7 4", " " };

        // Act
        Almanac almanac = new (lines);

        // Assert
        almanac.FertilizerToWater.InputMaps[0].Source.ShouldBe(53);
        almanac.FertilizerToWater.InputMaps[0].Destination.ShouldBe(49);
        almanac.FertilizerToWater.InputMaps[0].Range.ShouldBe(8);

        almanac.FertilizerToWater.InputMaps[1].Source.ShouldBe(11);
        almanac.FertilizerToWater.InputMaps[1].Destination.ShouldBe(0);
        almanac.FertilizerToWater.InputMaps[1].Range.ShouldBe(42);

        almanac.FertilizerToWater.InputMaps[2].Source.ShouldBe(0);
        almanac.FertilizerToWater.InputMaps[2].Destination.ShouldBe(42);
        almanac.FertilizerToWater.InputMaps[2].Range.ShouldBe(7);

        almanac.FertilizerToWater.InputMaps[3].Source.ShouldBe(7);
        almanac.FertilizerToWater.InputMaps[3].Destination.ShouldBe(57);
        almanac.FertilizerToWater.InputMaps[3].Range.ShouldBe(4);
    }

    [TestMethod]
    public void SetsWaterToLightInputMaps()
    {
        // Arrange
        string[] lines = { "seeds: 79 14 55 13", " ", "water-to-light map:", "88 18 7", "18 25 70", " " };

        // Act
        Almanac almanac = new (lines);

        // Assert
        almanac.WaterToLight.InputMaps[0].Source.ShouldBe(18);
        almanac.WaterToLight.InputMaps[0].Destination.ShouldBe(88);
        almanac.WaterToLight.InputMaps[0].Range.ShouldBe(7);

        almanac.WaterToLight.InputMaps[1].Source.ShouldBe(25);
        almanac.WaterToLight.InputMaps[1].Destination.ShouldBe(18);
        almanac.WaterToLight.InputMaps[1].Range.ShouldBe(70);
    }

    [TestMethod]
    public void SetsLightToTemperatureInputMaps()
    {
        // Arrange
        string[] lines = { "seeds: 79 14 55 13", " ", "light-to-temperature map:", "45 77 23", "81 45 19", "68 64 13", " " };

        // Act
        Almanac almanac = new (lines);

        // Assert
        almanac.LightToTemperature.InputMaps[0].Source.ShouldBe(77);
        almanac.LightToTemperature.InputMaps[0].Destination.ShouldBe(45);
        almanac.LightToTemperature.InputMaps[0].Range.ShouldBe(23);

        almanac.LightToTemperature.InputMaps[1].Source.ShouldBe(45);
        almanac.LightToTemperature.InputMaps[1].Destination.ShouldBe(81);
        almanac.LightToTemperature.InputMaps[1].Range.ShouldBe(19);

        almanac.LightToTemperature.InputMaps[2].Source.ShouldBe(64);
        almanac.LightToTemperature.InputMaps[2].Destination.ShouldBe(68);
        almanac.LightToTemperature.InputMaps[2].Range.ShouldBe(13);
    }

    [TestMethod]
    public void SetsTemperatureToHumidityInputMaps()
    {
        // Arrange
        string[] lines = { "seeds: 79 14 55 13", " ", "temperature-to-humidity map:", "0 69 1", "1 0 69", " " };

        // Act
        Almanac almanac = new (lines);

        // Assert
        almanac.TemperatureToHumidity.InputMaps[0].Source.ShouldBe(69);
        almanac.TemperatureToHumidity.InputMaps[0].Destination.ShouldBe(0);
        almanac.TemperatureToHumidity.InputMaps[0].Range.ShouldBe(1);

        almanac.TemperatureToHumidity.InputMaps[1].Source.ShouldBe(0);
        almanac.TemperatureToHumidity.InputMaps[1].Destination.ShouldBe(1);
        almanac.TemperatureToHumidity.InputMaps[1].Range.ShouldBe(69);
    }

    [TestMethod]
    public void SetsHumidityToLocationInputMaps()
    {
        // Arrange
        string[] lines = { "seeds: 79 14 55 13", " ", "temperature-to-humidity map:", "0 69 1", "1 0 69", " ", "humidity-to-location map:", "60 56 37", "56 93 4", " " };

        // Act
        Almanac almanac = new (lines);

        // Assert
        almanac.TemperatureToHumidity.InputMaps[0].Source.ShouldBe(69);
        almanac.TemperatureToHumidity.InputMaps[0].Destination.ShouldBe(0);
        almanac.TemperatureToHumidity.InputMaps[0].Range.ShouldBe(1);
        almanac.TemperatureToHumidity.InputMaps[1].Source.ShouldBe(0);
        almanac.TemperatureToHumidity.InputMaps[1].Destination.ShouldBe(1);
        almanac.TemperatureToHumidity.InputMaps[1].Range.ShouldBe(69);

        almanac.HumidityToLocation.InputMaps[0].Source.ShouldBe(56);
        almanac.HumidityToLocation.InputMaps[0].Destination.ShouldBe(60);
        almanac.HumidityToLocation.InputMaps[0].Range.ShouldBe(37);
        almanac.HumidityToLocation.InputMaps[1].Source.ShouldBe(93);
        almanac.HumidityToLocation.InputMaps[1].Destination.ShouldBe(56);
        almanac.HumidityToLocation.InputMaps[1].Range.ShouldBe(4);
    }

    [TestMethod]
    public void GetsSeedToSoilIDestinationResult()
    {
        // Arrange
        string[] lines = { "seeds: 79 14 55 13", " ", "seed-to-soil map:", "50 98 2", "52 50 48" };
        Almanac almanac = new (lines);

        // Act
        List<long> destinationResult = almanac.SeedToSoil.GetDestinationResult(almanac.Seeds);

        // Assert
        destinationResult[0].ShouldBe(81);
        destinationResult[1].ShouldBe(14);
        destinationResult[2].ShouldBe(57);
        destinationResult[3].ShouldBe(13);
    }

    [TestMethod]
    public void GetClosestLocation()
    {
        // Arrange
        string[] lines = File.ReadAllLines("./testing_input.txt");
        Almanac almanac = new (lines);

        // Act
        long closestLocation = almanac.GetClosestLocation();

        // Assert
        closestLocation.ShouldBe(35);
    }

    #endregion

    #region PartTwo

    [TestMethod]
    public void SetsRangedSeedsList()
    {
        // Arrange
        string[] lines = { "seeds: 79 14 55 13", "seed-to-soil map:", "50 98 2" };

        // Act
        Almanac almanac = new(lines, true);

        // Assert
        // First set
        almanac.SeedsWithRanges.Keys.Count.ShouldBe(2);
        almanac.SeedsWithRanges.ToList()[0].Key.ShouldBe(79);
        almanac.SeedsWithRanges.ToList()[0].Value.ShouldBe(14);
        almanac.SeedsWithRanges.ToList()[1].Key.ShouldBe(55);
        almanac.SeedsWithRanges.ToList()[1].Value.ShouldBe(13);
    }

    [TestMethod]
    public void GetClosestLocationWithRanges()
    {
        // Arrange
        string[] lines = File.ReadAllLines("./testing_input.txt");
        Almanac almanac = new(lines, true);

        // Act
        long closestLocation = almanac.GetClosestLocation(true);

        // Assert
        closestLocation.ShouldBe(46);
    }

    #endregion
}