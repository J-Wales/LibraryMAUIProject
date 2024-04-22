# LibraryMAUIProject

# To build the appropriate database enter the following code into your HeidiSQl or other Daatabase management system: 


# To create the tables: 

# CREATE DATABASE IF NOT EXISTS library;


# CREATE TABLE IF NOT EXISTS customers (
#    CustomerID INT AUTO_INCREMENT PRIMARY KEY,
#    custPassword VARCHAR(50) NOT NULL,
#    custName VARCHAR(100) NOT NULL, 
#    PhoneNumber VARCHAR(12) NOT NULL);

# CREATE TABLE IF NOT EXISTS rentals (
#    RentalID INT AUTO_INCREMENT PRIMARY KEY,
#    CustomerID INT,
#   NumberofBooks INT,
#    BookTitles TEXT,
#    DateRented DATE,
#   FOREIGN KEY (CustomerID) REFERENCES customers(CustomerID));




# To populate the tables: 

# INSERT INTO customers (CustomerID, custPassword, custName, PhoneNumber)
# VALUES 
#    (1000, 'Password', 'Alice Johnson', '123-456-7890'),
#    (1001, 'WordPass', 'Bob Smith', '456-789-0123'),
#    (1002, 'PWord', 'Emily Davis', '789-012-3456'),
#    (1003, 'WordP', 'Michael Wilson', '012-345-6789'),
#    (1004, 'Pard', 'Olivia Martinez', '345-678-9012'),
#    (1005, 'Woss', 'James Taylor', '678-901-2345'),
#    (1006, 'WordP', 'Sophia Anderson', '901-234-5678'),
#    (1007, 'PassW', 'William Thomas', '234-567-8901'),
#    (1008, 'Word', 'Mia Garcia', '567-890-1234'),
#    (1009, 'Pass', 'Ethan Hernandez', '890-123-4567');
