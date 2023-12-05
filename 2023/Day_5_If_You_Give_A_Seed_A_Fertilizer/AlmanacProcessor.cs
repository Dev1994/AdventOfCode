namespace Day_5_If_You_Give_A_Seed_A_Fertilizer;

public class AlmanacProcessor
{
    public long GetClosestLocation(string[] lines)
    {
        Almanac almanac = new (lines);
        return almanac.GetClosestLocation();
    }
}