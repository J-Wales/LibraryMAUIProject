using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;


namespace LibraryMAUIProject
{

    public class Rental 
    {
        // Properties of the Rental class
        public int RentalID { get; set; } // ID of the rental
        public int UserID { get; set; } // ID of the user who rented the books

        // Constructor to initialize Rental object
        public Rental(int RentalID, int UserID)
        {
            this.RentalID = RentalID;
            this.UserID = UserID;
        }

        // Method to add rental entry to the database table
        public void toTable()
        {
            // Create a connection string builder to configure the database connection
            MySqlConnectionStringBuilder builder =
                   new MySqlConnectionStringBuilder
                   {
                       // Set the server address to "localhost"
                       Server = "localhost",
                       // Set the user ID to "root"
                       UserID = "root",
                       // Set the password to "OOP2@"
                       Password = "Iforgot100",
                       // Set the database name to "demo1"
                       Database = "librarydatabase",
                   };

            // Establish a connection to the database
            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);

            connection.Open();

            // SQL query to insert rental entry into the database table
            string sql = $"INSERT INTO rentals (rentalID, customerID) VALUES ({RentalID},{UserID})";

            // Create a MySqlCommand object to execute the SQL query
            MySqlCommand command = new MySqlCommand(sql, connection);

            command.ExecuteNonQuery(); // Execute the SQL query

            connection.Close(); // Close the database connection
        }
    }
}
