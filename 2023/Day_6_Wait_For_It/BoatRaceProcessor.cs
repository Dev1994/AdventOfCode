namespace Day_6_Wait_For_It;

public class BoatRaceProcessor(List<string> lines)
{
    public List<Race> Races { get; } = SetRaces(lines);

    public Race Race { get; } = GetSingleRace(lines);

    private long WinningNumbersMultiplied { get; set; }

    public long GetWaysToWinMultiplied()
    {
        foreach (long possibleWaysToWin in Races.Select(race => race.GetNumberOfPossibleWaysToWin()))
        {
            if (WinningNumbersMultiplied == 0)
                WinningNumbersMultiplied = possibleWaysToWin;
            else
                WinningNumbersMultiplied *= possibleWaysToWin;
        }

        return WinningNumbersMultiplied;
    }

    private static List<Race> SetRaces(List<string> lines)
    {
        List<string> times = lines.First().Replace("Time:", string.Empty).Trim().Split(" ").Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
        List<string> distances = lines[^1].Replace("Distance:", string.Empty).Trim().Split(" ").Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

        return times.Select((t, i) => new Race(int.Parse(t), int.Parse(distances[i]))).ToList();
    }

    private static Race GetSingleRace(List<string> lines)
    {
        string time = string.Empty;
        string distance = string.Empty;

        lines.First().Replace("Time:", string.Empty).Trim().Split(" ").Where(s => !string.IsNullOrWhiteSpace(s)).ToList().ForEach(t => time += t);
        lines[^1].Replace("Distance:", string.Empty).Trim().Split(" ").Where(s => !string.IsNullOrWhiteSpace(s)).ToList().ForEach(d => distance += d);

        if (time == null || distance == null)
            throw new Exception("Could not set time and distance for single race");

        return new Race(long.Parse(time), long.Parse(distance));
    }
}