using System;

class Program
{
    static void Main(string[] args)
    {
        DatabaseHelper dbHelper = new DatabaseHelper();

        while (true)
        {
            Console.Clear();
            Console.WriteLine(" Population Reporting System");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("1. View Countries by Population");
            Console.WriteLine("2. View Top Cities in a Continent");
            Console.WriteLine("3. View Language Speaker Statistics");
            Console.WriteLine("4. Exit");
            Console.Write("\nEnter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    dbHelper.GetCountriesByPopulation();
                    break;
                case "2":
                    Console.Write("\nEnter Continent Name: ");
                    string continent = Console.ReadLine();
                    Console.Write("Enter Number of Top Cities to Display: ");
                    int topN;
                    while (!int.TryParse(Console.ReadLine(), out topN) || topN <= 0)
                    {
                        Console.Write("Invalid input! Enter a valid number: ");
                    }
                    dbHelper.GetTopCitiesInContinent(continent, topN);
                    break;
                case "3":
                    dbHelper.GetLanguageSpeakers();
                    break;
                case "4":
                    Console.WriteLine("\nExiting... Goodbye!");
                    return;
                default:
                    Console.WriteLine("\n Invalid choice! Please try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
