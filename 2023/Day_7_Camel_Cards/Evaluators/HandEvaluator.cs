using Day_7_Camel_Cards.Enums;

namespace Day_7_Camel_Cards.Evaluators;

public class HandEvaluator
{
    private static readonly Dictionary<char, int> CardRank = new()
    {
        { 'A', 14 },
        { 'K', 13 },
        { 'Q', 12 },
        { 'J', 11 },
        { 'T', 10 },
        { '9', 9 },
        { '8', 8 },
        { '7', 7 },
        { '6', 6 },
        { '5', 5 },
        { '4', 4 },
        { '3', 3 },
        { '2', 2 }
    };

    public TYPE EvaluateHandType(List<char> cards)
    {
        Dictionary<char, int> cardCount = CountCards(cards);

        int distinctCardCount = cardCount.Count;

        switch (distinctCardCount)
        {
            case 1:
                return TYPE.FiveOfAKind;

            case 2:
                // Check for Four of a Kind or Full House
                return cardCount.Any(entry => entry.Value == 4) ? TYPE.FourOfAKind :
                    cardCount.Any(entry => entry.Value == 3) ? TYPE.FullHouse : TYPE.TwoPair;

            case 3:
                // Check for Three of a Kind
                return cardCount.Any(entry => entry.Value == 3) ? TYPE.ThreeOfAKind : TYPE.TwoPair;

            case 4:
                return TYPE.OnePair;

            default:
                return TYPE.HighCard;
        }
    }

    public List<Hand> OrderByCardStrength(List<Hand> hands)
    {
        
        return new List<Hand>();
    }

    private static Dictionary<char, int> CountCards(List<char> cards)
    {
        Dictionary<char, int> cardCount = new ();

        foreach (char card in cards)
        {
            if (cardCount.ContainsKey(card))
                cardCount[card]++;
            else
                cardCount[card] = 1;
        }

        return cardCount;
    }

    private static int CompareCards(char card1, char card2)
    {
        int rank1 = CardRank.GetValueOrDefault(card1, 0);
        int rank2 = CardRank.GetValueOrDefault(card2, 0);

        return rank1.CompareTo(rank2);
    }
}