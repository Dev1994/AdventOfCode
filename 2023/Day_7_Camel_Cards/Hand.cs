using Day_7_Camel_Cards.Enums;
using Day_7_Camel_Cards.Evaluators;

namespace Day_7_Camel_Cards;

public class Hand
{
    public Hand(List<char> cards, int bet)
    {
        Cards = cards;
        Bet = bet;
        SetType();
    }

    public List<char> Cards { get; set; }

    public int Bet { get; set; }

    public TYPE Type { get; set; }

    public int Rank { get; set; }

    private void SetType()
    {
        HandEvaluator evaluator = new ();
        Type = evaluator.EvaluateHandType(Cards);
    }
}