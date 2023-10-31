// Program to show case all what we have learnt for the first 4 weeks in Bootcamp
using System;
using System.IO;
using System.Text;
using System.Threading;

namespace assignment3;

class Program
{
    static void Main()
    {
        Console.WriteLine("Student Grade Calculator");

        // Input the number of students
        int numberOfStudents;
        while (true)
        {
            Console.Write("Enter the number of students: ");
            if (int.TryParse(Console.ReadLine(), out numberOfStudents) && numberOfStudents > 0)
                break;
            else
                Console.WriteLine("Invalid input. Please enter a positive integer.");
        }

        Student[] students = new Student[numberOfStudents];

        // Input student data
        for (int i = 0; i < numberOfStudents; i++)
        {
            Console.WriteLine($"\nStudent {i + 1}:");
            string? studentName;
            do
            {
                Console.Write("Enter student's name: ");
                studentName = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(studentName));

            int examScore;
            while (true)
            {
                Console.Write("Enter exam score (0-100): ");
                if (int.TryParse(Console.ReadLine(), out examScore) && examScore >= 0 && examScore <= 100)
                    break;
                else
                    Console.WriteLine("Invalid input. Please enter a valid exam score (0-100).");
            }

            students[i] = new Student(studentName, examScore);
        }

        // Write results to a text file with exception handling
        try
        {
            WriteResultsToFile(students);
            Console.WriteLine($"\nPress any key to exit! ");
            Console.ReadKey();

        }
        catch (IOException ex)
        {
            Console.WriteLine($"An error occurred while writing to the file: {ex.Message}");
        }
    }

    static void WriteResultsToFile(Student[] students)
    {
        string outFilePath = @"D:\Bootcamp2023\studfile.txt";

        //check if the file exist
        bool fileExists = File.Exists(outFilePath);
        if (!fileExists)
        {
            using (StreamWriter writer = File.CreateText(outFilePath));
        }
        using (StreamWriter writer = new StreamWriter(outFilePath, false, Encoding.ASCII))
        {
            writer.WriteLine("Grades:\n");
            writer.WriteLine("|     Student Name     | Exam Score | Grade |");
            writer.WriteLine("|----------------------|------------|-------|");
            foreach (Student student in students)
            {
                writer.WriteLine($"| {student.Name, -20} | {student.ExamScore, -10} | {student.Grade, -5} |");
            }
            Thread.Sleep(500);
            Console.WriteLine($"\nResults have been written successfully to file: {outFilePath}");
            writer.Close();
        }
    }
}