using Day_6_Wait_For_It;

string[] lines = File.ReadAllLines("./input.txt");

BoatRaceProcessor boatRaceProcessor = new (lines.ToList());
Console.WriteLine($"Total of all winning rounds multiplied is {boatRaceProcessor.GetWaysToWinMultiplied()}");
Console.WriteLine($"The number of ways to win in the much longer race is {boatRaceProcessor.Race.GetNumberOfPossibleWaysToWin()}");