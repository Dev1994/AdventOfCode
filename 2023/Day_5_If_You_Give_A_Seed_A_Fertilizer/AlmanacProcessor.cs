namespace Day_5_If_You_Give_A_Seed_A_Fertilizer;

public class AlmanacProcessor
{
    public long GetClosestLocation(string[] lines, bool useRanges = false)
    {
        Almanac almanac = new (lines , useRanges);
        return almanac.GetClosestLocation(useRanges);
    }
}