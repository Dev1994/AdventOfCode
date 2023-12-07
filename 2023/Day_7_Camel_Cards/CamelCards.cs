using Day_7_Camel_Cards.Evaluators;

namespace Day_7_Camel_Cards;

public class CamelCards(List<string> lines)
{
    private readonly HandEvaluator _handEvaluator = new ();

    public List<Hand> Hands { get; } = SetHands(lines);

    public int GetTotalWinnings()
    {
        List<Hand> byTypes = Hands.OrderBy(h => h.Type).ToList();

        // TODO: Order hands so that hands of the same type are ordered weakest to strongest

        for (int i = 0; i < byTypes.Count; i++)
            byTypes[i].Rank = i + 1;

        int totalWinnings = 0;
        byTypes.ForEach(h => totalWinnings += h.Rank * h.Bet);

        return totalWinnings;
    }

    private static List<Hand> SetHands(List<string> lines)
    {
        List<Hand> hands = new ();

        foreach (string line in lines)
        {
            List<string> splitCardsFromBet = line.Split(" ").ToList();
            List<char> cards = splitCardsFromBet.First().Trim().ToCharArray().ToList();
            int bet = int.Parse(splitCardsFromBet.Last().Trim());

            hands.Add(new Hand(cards, bet));
        }

        return hands;
    }
}