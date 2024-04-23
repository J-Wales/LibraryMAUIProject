using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
