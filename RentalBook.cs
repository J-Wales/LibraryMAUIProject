using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace LibraryMAUIProject
{
    public class RentalBook
    {
        // Properties of the RentalBook class
        public int rentalID { get; set; } // ID of the rental
        public int bookID { get; set; } // ID of the book

        // Constructor to initialize RentalBook object
        public RentalBook(int rentalID, int bookID)
        {
            this.rentalID = rentalID;
            this.bookID = bookID;
        }

        // Method to add rental book entry to the database table
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

            // SQL query to insert rental book entry into the database table
            string sql = $"INSERT INTO rentalbooks (rentalID, bookID) VALUES ({rentalID},{bookID})";

            // Create a MySqlCommand object to execute the SQL query
            MySqlCommand command = new MySqlCommand(sql, connection);

            command.ExecuteNonQuery(); // Execute the SQL query

            connection.Close(); // Close the database connection
        }

        // Method to remove rental book entry from the database table
        public void Remove()
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

            // SQL query to delete rental book entry from the database table
            string sql = $"DELETE FROM rentalbooks WHERE rentalID = {rentalID} AND bookID = {bookID}";

            // Create a MySqlCommand object to execute the SQL query
            MySqlCommand command = new MySqlCommand(sql, connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                reader.Read();
            }

            connection.Close(); // Close the database connection

        }
    }
}
