using System;
using MySql.Data.MySqlClient;

public class DatabaseHelper
{
    // Connection string to the MySQL database, specifying the server, database, user, and password.
    private string connectionString = "server=localhost;database=world;user=root;password=;";

    // Method to retrieve and display countries ordered by population.
    public void GetCountriesByPopulation()
    {
        // Create and open a connection to the MySQL database using the connection string.
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            try
            {
                conn.Open(); // Open the database connection.

                // Define the SQL query to retrieve country information ordered by population in descending order.
                string query = "SELECT Code, Name, Continent, Region, Population, Capital FROM country ORDER BY Population DESC;";

                // Create a command object to execute the SQL query.
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // Execute the query and retrieve the result set in a reader.
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Output the column headers for clarity.
                        Console.WriteLine("\nCountries Ordered by Population:");
                        Console.WriteLine("------------------------------------------------------");

                        // Loop through the result set and output the data for each row.
                        while (reader.Read())
                        {
                            // Print country information including code, name, continent, region, population, and capital.
                            Console.WriteLine($"Code: {reader["Code"]}, Name: {reader["Name"]}, Continent: {reader["Continent"]}, " +
                                              $"Region: {reader["Region"]}, Population: {reader["Population"]}, Capital: {reader["Capital"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // If an error occurs, print the exception message.
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    // Method to retrieve and display the top 'N' cities by population in a given continent.
    public void GetTopCitiesInContinent(string continent, int topN)
    {
        // Create and open a connection to the MySQL database.
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            try
            {
                conn.Open(); // Open the database connection.

                // Define the SQL query with placeholders for continent and the number of cities to return.
                string query = $"SELECT city.Name, city.CountryCode, city.Population FROM city " +
                               $"JOIN country ON city.CountryCode = country.Code " +
                               $"WHERE country.Continent = @Continent ORDER BY city.Population DESC LIMIT @TopN;";

                // Create a command object with the query and connection.
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // Add parameters to prevent SQL injection and set their values.
                    cmd.Parameters.AddWithValue("@Continent", continent);
                    cmd.Parameters.AddWithValue("@TopN", topN);

                    // Execute the query and retrieve the result set.
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Output the column headers for clarity.
                        Console.WriteLine($"\nTop {topN} Cities in {continent}:");
                        Console.WriteLine("------------------------------------------------------");

                        // Loop through the result set and output the data for each row.
                        while (reader.Read())
                        {
                            // Print city information including name, country code, and population.
                            Console.WriteLine($"Name: {reader["Name"]}, Country: {reader["CountryCode"]}, Population: {reader["Population"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // If an error occurs, print the exception message.
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    // Method to retrieve and display the number of speakers of major languages.
    public void GetLanguageSpeakers()
    {
        // Create and open a connection to the MySQL database.
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            try
            {
                conn.Open(); // Open the database connection.

                // Define the SQL query to calculate the total number of speakers for specific languages.
                string query = "SELECT Language, SUM((Population * Percentage) / 100) AS TotalSpeakers FROM countrylanguage " +
                               "JOIN country ON countrylanguage.CountryCode = country.Code " +
                               "WHERE Language IN ('Chinese', 'English', 'Hindi', 'Spanish', 'Arabic') " +
                               "GROUP BY Language ORDER BY TotalSpeakers DESC;";

                // Create a command object to execute the SQL query.
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // Execute the query and retrieve the result set.
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Output the column headers for clarity.
                        Console.WriteLine("\nLanguage Speaker Statistics:");
                        Console.WriteLine("---------------------------------");

                        // Loop through the result set and output the data for each row.
                        while (reader.Read())
                        {
                            // Print the language and the total number of speakers.
                            Console.WriteLine($"Language: {reader["Language"]}, Total Speakers: {reader["TotalSpeakers"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // If an error occurs, print the exception message.
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
