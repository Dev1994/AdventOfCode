string[] lines = File.ReadAllLines("./input.txt");
int calibrationSum = 0;

Dictionary<string, string> numbers = new()
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

        if (char.IsDigit(wordsToNumbers[i]) ||
            firstValue.Contains(numbers.ElementAt(0).Key) ||
            firstValue.Contains(numbers.ElementAt(1).Key) ||
            firstValue.Contains(numbers.ElementAt(2).Key) ||
            firstValue.Contains(numbers.ElementAt(3).Key) ||
            firstValue.Contains(numbers.ElementAt(4).Key) ||
            firstValue.Contains(numbers.ElementAt(5).Key) ||
            firstValue.Contains(numbers.ElementAt(6).Key) ||
            firstValue.Contains(numbers.ElementAt(7).Key) ||
            firstValue.Contains(numbers.ElementAt(8).Key))
        {
            firstNumber = firstValue;
            break;
        }

    }

    firstValue = string.Empty;
    for (int i = wordsToNumbers.Length - 1; i >= 0; i--)
    {
        firstValue += wordsToNumbers[i];
        if (char.IsDigit(wordsToNumbers[i]) ||
            firstValue.Contains(Reverse(numbers.ElementAt(0).Key)) ||
            firstValue.Contains(Reverse(numbers.ElementAt(1).Key)) ||
            firstValue.Contains(Reverse(numbers.ElementAt(2).Key)) ||
            firstValue.Contains(Reverse(numbers.ElementAt(3).Key)) ||
            firstValue.Contains(Reverse(numbers.ElementAt(4).Key)) ||
            firstValue.Contains(Reverse(numbers.ElementAt(5).Key)) ||
            firstValue.Contains(Reverse(numbers.ElementAt(6).Key)) ||
            firstValue.Contains(Reverse(numbers.ElementAt(7).Key)) ||
            firstValue.Contains(Reverse(numbers.ElementAt(8).Key)))
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