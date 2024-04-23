using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
