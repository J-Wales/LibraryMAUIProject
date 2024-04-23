using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace LibraryMAUIProject
{
    public class Book
    {
        // Properties of the Book class
        public int bookID { get; set; } // ID of the book
        public string Title { get; set; } // Title of the book
        public string Author { get; set; } // Author of the book
        public int Available { get; set; } // Availability status of the book

        // Constructor to initialize Book object
        public Book(int bookID, string Title, string Author, int Available)
        {
            this.bookID = bookID;
            this.Title = Title;
            this.Author = Author;
            this.Available = Available;
        }

        // Method to return a string representation of the Book object
        public string toString()
        {
            return $"{bookID},{Title},{Author},{Available}";
        }

        // Method to update the availability status of the book in the database
        public void Update()
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

            // SQL query to update the availability status of the book in the database
            string sql = $"UPDATE books SET available = {Available} WHERE bookID = {bookID}";

            // Create a MySqlCommand object to execute the SQL query
            MySqlCommand command = new MySqlCommand(sql, connection);

            command.ExecuteNonQuery(); // Execute the SQL query

            connection.Close(); // Close the database connection
        }
    }
}
