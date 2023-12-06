namespace Day_6_Wait_For_It;

public class Race
{
    public Race(long time, long raceRecord)
    {
        Time = time;
        CurrentRecord = raceRecord;
    }

    public long Time { get; set; }

    public long CurrentRecord { get; set; }

    public long GetNumberOfPossibleWaysToWin()
    {
        List<long> results = new ();
        for (long i = 0; i <= Time; i++)
        {
            long result = (Time - i) * i;
            if (result > CurrentRecord)
                results.Add(i);
        }

        return results.Distinct().Count();
    }
}