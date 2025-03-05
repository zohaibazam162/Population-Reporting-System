using System;

class Program
{
    static void Main(string[] args)
    {
        // Create an instance of DatabaseHelper to interact with the database
        DatabaseHelper dbHelper = new DatabaseHelper();

        // Infinite loop to keep the menu running until the user chooses to exit
        while (true)
        {
            Console.Clear(); // Clears the console screen for a fresh menu display
            Console.WriteLine(" Population Reporting System");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("1. View Countries by Population");
            Console.WriteLine("2. View Top Cities in a Continent");
            Console.WriteLine("3. View Language Speaker Statistics");
            Console.WriteLine("4. Exit");
            Console.Write("\nEnter your choice: ");

            // Read user input from the console
            string choice = Console.ReadLine();

            // Switch case to handle menu selection
            switch (choice)
            {
                case "1":
                    // Calls method to fetch and display countries sorted by population
                    dbHelper.GetCountriesByPopulation();
                    break;
                case "2":
                    // User input for filtering cities by continent and limiting results
                    Console.Write("\nEnter Continent Name: ");
                    string continent = Console.ReadLine();

                    Console.Write("Enter Number of Top Cities to Display: ");
                    int topN;

                    // Ensures valid numeric input for the number of cities
                    while (!int.TryParse(Console.ReadLine(), out topN) || topN <= 0)
                    {
                        Console.Write("Invalid input! Enter a valid number: ");
                    }

                    // Calls method to fetch and display top N cities in the given continent
                    dbHelper.GetTopCitiesInContinent(continent, topN);
                    break;
                case "3":
                    // Calls method to display language speaker statistics
                    dbHelper.GetLanguageSpeakers();
                    break;
                case "4":
                    // Exits the program gracefully
                    Console.WriteLine("\nExiting... Goodbye!");
                    return;
                default:
                    // Handles invalid menu options
                    Console.WriteLine("\n Invalid choice! Please try again.");
                    break;
            }

            // Waits for user input before showing the menu again
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
