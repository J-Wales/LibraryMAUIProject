using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMAUIProject
{
    public class User
    {
        public int UserID { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public char Type { get; set; }

        public User(int UserID, string Password, string Name, string PhoneNumber)
        {
            this.UserID = UserID;
            this.Password = Password;
            this.Name = Name;
            this.PhoneNumber = PhoneNumber;

            SetType();
        }

        public void SetType()
        {
            if (UserID > 4999)
            {
                Type = 'L';
            }
            else
            {
                Type = 'C';
            }
        }
    }
}
