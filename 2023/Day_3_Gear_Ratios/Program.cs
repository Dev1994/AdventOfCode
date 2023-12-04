using Day_3_Gear_Ratios;string[] lines = File.ReadAllLines("./input.txt");

EngineParts engineParts = new ();

Console.WriteLine($"Sum of all engine parts = {engineParts.CalculateGearsSum(lines)}");