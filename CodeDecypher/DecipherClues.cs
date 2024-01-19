namespace CodeDecypher;
internal class DecipherClues
{
    public static void Decipher(List<Clue> clues)
    {
        var possibleNumbers = Enumerable.Range(0, 1000).Select(i => i.ToString("D3")).ToList();

        foreach (var clue in clues)
        {
            possibleNumbers = possibleNumbers.Where(number => IsValid(number, clues)).ToList();
        }

        if (possibleNumbers.Count == 1)
        {
            Console.WriteLine($"Solution found. The value is: {possibleNumbers[0]:D3}");
        }
        else if (possibleNumbers.Count > 1)
        {
            Console.WriteLine($"Multiple solutions found: ");
            foreach (var solution in possibleNumbers)
            {
                Console.WriteLine($"    The value is: {solution}");
            }
        }
        else
        {
            Console.WriteLine("No Solution found.");
        }

    }

    private static bool IsValid(string number, List<Clue> clues)
    {
        foreach (var clue in clues)
        {
            int numberOfCorrectDigits = 0;
            int numberOfDigitsInWrongPosition = 0;

            for (int i = 0; i < 3; i++)
            {
                if (number[i] == clue.Value[i])
                {
                    numberOfCorrectDigits++;
                }
                else if (number.Contains(clue.Value[i]))
                {
                    numberOfDigitsInWrongPosition++;
                }
            }

            if (numberOfCorrectDigits != clue.NumberOfCorrectDigits || numberOfDigitsInWrongPosition != clue.NumberOfDigitsInWrongPosition)
            {
                return false;
            }
        }

        return true;
    }
}
