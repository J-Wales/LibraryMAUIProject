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
        public int bookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Available { get; set; }

        public Book(int bookID, string Title, string Author, int Available)
        {
            this.bookID = bookID;
            this.Title = Title;
            this.Author = Author;
            this.Available = Available;
        }


        public string toString()
        {
            return $"{bookID},{Title},{Author},{Available}";
        }

        public void Update()
        {
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

            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);

            connection.Open();

            string sql = $"UPDATE books SET available = {Available} WHERE bookID = {bookID}";

            MySqlCommand command = new MySqlCommand(sql, connection);

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
