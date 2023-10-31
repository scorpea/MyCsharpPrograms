using System.IO;
using System.Text;
using System.Threading;

namespace rwStream;

class Program
{
    static void Main(string[] args)
    {
        string line;
        try 
        {
            string inFilePath = @"D:\Bootcamp2023\infile.txt";
            string outFilePath = @"D:\Bootcamp2023\outfile.txt";
            StreamReader sr = new StreamReader(inFilePath);
            bool fileExists = File.Exists(outFilePath);
            if (!fileExists)
            {
               using (StreamWriter writer = File.CreateText(outFilePath));
            }
            StreamWriter sw = new StreamWriter(outFilePath, false, Encoding.ASCII);
            line = sr.ReadLine();
            Console.WriteLine($"Please wait, writing to file {outFilePath} \n");
            while (line != null)
            {
                sw.WriteLine(line);
                line = sr.ReadLine();
            }
            sr.Close();
            sw.Close();
            Thread.Sleep(20);
            Console.WriteLine("\nFile has been written successfully.");
            Console.WriteLine($"\nPress any key to exit! ");
            Console.ReadKey();
        }
        catch (IOException ex)
        {
            Console.WriteLine($"An error has occurred: {ex.Message}");
        }
    }
}
