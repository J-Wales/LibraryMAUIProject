using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMAUIProject
{
    class LibraryLoginSystem
    {
        private readonly HashSet<int> employeeIds = new HashSet<int>(Enumerable.Range(0,1000));
        private readonly HashSet<int> customerIds = new HashSet<int>(Enumerable.Range(1000, 4000));

        public void Login (int userId)
        {
            if (employeeIds.Contains(userId))
            {
                EmployeeMenu();
            }
            else if (customerIds.Contains(userId))
            {
                CustomerMenu();
            }
            else
            {
                Console.WriteLine("Invalid user ID");
            }
        }

        private void EmployeeMenu()
        {

        }

        private void CustomerMenu()
        {

        }

    }
}
