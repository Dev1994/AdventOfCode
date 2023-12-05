namespace Day_5_If_You_Give_A_Seed_A_Fertilizer;

public class Map
{
    public Map(string[] splitMap)
    {
        Destination = long.Parse(splitMap[0]);
        Source = long.Parse(splitMap[1]);
        Range = long.Parse(splitMap[2]);
    }

    public long Destination { get; set; }

    public long Source { get; set; }

    public long Range { get; set; }

    public bool ContainedInRange(long seed)
    {
        return Enumerable.Range(Source, Range).Contains(seed);
    }
}