namespace Day_4_Scratchcards;

public class ScratchCard
{
    public ScratchCard(string line)
    {
        string[] splitScratchcard = line.Split(':');
        string[] splitNumbers = splitScratchcard[1].Split("|");

        string cardId = splitScratchcard[0].Replace("Card ", "");
        Id = int.Parse(cardId);

        foreach (string winningString in splitNumbers[0].Trim().Split(" ").Where(w => !string.IsNullOrWhiteSpace(w)))
            WinningNumbers.Add(int.Parse(winningString));

        foreach (string givenNumber in splitNumbers[1].Trim().Split(" ").Where(g => !string.IsNullOrWhiteSpace(g)))
            ScratchNumbers.Add(int.Parse(givenNumber));

        SetMatchingNumbers();
        SetPoints();
    }

    public int Id { get; set; }

    public int Points { get; set; }

    public List<int> WinningNumbers { get; set; } = new ();

    public List<int> ScratchNumbers { get; set; } = new ();

    public List<int> MatchingNumbers { get; set; } = new ();

    private void SetMatchingNumbers()
    {
        MatchingNumbers = WinningNumbers.Intersect(ScratchNumbers).ToList();
    }

    private void SetPoints()
    {
        int numberOfMatches = MatchingNumbers.Count;

        if (numberOfMatches == 1)
            Points = 1;

        if (numberOfMatches > 1)
        {
            Points = 1;
            for (int i = 0; i < numberOfMatches - 1; i++)
                Points = Points * 2;
        }
    }
}