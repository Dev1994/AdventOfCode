namespace Day_5_If_You_Give_A_Seed_A_Fertilizer;

public class Almanac
{
    public Almanac(string[] lines, bool useRangedSeeds = false)
    {
        SetSeeds(lines.First(), useRangedSeeds);
        SetMappings(lines);
    }

    public List<long> Seeds { get; } = new ();

    public Dictionary<long, long> SeedsWithRanges { get; } = new ();

    public Mapping SeedToSoil { get; private set; }

    public Mapping SoilToFertilizer { get; private set; }

    public Mapping FertilizerToWater { get; private set; }

    public Mapping WaterToLight { get; private set; }

    public Mapping LightToTemperature { get; private set; }

    public Mapping TemperatureToHumidity { get; private set; }

    public Mapping HumidityToLocation { get; private set; }

    public long GetClosestLocation(bool useRanges = false)
    {
        List<long> soilResult;
        if (useRanges)
        {
            Console.WriteLine("Starting to get SeedToSoil with ranges");
            soilResult = SeedToSoil.GetDestinationResult(SeedsWithRanges);
        }
        else
        {
            Console.WriteLine("Starting to get SeedToSoil");
            soilResult = SeedToSoil.GetDestinationResult(Seeds);
        }

        Console.WriteLine("Starting to get SoilToFertilizer");
        List<long> fertilizerResult = SoilToFertilizer.GetDestinationResult(soilResult);

        Console.WriteLine("Starting to get FertilizerToWater");
        List<long> waterResult = FertilizerToWater.GetDestinationResult(fertilizerResult);

        Console.WriteLine("Starting to get WaterToLight");
        List<long> lightResult = WaterToLight.GetDestinationResult(waterResult);

        Console.WriteLine("Starting to get LightToTemperature");
        List<long> temperatureResult = LightToTemperature.GetDestinationResult(lightResult);

        Console.WriteLine("Starting to get TemperatureToHumidity");
        List<long> humidityResult = TemperatureToHumidity.GetDestinationResult(temperatureResult);

        Console.WriteLine("Starting to get HumidityToLocation");
        List<long> locationResult = HumidityToLocation.GetDestinationResult(humidityResult);

        return locationResult.Min();
    }

    private void SetSeeds(string line, bool useRangedSeeds)
    {
        string cleanedLine = line.Replace("seeds: ", "").Trim();
        char[] chars = cleanedLine.ToCharArray();

        string fullNumber = string.Empty;
        foreach (char character in chars)
        {
            if (char.IsDigit(character))
            {
                fullNumber += character;
                continue;
            }

            Seeds.Add(Convert.ToInt64(fullNumber));
            fullNumber = string.Empty;
        }

        Seeds.Add(long.Parse(fullNumber));

        if (!useRangedSeeds)
            return;

        for (int i = 0; i < Seeds.Count - 1; i++)
        {
            if (i % 2 == 0)
                SeedsWithRanges.Add(Seeds[i], Seeds[i + 1]);
        }
    }

    private void SetMappings(string[] lines)
    {
        List<string> noSeeds = lines.ToList().Slice(2, lines.Length - 2);

        SeedToSoil = new Mapping("seed-to-soil map:", noSeeds);
        SoilToFertilizer = new Mapping("soil-to-fertilizer map:", noSeeds);
        FertilizerToWater = new Mapping("fertilizer-to-water map:", noSeeds);
        WaterToLight = new Mapping("water-to-light map:", noSeeds);
        LightToTemperature = new Mapping("light-to-temperature map:", noSeeds);
        TemperatureToHumidity = new Mapping("temperature-to-humidity map:", noSeeds);
        HumidityToLocation = new Mapping("humidity-to-location map:", noSeeds);
    }
}