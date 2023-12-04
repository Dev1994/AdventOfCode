namespace Day_3_Gear_Ratios;

public class EngineParts
{
    public int CalculateGearsSum(string[] lines)
    {
        List<int> engineParts = new ();
        List<Dictionary<string, (List<int> numberIndexes, bool isEnginePart)>> lineDictionariesList = new ();
        List<int> secondLastSpecialIndexes = new ();
        List<int> previousSpecialIndexes = new ();

        foreach (string line in lines)
        {
            char[] lineChars = line.ToCharArray();

            List<int> numberIndexes = new ();
            List<int> specialIndexes = new ();

            // Get all the number indexes and special character indexes.
            for (int i = 0; i < lineChars.Length; i++)
            {
                char currentChar = lineChars[i];
                if (char.IsDigit(currentChar) && currentChar != '.')
                    numberIndexes.Add(i);
                if (!char.IsDigit(currentChar) && currentChar != '.')
                    specialIndexes.Add(i);
            }

            Dictionary<string, (List<int> numberIndexes, bool isEnginePart)> fullNumbersDictionary = new ();
            string fullNumber = string.Empty;
            List<int> fullNumberIndexes = new ();
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

            // Add full numbers dictionary based on current line special characters
            fullNumbersDictionary.Add(fullNumber, (fullNumberIndexes, HasSpecialPrefixOrPostfix(specialIndexes, fullNumberIndexes)));

            Dictionary<string, (List<int> numberIndexes, bool isEnginePart)> updatedFullNumberDictionary = GetUpdatedDictionary(previousSpecialIndexes, fullNumbersDictionary);
            lineDictionariesList.Add(updatedFullNumberDictionary);

            // Check if previous line contains engine parts based on current line special characters
            if (lineDictionariesList.Count > 1)
            {
                Dictionary<string, (List<int> numberIndexes, bool isEnginePart)> previousLine = lineDictionariesList.ElementAt(lineDictionariesList.Count - 2);
                Dictionary<string, (List<int> numberIndexes, bool isEnginePart)> updatedPreviousLineDictionary = GetUpdatedDictionary(specialIndexes, previousLine);

                // Update previous line dictionary
                lineDictionariesList[^2] = updatedPreviousLineDictionary;
            }

            if (lines.Length > 1 && lines[^2] == line)
                secondLastSpecialIndexes = new List<int>(specialIndexes);

            previousSpecialIndexes = new List<int>(specialIndexes);
        }

        if (lines.Length > 1)
        {
            Dictionary<string, (List<int> numberIndexes, bool isEnginePart)> lastLine = lineDictionariesList.ElementAt(lineDictionariesList.Count - 1);
            Dictionary<string, (List<int> numberIndexes, bool isEnginePart)> updatedLastLineDictionary = GetUpdatedDictionary(secondLastSpecialIndexes, lastLine);

            // Update previous line dictionary
            lineDictionariesList[^1] = updatedLastLineDictionary;
        }

        foreach (Dictionary<string, (List<int> numberIndexes, bool isEnginePart)> valueTuples in lineDictionariesList)
            engineParts.AddRange(valueTuples.Where(v => v.Value.isEnginePart).Select(v => int.Parse(RemovePostFixFromString(v.Key))).ToList());

        return engineParts.Sum();
    }

    private static string RemovePostFixFromString(string fullNumber)
    {
        if (fullNumber.Contains("_"))
        {
            int index = fullNumber.IndexOf("_", StringComparison.Ordinal);
            int count = fullNumber.Length - index;
            return fullNumber.Remove(index, count);
        }

        return fullNumber;
    }

    private static Dictionary<string, (List<int> numberIndexes, bool isEnginePart)> GetUpdatedDictionary(
        List<int> specialIndexes, Dictionary<string, (List<int> numberIndexes, bool isEnginePart)> previousLine)
    {
        Dictionary<string, (List<int> numberIndexes, bool isEnginePart)> updatedFullNumberDictionary = new ();
        foreach (KeyValuePair<string, (List<int> numberIndexes, bool isEnginePart)> previousLineDictionary in previousLine)
        {
            List<int> currentIndexes = previousLineDictionary.Value.numberIndexes;
            if (previousLineDictionary.Value.isEnginePart)
            {
                updatedFullNumberDictionary.Add(previousLineDictionary.Key, (currentIndexes, true));
            }
            else
            {
                updatedFullNumberDictionary.Add(
                    previousLineDictionary.Key, (currentIndexes, HasSpecialCharacterInSameIndex(specialIndexes, currentIndexes) || HasSpecialPrefixOrPostfix(specialIndexes, currentIndexes)));
            }
        }

        return updatedFullNumberDictionary;
    }

    private static bool HasSpecialPrefixOrPostfix(List<int> specialIndexes, List<int> numberIndexes)
    {
        return specialIndexes.Any(s => numberIndexes.Any(n => s == n - 1) || numberIndexes.Any(n => s == n + 1));
    }

    private static bool HasSpecialCharacterInSameIndex(List<int> specialIndexes, List<int> numberIndexes)
    {
        return specialIndexes.Any(s => numberIndexes.Any(n => s == n));
    }
}