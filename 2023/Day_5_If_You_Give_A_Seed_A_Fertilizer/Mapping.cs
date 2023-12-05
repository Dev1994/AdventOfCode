namespace Day_5_If_You_Give_A_Seed_A_Fertilizer;

public class Mapping
{
    public Mapping(string title, List<string> lines)
    {
        // Find index of title
        int titleIndex = lines.IndexOf(title);

        if (titleIndex == -1)
            return;

        for (int i = titleIndex + 1; i < lines.Count; i++)
        {
            string line = lines[i];
            if (string.IsNullOrWhiteSpace(line))
                break;

            string[] splitMap = line.Split(" ");
            InputMaps.Add(new Map(splitMap));
        }
    }

    public List<Map> InputMaps { get; set; } = new ();

    public List<long> GetDestinationResult(List<long> seeds)
    {
        List<long> result = new ();
        foreach (long seed in seeds)
        {
            bool seedFoundInRange = false;
            foreach (Map inputMap in InputMaps)
            {
                if (inputMap.ContainedInRange(seed))
                {
                    result.Add(seed - inputMap.Source + inputMap.Destination);
                    seedFoundInRange = true;
                    continue;
                }
            }

            if (!seedFoundInRange)
                result.Add(seed);
        }

        return result;
    }
}