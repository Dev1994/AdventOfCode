namespace Day_5_If_You_Give_A_Seed_A_Fertilizer;

public class Map(string[] splitMap)
{
    public long Destination { get; set; } = long.Parse((string) splitMap[0]);

    public long Source { get; set; } = long.Parse(splitMap[1]);

    public long Range { get; set; } = long.Parse((string) splitMap[2]);

    public bool ContainedInRange(long seed)
    {
        long max = Source + Range;
        if (seed < max && seed > Source)
            return true;

        return false;
    }
}