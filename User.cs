using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMAUIProject
{
    public class User
    {
        // Properties of the User class
        public int UserID { get; set; } // ID of the user
        public string Password { get; set; } // Password of the user
        public string Name { get; set; } // Name of the user

        public string PhoneNumber { get; set; } // Phone number of the user

        public char Type { get; set; } // Type of user: 'L' for librarian, 'C' for customer

        // Constructor to initialize User object
        public User(int UserID, string Password, string Name, string PhoneNumber)
        {
            this.UserID = UserID;
            this.Password = Password;
            this.Name = Name;
            this.PhoneNumber = PhoneNumber;

            SetType(); // Determine the type of user based on UserID
        }

        // Method to set the Type property based on UserID
        public void SetType()
        {
            if (UserID > 4999) // Librarian IDs start from 5000
            {
                Type = 'L'; // Set Type to 'L' for librarian
            }
            else
            {
                Type = 'C'; // Set Type to 'C' for customer
            }
        }
    }
}
