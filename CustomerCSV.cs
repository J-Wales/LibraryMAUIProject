using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMAUIProject
{
    class CustomerCSV
    {
        static void Main(string[] args) 
        {
            string filePath = "Customer_Data.csv";

            WriteToCsv(filePath);

            ReadFromCsv(filePath);
        }

        static void WriteToCsv(string filePath)
        {
            List<string[]> data = new List<string[]>
            {
               new string[] {"CustomerID", "Name", "Phonenumber"},
               new string[] {"1000", "Alice Johnson", "123-456-7890"},
               new string[] {"1001", "Bob Smith", "456-789-0123"},
               new string[] {"1002", "Emily Davis", "789-012-3456"},
               new string[] {"1003", "Micheal Wilson", "012-345-6789"},
               new string[] {"1004", "Olivia Martinez", "345-678-9012"},
               new string[] {"1005", "James Taylor", "678-901-2345"},
               new string[] {"1006", "Sophia Anderson", "901-234-5678"},
               new string[] {"1007", "William Thomas", "234-567-8901"},
               new string[] {"1008", "Mia Garcia", "567-890-1234"},
               new string[] {"1009", "Ethan Hernandez", "890-123-4567"}
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
                while((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');
                    Console.WriteLine($"UserID: {fields[0]}, Customer Name: {fields[1]}, Phone Number: {fields[2]}");
                }
            }
        }
    }
}
