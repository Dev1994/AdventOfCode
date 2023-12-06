namespace Day_6_Wait_For_It;

public class BoatRaceProcessor
{
    public BoatRaceProcessor(List<string> lines)
    {
        SetRaces(lines);
        SetSingleRace(lines);
    }

    public List<Race> Races { get; set; } = new ();

    public Race Race { get; set; }

    private long WinningNumbersMultiplied { get; set; }

    public long GetWaysToWinMultiplied()
    {
        foreach (Race race in Races)
        {
            long possibleWaysToWin = race.GetNumberOfPossibleWaysToWin();
            if (WinningNumbersMultiplied == 0)
                WinningNumbersMultiplied = possibleWaysToWin;
            else
                WinningNumbersMultiplied *= possibleWaysToWin;
        }

        return WinningNumbersMultiplied;
    }

    private void SetRaces(List<string> lines)
    {
        List<string> times = lines.First().Replace("Time:", string.Empty).Trim().Split(" ").Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
        List<string> distances = lines[^1].Replace("Distance:", string.Empty).Trim().Split(" ").Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

        for (int i = 0; i < times.Count; i++)
            Races.Add(new Race(int.Parse(times[i]), int.Parse(distances[i])));
    }

    private void SetSingleRace(List<string> lines)
    {
        string time = string.Empty;
        string distance = string.Empty;

        lines.First().Replace("Time:", string.Empty).Trim().Split(" ").Where(s => !string.IsNullOrWhiteSpace(s)).ToList().ForEach(t => time += t);
        lines[^1].Replace("Distance:", string.Empty).Trim().Split(" ").Where(s => !string.IsNullOrWhiteSpace(s)).ToList().ForEach(d => distance += d);

        if (time == null || distance == null)
            throw new Exception("Could not set time and distance for single race");

        Race = new Race(long.Parse(time), long.Parse(distance));
    }
}