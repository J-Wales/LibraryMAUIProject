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
        public int rentalID { get; set; }
        public int bookID { get; set; }

        public RentalBook(int rentalID, int bookID)
        {
            this.rentalID = rentalID;
            this.bookID = bookID;
        }

        public void toTable()
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

            string sql = $"INSERT INTO rentalbooks (rentalID, bookID) VALUES ({rentalID},{bookID})";

            MySqlCommand command = new MySqlCommand(sql, connection);

            command.ExecuteNonQuery();

            connection.Close();
        }

        public void Remove()
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

            string sql = $"DELETE FROM rentalbooks WHERE rentalID = {rentalID} AND bookID = {bookID}";

            MySqlCommand command = new MySqlCommand(sql, connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                reader.Read();
            }

            connection.Close();

        }
    }
}
