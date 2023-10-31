using System; 
using System.IO;
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace mixstring;

class Program
{
    static void Main()
    {
        bool test = true;
        const string acceptedChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789#@$%^*&)(!$}{[]";
        while (test)
        {
            Console.Clear();
            int totalAlphabets = 0, totalNumbers = 0, totalSymbols = 0; // variable declaration and initialization
            Console.WriteLine("Enter a String "); // Specify the desired length of the string
            string? randomString = Console.ReadLine();
            int length = randomString.Length;
            if (length>=6 && length<=500) // Check to make sure the length of the string is within the range
            {
                bool validInput = checkString(randomString);
                if (validInput) // Check if the input string is within "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789#@$%^*&)(!$}{[]"
                {
                    Console.Clear();
                    Console.Write("Inputed String is    ");
                    Console.WriteLine($"{randomString} \n");
                    countRearrangeAlphaNumbSymbol (randomString, totalAlphabets, totalNumbers, totalSymbols);
                    test = false;
                }
                else
                {
                    Console.WriteLine($"Error:- inputed string {randomString} does not fall withing the acceptable characters {acceptedChar} \n");    
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
        foreach (char c in randomString)
        {
            if (Char.IsUpper(c) || Char.IsDigit(c) || isSpecialChar(c))
            {
                return true;
            }
        }
        return false;
    }

    static bool isSpecialChar(char c)
    {
        char[] specialCharacters = { '#', '@', '$', '%', '^', '*', '&', '(', ')', '!', '$', '}', '{', '[', ']' };
        return Array.Exists(specialCharacters, specialChar => specialChar == c);
    }

    static void countRearrangeAlphaNumbSymbol (string randomString, int totalAlphabets, int totalNumbers, int totalSymbols)
    {
        char[] strArray = randomString.ToCharArray(); //converting the string to an Array

        foreach (var item in strArray)
        {
            if (char.IsLetter(item))
                totalAlphabets++;
            if (char.IsDigit(item))
                totalNumbers++;
            if (!char.IsLetterOrDigit(item))
                totalSymbols++;
        }
            
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

        char[] alphaArray = new char[totalAlphabets];
        char [] numbArray = new char[totalNumbers];
        foreach (var item in strArray)
        {
            if (char.IsLetter(item))
                alphaArray = alphaArray.Append(item).ToArray();
            if (char.IsDigit(item))
                numbArray = numbArray.Append(item).ToArray();
        }
            
        Array.Sort(alphaArray);
        Array.Sort(numbArray);

        Console.Write($"\nAlphabets arranged in ascending order ");
        foreach (var item in alphaArray)
        {
            Console.Write(item);
        }

        Console.Write($"\nNumbers arranged in ascending order ");
        if (totalNumbers==0)
        {
            double totalSum = (totalAlphabets + totalSymbols) / 2;
            Console.Write($"\nThere are no Numbers in the string but the sum of the number of Alphabets and Symbols divided by 2 is : {totalSum:F2}");
        }
        else
        {
            int sumNumbers = 0;
            foreach (var itemNum in numbArray)
            {
                Console.Write(itemNum);
                sumNumbers = sumNumbers + (int)itemNum;
            }
            Console.WriteLine($"\n Sum Array {sumNumbers}");
            double totalSum = (sumNumbers + totalAlphabets + totalSymbols) / 2;
            Console.Write($"\nThe Sum of the Numbers, number of Alphabets and Symbols divided by 2 is : {totalSum:F2}");
        }
    }
}
