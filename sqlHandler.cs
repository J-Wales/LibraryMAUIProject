using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace LibraryMAUIProject
{
    public class sqlHandler
    {
        public User[]? users;
        public Book[]? books;
        public Rental[]? rentals;
        public RentalBook[]? rentalbooks;

        public sqlHandler()
        {
            GetUsers();
            GetBooks();
            GetRentals();
            GetRentalBooks();
        }

        public void GetUsers()
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

            string sql = "SELECT * FROM users";

            MySqlCommand command = new MySqlCommand(sql, connection);

            List<User> list = new List<User>();

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string pass = reader.GetString(1);
                    string name = reader.GetString(2);
                    string phone = reader.GetString(3);

                    list.Add(new User(id, pass, name, phone));
                }
                users = list.ToArray();
            }
            connection.Close();
        }
        public void GetBooks()
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

            string sql = "SELECT * FROM books";

            MySqlCommand command = new MySqlCommand(sql, connection);

            List<Book> list = new List<Book>();

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string title = reader.GetString(1);
                    string author = reader.GetString(2);
                    int available = reader.GetInt32(3);

                    list.Add(new Book(id, title, author, available));
                }
                books = list.ToArray();
            }
            connection.Close();
        }

        public void GetRentals()
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

            string sql = "SELECT * FROM rentals";

            MySqlCommand command = new MySqlCommand(sql, connection);

            List<Rental> list = new List<Rental>();

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int rentalid = reader.GetInt32(0);
                    int userid = reader.GetInt32(1);


                    list.Add(new Rental(rentalid, userid));
                }
                rentals = list.ToArray();
            }
            connection.Close();
        }

        public void GetRentalBooks()
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

            string sql = "SELECT * FROM rentalbooks";

            MySqlCommand command = new MySqlCommand(sql, connection);

            List<RentalBook> list = new List<RentalBook>();

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int rentalid = reader.GetInt32(0);
                    int bookid = reader.GetInt32(1);

                    list.Add(new RentalBook(rentalid, bookid));
                }
                rentalbooks = list.ToArray();
            }
            connection.Close();
        }
    }
}
