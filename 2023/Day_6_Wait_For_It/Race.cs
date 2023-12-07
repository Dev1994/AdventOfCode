namespace Day_6_Wait_For_It;

public class Race(long time, long raceRecord)
{
    public long Time { get; set; } = time;

    public long CurrentRecord { get; set; } = raceRecord;

    public long GetNumberOfPossibleWaysToWin()
    {
        List<long> results = [];
        for (long i = 0; i <= Time; i++)
        {
            long result = (Time - i) * i;
            if (result > CurrentRecord)
                results.Add(i);
        }

        return results.Distinct().Count();
    }
}