using Day_5_If_You_Give_A_Seed_A_Fertilizer;

string[] lines = File.ReadAllLines("./input.txt");

AlmanacProcessor almanacProcessor = new ();
Console.WriteLine($"Closes location to plant is {almanacProcessor.GetClosestLocation(lines)}");
Console.WriteLine($"Closes location to plant with seed ranges is {almanacProcessor.GetClosestLocation(lines, true)}");