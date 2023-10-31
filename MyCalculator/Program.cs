
namespace MyCalculator;

class Calculator
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Arnold's Simple Calculator");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice (1/2/3/4/5): ");

            // Read user's choice
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a valid option.\n");
                continue;
            }

            if (choice == 5)
            {
                Console.WriteLine("Exiting the calculator. Thank You\n");
                break;
            }

            double result = 0;
            string sign ="";

            // Input numbers
            Console.Write("Enter the first number: ");
            double num1;
            if (!double.TryParse(Console.ReadLine(), out num1))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.\n");
                continue;
            }

            Console.Write("Enter the second number: ");
            double num2;
            if (!double.TryParse(Console.ReadLine(), out num2))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.\n");
                continue;
            }

            // Perform calculation based on user's choice
            switch (choice)
            {
                case 1:
                    result = num1 + num2;
                    sign = "+";
                    break;
                case 2:
                    result = num1 - num2;
                    sign = "-";
                    break;
                case 3:
                    result = num1 * num2;
                    sign = "*";
                    break;
                case 4:
                    if (num2 == 0)
                    {
                        Console.WriteLine("Error: Division by zero.\n");
                        continue;
                    }
                    result = num1 / num2;
                    result = Math.Round(result, 2);
                    sign = "/";
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.\n");
                    continue;
            }

            // Display the result
            Console.WriteLine($"{num1} {sign} {num2} = {result}\n");
        }
    }
}