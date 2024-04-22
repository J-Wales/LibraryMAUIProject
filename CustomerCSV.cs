using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using MySqlConnector;

namespace LibraryMAUIProject
{
    class CustomerCSV
    {
        static void Main(string[] args) 
        {
            string filePath = "Customer_Data.csv";

            var connectionString = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                UserID = "root",
                Password = "DarkWolf", // Change the password to whatever you have it set to
                Database = "library"

            };

            WriteToCsv(filePath);

            AddDataToDatabase(filePath, connectionString.ConnectionString);
        }

        static void WriteToCsv(string filePath)
        {
            List<string[]> data = new List<string[]>
            {
               new string[] {"CustomerID", "Paassword","Name", "Phonenumber"},
               new string[] {"1000", "Password","Alice Johnson", "123-456-7890"},
               new string[] {"1001", "WordPass","Bob Smith", "456-789-0123"},
               new string[] {"1002", "PWord","Emily Davis", "789-012-3456"},
               new string[] {"1003", "WordP","Micheal Wilson", "012-345-6789"},
               new string[] {"1004", "Pard","Olivia Martinez", "345-678-9012"},
               new string[] {"1005", "Woss","James Taylor", "678-901-2345"},
               new string[] {"1006", "WordP","Sophia Anderson", "901-234-5678"},
               new string[] {"1007", "PassW","William Thomas", "234-567-8901"},
               new string[] {"1008", "Word","Mia Garcia", "567-890-1234"},
               new string[] {"1009", "Pass","Ethan Hernandez", "890-123-4567"}
            };

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (string[] line in data)
                {
                    writer.WriteLine(string.Join(",", line));
                }
            }
        }

        static void AddDataToDatabase(string filePath, string connectionString)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                reader.ReadLine();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');

                    AddCustomerToDatabase(fields[0], fields[1], fields[2], fields[3], connectionString);
                }
            }
        }

        static void AddCustomerToDatabase(string customerId, string password, string name, string phoneNumber, string connectionString)
        {


            Console.WriteLine($"Adding customer to database: CustoemrID: {customerId}, Name: {name}, PhoneNumber: {phoneNumber}");

            
            string query = "INSERT INTO customers (customerID, custPassword, custName, PhoneNumber)" +
                   "VALUES (@customerID, @custPassword, @custName, @PhoneNumber)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@customerID", customerId);
                        command.Parameters.AddWithValue("@custPassword", password);
                        command.Parameters.AddWithValue("@custName", name);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                        int rowsAffected = command.ExecuteNonQuery();

                        Console.WriteLine($"Rows inserted: {rowsAffected}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting customer data: {ex.Message}");
                }
            }
        }
        
    }
}
