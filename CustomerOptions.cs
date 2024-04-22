using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using MySqlConnector;

namespace LibraryMAUIProject
{
    public static class CustomerOptions
    {
        public static void CheckBookInfo()
        {
            
            
            // change the password to your personal one otherwise it will not work
            var connectionString = "Server = localhost, UserID = root,Password = DarkWolf, Database = library";

            var books = RetrieveBooks(connectionString);

            Console.WriteLine("Book Information");
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}");
            }
            

            static List<Book> RetrieveBooks(string connectionString)
            {
                string query = "SELECT Title, Author, Genre FROM books";

                var books = new List<Book>();

                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new MySqlCommand(query, connection))
                    {
                        using(var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var title = reader.GetString(0);
                                var author = reader.GetString(1);
                                var genre = reader.GetString(2);
                                books.Add(new Book { Title = title, Author = author, Genre = genre });
                            }
                        }
                    }
                }
                return books;
            }

        }

        public class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public string Genre { get; set; }

        }

        public static void RentBooks()
        {
            // Change the password section to your actual password in order for it to wook correctly
            var connectionString = "Server = localhost, UserID = root, Password = DarkWolf, Database = library";

            Console.WriteLine("Please Enter Your Id #: ");
            int customerId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter number of books rented: ");
            int numberOfBooks = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Book titles that you wish to rent (please seperate each title with a comma): ");
            var bookTitleInput = Console.ReadLine();
            var bookTitlesArray = bookTitleInput.Split(',');

                AddRental(connectionString, customerId,numberOfBooks, bookTitlesArray);
            

            static void AddRental(string connectionString, int customerId, int numberOfBooks, string[] bookTitles)
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using(var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            
                            InsertRental(connection, transaction, customerId, numberOfBooks, string.Join(",",bookTitles));

                            transaction.Commit();

                            Console.WriteLine("Rental Added successfully");
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Console.WriteLine($"Error adding rental: {ex.Message}");
                        }
                    }
                }
            }

            static void InsertRental(MySqlConnection connection, MySqlTransaction transaction, int customerId, int numberOfBooks, string bookTitles)
            {
                string query = "INSERT INTO rentals (CustomerId, NumberOfBooks, BookTitles, DateRented) VALUES (@customerId, @numberOfBooks, @bookTitles @dateRented)";

                using (var command = new MySqlCommand(query, connection, transaction))
                {
                    command.Parameters.AddWithValue("@customerId", customerId);
                    command.Parameters.AddWithValue("@numberOfBooks", numberOfBooks);
                    command.Parameters.AddWithValue("@bookTitles", bookTitles);
                    command.Parameters.AddWithValue("@dateRented", DateTime.Now);
                    command.ExecuteNonQuery();

                }
               
                
            }
        }
        
    }
}
