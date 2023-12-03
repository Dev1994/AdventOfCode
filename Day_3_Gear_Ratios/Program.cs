string[] lines = File.ReadAllLines("./input.txt");

List<int> engineParts = new();
List<Dictionary<string, (List<int> numberIndexes, bool isEnginePart)>> lineDictionariesList = new();
List<int> previousSpecialIndexes = new();

foreach (string line in lines)
{
    char[] lineChars = line.ToCharArray();

    List<int> numberIndexes = new();
    List<int> specialIndexes = new();

    // Get all the number indexes and special character indexes.
    for (int i = 0; i < lineChars.Length; i++)
    {
        char currentChar = lineChars[i];
        if (char.IsDigit(currentChar) && currentChar != '.')
            numberIndexes.Add(i);
        if (!char.IsDigit(currentChar) && currentChar != '.')
            specialIndexes.Add(i);
    }

    Dictionary<string, (List<int> numberIndexes, bool isEnginePart)> fullNumbersDictionary = new();
    string fullNumber = string.Empty;
    List<int> fullNumberIndexes = new();
    int previousIndex = -1;

    foreach (int numberIndex in numberIndexes)
    {
        if (numberIndex - 1 == previousIndex || previousIndex == -1)
        {
            fullNumber += lineChars[numberIndex];
            fullNumberIndexes.Add(numberIndex);
            previousIndex = numberIndex;
            continue;
        }

        if (fullNumber != string.Empty)
        {
            if (fullNumbersDictionary.ContainsKey(fullNumber))
                fullNumber = $"{fullNumber}_{numberIndex}";

            fullNumbersDictionary.Add(fullNumber, (new List<int>(fullNumberIndexes), HasSpecialPrefixOrPostfix(specialIndexes, fullNumberIndexes)));
            fullNumber = string.Empty;
            fullNumberIndexes.Clear();

            fullNumber += lineChars[numberIndex];
            fullNumberIndexes.Add(numberIndex);
            previousIndex = numberIndex;
        }
    }

    // Add last full number found to dictionary
    fullNumbersDictionary.Add(fullNumber, (fullNumberIndexes, HasSpecialPrefixOrPostfix(specialIndexes, fullNumberIndexes)));
    lineDictionariesList.Add(fullNumbersDictionary);

    // Check if previous line contains engine parts based on current line special characters
    if (lineDictionariesList.Count > 1)
    {
        Dictionary<string, (List<int> numberIndexes, bool isEnginePart)> previousLine = lineDictionariesList.ElementAt(lineDictionariesList.Count - 2);
        Dictionary<string, (List<int> numberIndexes, bool isEnginePart)> updatedPreviousLineDictionary = IsAdjacentToSpecialCharacter(specialIndexes, previousLine);

        // Update previous line dictionary
        lineDictionariesList[^2] = updatedPreviousLineDictionary;
    }

    if (lines[^2] == line)
        previousSpecialIndexes = new List<int>(specialIndexes);
}

Dictionary<string, (List<int> numberIndexes, bool isEnginePart)> lastLine = lineDictionariesList.ElementAt(lineDictionariesList.Count - 1);
Dictionary<string, (List<int> numberIndexes, bool isEnginePart)> updatedLastLineDictionary = IsAdjacentToSpecialCharacter(previousSpecialIndexes, lastLine);

// Update previous line dictionary
lineDictionariesList[^1] = updatedLastLineDictionary;

foreach (Dictionary<string, (List<int> numberIndexes, bool isEnginePart)> valueTuples in lineDictionariesList)
{
    List<int> list = valueTuples.Where(v => v.Value.isEnginePart).Select(v => int.Parse(RemovePostFixFromString(v.Key))).ToList();
    engineParts.AddRange(valueTuples.Where(v => v.Value.isEnginePart).Select(v => int.Parse(RemovePostFixFromString(v.Key))).ToList());
}

Console.WriteLine($"Sum of all engine parts = {engineParts.Sum()}");

static bool HasSpecialPrefixOrPostfix(List<int> specialIndexes, List<int> numberIndexes)
{
    return specialIndexes.Any(s => numberIndexes.Any(n => s == n - 1) || numberIndexes.Any(n => s == n + 1));
}

static bool HasSpecialCharacterInSameIndex(List<int> specialIndexes, List<int> numberIndexes)
{
    return specialIndexes.Any(s => numberIndexes.Any(n => s == n));
}

static string RemovePostFixFromString(string fullNumber)
{
    if (fullNumber.Contains("_"))
    {
        int index = fullNumber.IndexOf("_", StringComparison.Ordinal);
        int count = fullNumber.Length - index;
        return fullNumber.Remove(index, count);
    }

    return fullNumber;
}

static Dictionary<string, (List<int> numberIndexes, bool isEnginePart)> IsAdjacentToSpecialCharacter(List<int> specialIndexes, Dictionary<string, (List<int> numberIndexes, bool isEnginePart)> previousLine)
{
    Dictionary<string, (List<int> numberIndexes, bool isEnginePart)> updatedFullNumberDictionary = new();
    foreach (KeyValuePair<string, (List<int> numberIndexes, bool isEnginePart)> previousLineDictionary in previousLine)
    {
        List<int> currentIndexes = previousLineDictionary.Value.numberIndexes;
        updatedFullNumberDictionary.Add(previousLineDictionary.Key, (currentIndexes, HasSpecialCharacterInSameIndex(specialIndexes, currentIndexes) || HasSpecialPrefixOrPostfix(specialIndexes, currentIndexes)));
    }
    return updatedFullNumberDictionary;
}

// ..................../.................*.....453.....642....*.........828......@...94...........152/...*....790.......*.....445......../.....
// ...........................51.......681........................271..........719.......................964......399..426...............456...