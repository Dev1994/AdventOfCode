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

    public int GetTotalScratchcards(string[] lines)
    {
        List<ScratchCard> cards = new ();

        foreach (string line in lines)
            cards.Add(new ScratchCard(line));

        // Set copies based on originals
        for (int i = 0; i < cards.Count - 1; i++)
        {
            int id = cards[i].Id + 1;
            for (int j = 0; j < cards[i].MatchingNumbers.Count; j++)
            {
                if (cards.Any(c => c.Id == id))
                    cards.Where(c => c.Id == id).ToList().ForEach(c => c.Copies++);
                id++;
            }
        }

        // Set copies based of copies
        foreach (ScratchCard card in cards)
        {
            if (card.Copies == 0)
                continue;

            for (int i = 1; i <= card.Copies; i++)
            {
                int id = card.Id + 1;
                for (int j = 1; j <= card.MatchingNumbers.Count; j++)
                {
                    if (cards.Any(c => c.Id == id))
                        cards.Where(c => c.Id == id).ToList().ForEach(c => c.Copies++);
                    id++;
                }
            }
        }

        return cards.Select(c => c.Copies).Sum() + cards.Count;
    }
}