using System; using System.IO;
using System.Linq; using System.Text;
using System.Threading; using System.Threading.Tasks;
using System.Collections.Generic;

namespace assignment2;

class Program
{
    const string validCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789#@$%^*&)(!$}{[]";
    static void Main(string[] args)
    {
        bool test = true;
        while (test)
        {
            int totalAlphabets = 0, totalNumbers = 0, totalSymbols = 0; 
            Console.Clear();
            Console.WriteLine("Enter a String "); // Specify the desired length of the string
            string? randomString = (Console.ReadLine().ToUpper());
            int length = randomString.Length;
            if (length>=6 && length<=500) // Check to make sure the length of the string is within the range
            {
                bool isValid = checkString(randomString);
                if (isValid) // A method to check if the input string is within "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789#@$%^*&)(!$}{[]"
                {
                    Console.Clear();
                    Console.Write("Inputed String is    ");
                    Console.WriteLine($"{randomString} \n");
                    countAlphaNumbSymbol (randomString, totalAlphabets, totalNumbers, totalSymbols);
                    //rearrangeSumAlphaNumb (randomString, totalAlphabets, totalNumbers, totalSymbols);
                    test = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Error:- inputed string {randomString} does not fall withing the acceptable characters {validCharacters} ..Press any Key to Continue\n");    
                    Thread.Sleep(100);
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Error:- Minimum length should be 6 and maximun should be 500! Press any Key to continue \n");
                Thread.Sleep(100);
                Console.ReadKey();
            }

        }

    }
    
    static bool checkString (string randomString)
    {
        foreach (char character in randomString)
        {
            if (!validCharacters.Contains(character.ToString()))
            {
                return false;
            }
        }
        return true;
    }

    static void countAlphaNumbSymbol (string randomString, int totalAlphabets, int totalNumbers, int totalSymbols) // Count Symbols, Alphabets and Numbers in the string
    {
        totalAlphabets = randomString.Count(char.IsLetter);
        totalNumbers = randomString.Count(char.IsDigit);
        totalSymbols = randomString.Count((c) => !char.IsLetterOrDigit(c)); 
        Console.WriteLine($"Total Alphabets in the string : {totalAlphabets}");
            
        if (totalNumbers==0)
        {
            Console.WriteLine("Total Numbers in the String : None");
        }
        else
        {
            Console.WriteLine($"Total Numbers in the String : {totalNumbers}");
        }
        Console.WriteLine($"Total Symbols in the String : {totalSymbols}");
   /* }

    static void rearrangeSumAlphaNumb (string randomString, int totalAlphabets, int totalNumbers, int totalSymbols) // Arrange Alphabets and Numbers in the string in ascending order and calculate the sum
    {*/
        int[]? ascNumbers; 
        string ascAlphabets = string.Join("", randomString.Where(char.IsLetter).OrderBy(c => c));
        Console.Write($"\nAlphabets arranged in ascending order  {ascAlphabets}");
        Console.Write($"\nNumbers arranged in ascending order   ");
        if (totalNumbers == 0)
        {
            Console.Write($" None");
            double totalSum = (totalAlphabets + totalSymbols) / 2;
            Console.Write($"\nThere are no Numbers in the string but the sum of the number of Alphabets and Symbols divided by 2 is : {totalSum:F2}");
        }
        else
        {
            ascNumbers = randomString.Where(char.IsDigit).Select(c => int.Parse(c.ToString())).OrderBy(x => x).ToArray();
            /*for (int i = 0; i < ascNumbers.Length; i++)
            {
                ascNumbers[i] = i + 1;
            }
            Console.Write($"\n {string.Join("", ascNumbers)}");*/
            int sumNumbers = ascNumbers.Sum();
            Array.Sort(ascNumbers);
            foreach (var itemNum in ascNumbers)
            {
                Console.Write(itemNum);
            }
            double totalSum = (sumNumbers + totalAlphabets + totalSymbols) / 2;
            Console.Write($"\nThe Sum of the Numbers is {sumNumbers}, added to number of Alphabets and Symbols divided by 2 is : {totalSum:F2}");

        }
    }
}
