using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMAUIProject
{
    class RentalCVS
    {
        static void Main(string[] args)
        {
            string filePath = "Rental_Data.csv";

            WriteToCsv(filePath);

            ReadFromCsv(filePath);
        }

        static void WriteToCsv(string filePath)
        {
            List<string[]> data = new List<string[]>
            {
               new string[] {"Rental ID", "CustomerID", "Number of books", "Book titles", "Date Rented"},
               new string[] {"1", "1001", "3", "Harry Potter and the Philosopher's Stone, Harry Potter and the Chamber of Secrets, Harry Potter and the Prisoner of Azkaban", "2024-04-01"},
               new string[] {"2", "1004", "2", "The Great Gatsby, To Kill a Mockingbird", "2024-04-05"},
               new string[] {"3", "1002", "1", "Pride and Prejudice", "2024-04-10"},
               new string[] {"4", "1005", "4", "1984, Animal Farm, Brave New World, Fahrenheit451", "2024-04-15"},
               new string[] {"5", "1003", "2", "The Catcher in the Rye, Lord of the Flies", "2024-04-20"},
               new string[] {"6", "1008", "1", "The Hobbit", "2024-04-25"},
               new string[] {"7", "1006", "3", "The Hunger Games, Catching Fire, Mockingjay", "2024-05-01"},
               new string[] {"8", "1009", "2", "The Lord of the Rings: The Fellowship of the Ring, The Lord of the Rings: The Two Towers", "2024-05-05"},
               new string[] {"9", "1007", "1", "Gone with the Wind", "2024-05-10"},
               new string[] {"10", "1002", "2", "'The Chronicles of Narnia: The Lion, The Witch and the Wardrobe, The Chronicles of Narnia:Prince Caspian ", "2024-05-15"}
            };

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (string[] line in data)
                {
                    writer.WriteLine(string.Join(",", line));
                }
            }
        }

        static void ReadFromCsv(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');
                    Console.WriteLine($"Rental ID: {fields[0]}, Customer ID: {fields[1]}, Number of Books: {fields[2]}, Book Title's: {fields[3]}, Date Rented: {fields[4]}");
                }
            }
        }
    }
}

