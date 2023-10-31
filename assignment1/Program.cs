// A Simple Calculator
namespace assignment1;

class Calculator
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Arnold Arithmetic Calculator");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Modulus");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice (1/2/3/4/5/6): ");

            // Read user's choice
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a valid option.\n");
                continue;
            }
            else if (Convert.ToInt16(choice) >= 7)
            {
                Console.WriteLine("Invalid choice. Please select a valid option.\n");
                continue;
            }

            if (choice == 6)
            {
                Console.WriteLine("Exiting the calculator. Thank You\n");
                break;
            }

            double result = 0;
            string sign ="";

            // Input numbers
            Console.Clear();
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
                case (int)Operators.Addition:
                    result = num1 + num2;
                    sign = "+";
                    break;
                case (int)Operators.Subtraction:
                    result = num1 - num2;
                    sign = "-";
                    break;
                case (int)Operators.Multiplication:
                    result = num1 * num2;
                    sign = "*";
                    break;
                case (int)Operators.Division:
                    if (num2 == 0)
                    {
                        Console.WriteLine("Error: Division by zero.\n");
                        continue;
                    }
                    result = num1 / num2;
                    result = Math.Round(result, 2);
                    sign = "/";
                    break;
                case (int)Operators.Modulus:
                    result = num1 % num2;
                    sign = "%";
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.\n");
                    continue;
            }

            // Display the result
            Console.WriteLine($"{num1} {sign} {num2} = {result}\n");
            Console.WriteLine("Press any key to Continue...");
            Console.ReadKey();
        }
    }
}