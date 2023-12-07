using Day_7_Camel_Cards;

string[] lines = File.ReadAllLines("./input.txt");

CamelCards camelCards = new (lines.ToList());
Console.WriteLine($"You're total winnings are {camelCards.GetTotalWinnings()}");