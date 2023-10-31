using System; 
using System.IO;
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace genstring;

class Program
{
    static void Main()
    {
        bool test = true;
        while (test)
        {
            Console.Clear();
            int length;
            Console.WriteLine("Enter the String length "); // Specify the desired length of the string
            
            if (int.TryParse(Console.ReadLine(), out length)) // Check to make sure an integer value is entered
            {
                if (length>=6 && length<=500)
                {
                    string randomString = GenerateRandomString(length);
                    Console.Clear();
                    Console.Write("Generated String is    ");
                    Console.WriteLine($"{randomString} \n");
                    Console.Write("Generate more String [Y/N]? ");
                    string? strMore = Console.ReadLine();
                    if (strMore.ToUpper() == "Y")
                        test = true;
                    else if (strMore.ToUpper() == "N")
                        test = false;
                    else
                    {
                        Console.Write("Y/N expected, press any key ");
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
            else
            {
                Console.WriteLine("Integer value exepected! Press any key to Continue \n");
                Thread.Sleep(100);
                Console.ReadKey();
            }

        }
    }

    static string GenerateRandomString(int length)
    {
        // Character pool 
        // abcdefghijklmnopqrstuvwxyz
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789#@$%^*&)(!$}{[]"; 

        Random random = new Random();
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < length; i++)
        {
            int index = random.Next(chars.Length);
            sb.Append(chars[index]);
        }

        return sb.ToString();
    }
}
