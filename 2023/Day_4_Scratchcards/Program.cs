using Day_4_Scratchcards;

string[] lines = File.ReadAllLines("./input.txt");

ScratchcardChecker scratchcardChecker = new ();

Console.WriteLine($"Sum of all points = {scratchcardChecker.GetSumOfPoints(lines)}");