string[] lines = File.ReadAllLines("./input.txt");
int calibrationSum = 0;

Dictionary<string, string> numbers = new ()
{
    { "one", "1" },
    { "two", "2" },
    { "three", "3" },
    { "four", "4" },
    { "five", "5" },
    { "six", "6" },
    { "seven", "7" },
    { "eight", "8" },
    { "nine", "9" }
};

List<string> listNumbers = new () { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
List<string> reversedNumbers = new () { "eno", "owt", "eerht", "ruof", "evif", "xis", "neves", "thgie", "enin" };

foreach (string line in lines)
{
    Console.WriteLine(line);
    string wordsToNumbers = line;
    string cleanedLine = string.Empty;
    string firstValue = string.Empty;
    string firstNumber = string.Empty;
    string firstNumberFromBack = string.Empty;

    for (int i = 0; i < wordsToNumbers.Length; i++)
    {
        firstValue += wordsToNumbers[i];
        foreach (string key in numbers.Keys)
        {
            if (char.IsDigit(wordsToNumbers[i]) ||
                firstValue.Contains(listNumbers[0]) ||
                firstValue.Contains(listNumbers[1]) ||
                firstValue.Contains(listNumbers[2]) ||
                firstValue.Contains(listNumbers[3]) ||
                firstValue.Contains(listNumbers[4]) ||
                firstValue.Contains(listNumbers[5]) ||
                firstValue.Contains(listNumbers[6]) ||
                firstValue.Contains(listNumbers[7]) ||
                firstValue.Contains(listNumbers[8]))
            {
                firstNumber = firstValue;
                break;
            }
        }
    }

    firstValue = string.Empty;
    for (int i = wordsToNumbers.Length - 1; i >= 0; i--)
    {
        firstValue += wordsToNumbers[i];
        if (char.IsDigit(wordsToNumbers[i]) ||
            firstValue.Contains(reversedNumbers[0]) ||
            firstValue.Contains(reversedNumbers[1]) ||
            firstValue.Contains(reversedNumbers[2]) ||
            firstValue.Contains(reversedNumbers[3]) ||
            firstValue.Contains(reversedNumbers[4]) ||
            firstValue.Contains(reversedNumbers[5]) ||
            firstValue.Contains(reversedNumbers[6]) ||
            firstValue.Contains(reversedNumbers[7]) ||
            firstValue.Contains(reversedNumbers[8]))
        {
            firstNumberFromBack = Reverse(firstValue);
            break;
        }
    }

    wordsToNumbers = firstNumber + firstNumberFromBack;

    foreach (string numbersKey in numbers.Keys)
        wordsToNumbers = wordsToNumbers.Replace(numbersKey, numbers[numbersKey]);

    foreach (char character in wordsToNumbers)
    {
        if (char.IsDigit(character))
            cleanedLine += character;
    }

    cleanedLine = cleanedLine.Length > 1 ? $"{cleanedLine[0]}{cleanedLine[^1]}" : $"{cleanedLine[0]}";

    calibrationSum += int.Parse(cleanedLine);
    Console.WriteLine(cleanedLine);
}

Console.WriteLine($"Coordinates are {calibrationSum}");

static string Reverse(string s)
{
    char[] charArray = s.ToCharArray();
    Array.Reverse(charArray);
    return new string(charArray);
}