using System.IO;
using System.Threading;

namespace readwrite;

class Program
{
    static void Main(string[] args)
    {
        try 
        {
            string fileName = "D:\\Bootcamp2023\\outfile.txt";
            string inFilePath = @"D:\Bootcamp2023\infile.txt";
            string outFilePath = @fileName;
            string? text = File.ReadAllText(inFilePath);
            Console.WriteLine($"Please wait, writing to file {fileName} \n");
            Thread.Sleep(20);
            File.WriteAllText(outFilePath, text);
            Console.WriteLine("File has been written successfully.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"An error has occurred: {ex.Message}");
        }
    }
}
