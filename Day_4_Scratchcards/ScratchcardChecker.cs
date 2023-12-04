namespace Day_4_Scratchcards;

public class ScratchcardChecker
{
    public int GetSumOfPoints(string[] lines)
    {
        List<ScratchCard> cards = new ();

        foreach (string line in lines)
            cards.Add(new ScratchCard(line));

        return cards.Select(c => c.Points).Sum();
    }
}