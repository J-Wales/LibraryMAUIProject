using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using Org.Apache.Http.Authentication;
using static Android.Icu.Text.CaseMap;

namespace LibraryMAUIProject
{
    public class Rental
    {
        public int RentalID { get; set; }
        public int UserID { get; set; }

        public Rental(int RentalID, int UserID)
        {
            this.RentalID = RentalID;
            this.UserID = UserID;
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

            string sql = $"INSERT INTO rentals (rentalID, customerID) VALUES ({RentalID},{UserID})";

            MySqlCommand command = new MySqlCommand(sql, connection);

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
