string[] lines = File.ReadAllLines("./input.txt");

const int maxRed = 12;
const int maxGreen = 13;
const int maxBlue = 14;

Dictionary<int, bool> gamesResults = new ();
List<int> powersMinimums = new ();

foreach (string line in lines)
{
    // Get game id.
    string[] splitGame = line.Split(':');
    string game = splitGame[0].Replace("Game ", string.Empty);
    int gameId = int.Parse(game);
    gamesResults.Add(gameId, true);

    // Get game sets
    string[] sets = splitGame[1].Split(";");

    int minimumPossibleRed = 0;
    int minimumPossibleGreen = 0;
    int minimumPossibleBlue = 0;

    // Get set cubes
    foreach (string set in sets)
    {
        // Get round within a set.
        string[] rounds = set.Split(",", StringSplitOptions.TrimEntries);

        foreach (string round in rounds)
        {
            string cleanedRound;

            if (round.Contains("red"))
            {
                cleanedRound = round.Replace("red", string.Empty).Trim();
                int redCubes = int.Parse(cleanedRound);
                if (redCubes > maxRed)
                    gamesResults[gameId] = false;
                if (minimumPossibleRed < redCubes)
                    minimumPossibleRed = redCubes;
            }

            if (round.Contains("green"))
            {
                cleanedRound = round.Replace("green", string.Empty).Trim();
                int greenCubes = int.Parse(cleanedRound);
                if (greenCubes > maxGreen)
                    gamesResults[gameId] = false;
                if (minimumPossibleGreen < greenCubes)
                    minimumPossibleGreen = greenCubes;
            }

            if (round.Contains("blue"))
            {
                cleanedRound = round.Replace("blue", string.Empty).Trim();
                int blueCubes = int.Parse(cleanedRound);
                if (blueCubes > maxBlue)
                    gamesResults[gameId] = false;
                if (minimumPossibleBlue < blueCubes)
                    minimumPossibleBlue = blueCubes;
            }
        }
    }

    powersMinimums.Add(minimumPossibleRed * minimumPossibleGreen * minimumPossibleBlue);
}

Console.WriteLine($"Sum of minimum power of all games a are {powersMinimums.Sum()}");