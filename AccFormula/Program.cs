namespace AccFormula;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What are You up to?");
        Console.WriteLine("1. Net Income Processing n2. Total Asset Processing");
        string? userRsp = Console.ReadLine();

        if (userRsp == "1")
        {
            ProcessNetIncome();
        }
        else
        {
            ProcessTotalAsset();
        }
     
    }

    private static void ProcessTotalAsset()
    {
        Console.WriteLine("Enter liability value ");
        string? Liabilities = Console.ReadLine();
        double liabilities = Convert.ToDouble(Liabilities);

        Console.WriteLine("Enter equity value ");
        string? Equity = Console.ReadLine();
        double equity = Convert.ToDouble(Equity);

        double result = TotalAsset(liabilities, equity);
        Console.WriteLine($" Total Assest is {result} ");        
    }

    private static void ProcessNetIncome()
    {
        Console.WriteLine("Enter the Revenue ");
        string? Revenue = Console.ReadLine();
        double revenue = Convert.ToDouble(Revenue);

        Console.WriteLine("Enter Expenses ");
        string? Expenses = Console.ReadLine();
        double expenses = Convert.ToDouble(Expenses);

        double answer = NetIncome(revenue, expenses);
        Console.WriteLine($" The Net Income is {answer} ");        
    }

    private static double TotalAsset(double liabilities, double equity)
    {
        double result = liabilities + equity;
        return result;
    }

    private static double NetIncome(double revenue, double expenses)
    {
        double answer = revenue - expenses;
        return answer;
    }
}
