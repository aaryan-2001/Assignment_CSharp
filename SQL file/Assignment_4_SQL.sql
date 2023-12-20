----CREATING DATABASE

CREATE DATABASE TechShopDB

-- CREARTING TABLES
CREATE TABLE Customers(
	CustomerID INT Primary Key IDENTITY,
	FirstName VARCHAR(200) NOT NULL,
	LastName VARCHAR(200) NOT NULL,
	Email VARCHAR(200) NOT NULL,
	Phone VARCHAR(20),
	Address VARCHAR(200)
 )

 CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY,
    ProductName VARCHAR(100),
    Description TEXT,
    Price NUMERIC(10, 2)
)

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY,
    CustomerID INT,
    OrderDate DATE,
    TotalAmount NUMERIC(10, 2),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)

CREATE TABLE OrderDetail(
	OrderDetailID INT Primary Key IDENTITY,
	OrderID INT,
	ProductID INT,
	Quantity INT,
	FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
	FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
)

CREATE TABLE Inventory (
	InventoryID INT Primary Key IDENTITY,
	ProductID INT, 
	QuantityInStock INT,
	LastStockUpdate DATE,
	FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
)

CREATE TABLE Category (
    CategoryID INT PRIMARY KEY IDENTITY(1001,1),
    CategoryName VARCHAR(50) NOT NULL
)

-------------------------------------------------------------------------------------------------------------------

-- INSERTING VALUES TO TABLES

-- CUSTOMER TABLE

INSERT INTO Customers (FirstName, LastName, Email, Phone, Address)
VALUES 
('Aarav', 'Kumar', 'aarav.kumar@email.com', '1234567890', 'Mumbai, Maharashtra'),
('Aisha', 'Singh', 'aisha.singh@email.com', '9876543210', 'Delhi, Delhi'),
('Rahul', 'Sharma', 'rahul.sharma@email.com', '5551234567', 'Bangalore, Karnataka'),
('Ananya', 'Patel', 'ananya.patel@email.com', '4447890123', 'Hyderabad, Telangana'),
('Ravi', 'Gupta', 'ravi.gupta@email.com', '7778889999', 'Chennai, Tamil Nadu'),
('Neha', 'Jha', 'neha.jha@email.com', '6665554444', 'Kolkata, West Bengal'),
('Amit', 'Mishra', 'amit.mishra@email.com', '3332221111', 'Pune, Maharashtra'),
('Kavya', 'Reddy', 'kavya.reddy@email.com', '2223334444', 'Ahmedabad, Gujarat'),
('Vijay', 'Verma', 'vijay.verma@email.com', '9990001111', 'Jaipur, Rajasthan'),
('Meera', 'Shah', 'meera.shah@email.com', '1112223333', 'Lucknow, Uttar Pradesh')

-- CATEGORY TABLE

INSERT INTO Category (CategoryName)
VALUES 
('Electronics'),
('Furniture'),
('Clothing'),
('Books'),
('Toys'),
('Sports'),
('Home decor'),
('Beauty and Personal Care')

-- Products table

INSERT INTO Products (ProductName, Description, Price, CategoryID)
VALUES
('Smartwatch', 'Fitness tracker with heart rate monitor', 1000.00, 1001),
('Bluetooth Earbuds', 'Wireless earbuds with noise cancellation', 8000.00, 1001),
('LED Monitor', '27-inch 4K UHD LED monitor', 300.00, 1001),
('Digital Camera', 'Compact digital camera with 30x zoom', 250.00, 1001),
('Gaming Laptop', 'High-performance gaming laptop with RGB keyboard', 1500.00, 1001),
('Office Chair', 'Ergonomic office chair with lumbar support', 1500.00, 1002),
('Coffee Table', 'Modern coffee table with tempered glass top', 1200.00, 1002),
('Wardrobe', 'Large wardrobe with sliding doors', 4000.00, 1002),
('T-shirt', 'Cotton round neck T-shirt', 200.00, 1003),
('Jeans', 'Slim-fit denim jeans', 500.00, 1003),
('Novel', 'Best-selling novel by a popular author', 1500.00, 1004),
('Tabletop Board Game', 'Strategy board game for family and friends', 3000.00, 1005),
('Football', 'Official size and weight football', 2500.00, 1006),
('Yoga Mat', 'Non-slip yoga mat for home workouts', 2000.00, 1006),
('Throw Pillow', 'Decorative throw pillow for living room', 1000.00, 1007),
('Scented Candle', 'Aromatherapy scented candle for relaxation', 150.00, 1007),
('Skin Care Set', 'Complete skincare set for daily routine', 500.00, 1008),
('Hair Dryer', 'Ionic hair dryer with multiple heat settings', 450.00, 1008),
('Makeup Brushes', 'Professional makeup brush set', 2500.00, 1008),
('Shower Gel', 'Refreshing shower gel with natural ingredients', 1200.00, 1008)

 -- Orders table

INSERT INTO Orders (CustomerID, OrderDate, TotalAmount)
VALUES
(1, '2023-12-01', 30000.00),
(2, '2023-12-02', 5000.00),
(3, '2023-12-03', 7000.00),
(4, '2023-12-04', 4500.00),
(5, '2023-12-05', 8000.00),
(6, '2023-12-06', 2500.00),
(7, '2023-12-07', 6000.00),
(8, '2023-12-08', 3500.00),
(9, '2023-12-09', 9000.00),
(10, '2023-12-10', 4000.00),
(1, '2023-12-01', 5500.00),
(2, '2023-12-02', 7500.00),
(3, '2023-12-03', 3000.00),
(4, '2023-12-04', 6500.00),
(5, '2023-12-05', 4000.00),
(6, '2023-12-06', 2000.00),
(7, '2023-12-07', 3500.00),
(8, '2023-12-08', 6000.00),
(9, '2023-12-09', 4500.00),
(10, '2023-12-10', 7000.00)

-- OrderDetails table

INSERT INTO OrderDetail (OrderID, ProductID, Quantity)
VALUES
(1, 23, 2),
(1, 22, 1),
(2, 21, 3),
(2, 4, 1),
(3, 5, 2),
(3, 7, 1),
(4, 9, 1),
(4, 11, 2),
(5, 13, 1),
(5, 15, 3),
(6, 17, 1),
(6, 19, 2),
(7, 21, 1),
(7, 23, 2),
(8, 5, 3),
(8, 7, 1),
(9, 8, 2),
(9, 6, 1),
(10, 13, 1),
(10, 15, 2)

-- Inventory table

INSERT INTO Inventory (ProductID, QuantityInStock, LastStockUpdate)
VALUES
(4, 50, GETDATE()),
(6, 30, GETDATE()),
(5, 20, GETDATE()),
(7, 25, GETDATE()),
(9, 15, GETDATE()),
(11, 40, GETDATE()),
(13, 35, GETDATE()),
(15, 10, GETDATE()),
(17, 18, GETDATE()),
(19, 22, GETDATE()),
(21, 28, GETDATE()),
(23, 15, GETDATE()),
(8, 12, GETDATE()),
(10, 8, GETDATE()),
(12, 20, GETDATE()),
(14, 30, GETDATE()),
(16, 25, GETDATE()),
(18, 15, GETDATE()),
(20, 18, GETDATE()),
(22, 10, GETDATE())

-------------------------------------------------------------------------------------------------------------------

--1. Write an SQL query to retrieve the names and emails of all customers. 

SELECT FirstName+' '+ LastName as Name, Email
FROM Customers

-------------------------------------------------------------------------------------------------------------------

--2. Write an SQL query to list all orders with their order dates and corresponding customer names.

SELECT OrderDate, FirstName+' '+ LastName as Name 
FROM Orders , Customers
WHERE Orders.CustomerID = Customers.CustomerID

-------------------------------------------------------------------------------------------------------------------

--3. Write an SQL query to insert a new customer record into the "Customers" table. Include 
--customer information such as name, email, and address.

INSERT INTO Customers (FirstName, LastName, Email, Phone, Address)
VALUES
('Aryan', 'Shah', 'aryan.shah@gmail.com', '458963210','MP India')

-------------------------------------------------------------------------------------------------------------------

--4. Write an SQL query to update the prices of all electronic gadgets in the "Products" table by  increasing them by 10%.

UPDATE Products
SET Price = Price*1.10 --1.10 is equivalent to 10%
WHERE CategoryID = 1001

-------------------------------------------------------------------------------------------------------------------

--5. Write an SQL query to delete a specific order and its associated order details from the 
--"Orders" and "OrderDetails" tables. Allow users to input the order ID as a parameter.

DECLARE @od INT =10

DELETE FROM OrderDetail 
WHERE OrderID=@od
DELETE FROM Orders
WHERE OrderID=@od

SELECT * FROM Orders
-------------------------------------------------------------------------------------------------------------------

--6. Write an SQL query to insert a new order into the "Orders" table. Include the customer ID, 
--order date, and any other necessary information.

INSERT INTO Orders (CustomerID, OrderDate, TotalAmount)
VALUES
( 1, '2023-11-15', 9000.00)

SELECT * FROM Orders

-------------------------------------------------------------------------------------------------------------------

--7. Write an SQL query to update the contact information (e.g., email and address) of a specific 
--customer in the "Customers" table. Allow users to input the customer ID and new contact information

UPDATE Customers 
SET FirstName = 'Vikram', LastName = 'Shroff', Email='Vikram.Shroff@gmail.com', Phone='5896214760', Address='Port Blair' 
WHERE CustomerID=3

SELECT * FROM Customers

-------------------------------------------------------------------------------------------------------------------

--8. Write an SQL query to recalculate and update the total cost of each order in the "Orders" 
--Table based on the prices and quantities in the "OrderDetails" table.

UPDATE Orders
SET TotalAmount = (
SELECT SUM(Quantity * Products.Price)
FROM OrderDetail
JOIN Products ON OrderDetail.ProductID = Products.ProductID
WHERE OrderDetail.OrderID = Orders.OrderID
)

SELECT * FROM Orders

-------------------------------------------------------------------------------------------------------------------

--9. Write an SQL query to delete all orders and their associated order details for a specific 
--customer from the "Orders" and "OrderDetails" tables. Allow users to input the customer ID 
--as a parameter.

DECLARE @CustID INT = 10

DELETE FROM OrderDetail 
WHERE OrderID=(
SELECT OrderID FROM Orders 
WHERE CustomerID = @CustID
)

DELETE FROM Orders
WHERE CustomerID = @CustID

-------------------------------------------------------------------------------------------------------------------

--10. Write an SQL query to insert a new electronic gadget product into the "Products" table, 
--including product name, category, price, and any other relevant details.


INSERT INTO Products(ProductName, Description, Price, CategoryID)
VALUES
('TV', 'Entertainment product', '900.00',1001),
('washing machine',' Automatic cloth cleaner', '500',1001)

Select * From products

-------------------------------------------------------------------------------------------------------------------

--11. Write an SQL query to update the status of a specific order in the "Orders" table (e.g., from 
--"Pending" to "Shipped"). Allow users to input the order ID and the new status.

ALTER TABLE Orders
ADD Status varchar(100) DEFAULT 'pending'

UPDATE Orders 
SET Status = 'Pending' 
WHERE Status IS NULL	--this is to update the new status from pending to shipped

DECLARE @Update_OrderID INT = 1 -- declaring the variables here using declare @ AS USER INPUT
DECLARE @New_Status VARCHAR(50) = 'Shipped'

UPDATE Orders
SET Status = @New_Status
WHERE OrderID = @Update_OrderID

Select * From Orders

-------------------------------------------------------------------------------------------------------------------

--12. Write an SQL query to calculate and update the number of orders placed by each customer 
--in the "Customers" table based on the data in the "Orders" table.

ALTER TABLE Customers
ADD TotalOrders INT

UPDATE Customers
SET TotalOrders=(
SELECT COUNT(*) FROM Orders WHERE Orders.CustomerID = Customers.CustomerID
)

--another way -- Select Count(*) from Orders group by CustomerID

-------------------------------------------------------------------------------------------------------------------

/*Task 5. Aggregate functions, Having, Order By, GroupBy and Joins:

1. Write an SQL query to retrieve a list of all orders along with customer information (e.g.,
customer name) for each order.*/

SELECT O.OrderID, O.orderdate, C.customerid, C.firstname, C.lastname
FROM Orders O
JOIN Customers C ON
O.CustomerID = C.CustomerID

-------------------------------------------------------------------------------------------------------------------

--2. Write an SQL query to find the total revenue generated by each electronic gadget product.
--Include the product name and the total revenue.


SELECT P.CategoryID, P.ProductName, SUM(OD.Quantity* P.Price) AS TotalRevenue
FROM Products P 
LEFT JOIN  OrderDetail OD ON
P.ProductID = OD.ProductID
WHERE P.CategoryID = '1001'
GROUP BY P.CategoryID, P.ProductName
ORDER BY TotalRevenue

-------------------------------------------------------------------------------------------------------------------

--3. Write an SQL query to list all customers who have made at least one purchase. Include their 
--names and contact information.

SELECT DISTINCT C.FirstName, C.LastName, C.Email, C.Phone 
FROM Customers C
RIGHT JOIN Orders O ON
C.CustomerID = O.CustomerID

-------------------------------------------------------------------------------------------------------------------

--4. Write an SQL query to find the most popular electronic gadget, which is the one with the highest 
--total quantity ordered. Include the product name and the total quantity ordered.


SELECT C.CategoryName, P.ProductName, SUM(OD.Quantity) AS TotalQuantityOrdered
FROM Products P 
JOIN  OrderDetail OD ON
P.ProductID = OD.ProductID
JOIN Category C ON
C.CategoryID = P.CategoryID
WHERE C.CategoryName = 'Electronics'
GROUP BY C.CategoryName, P.ProductName
ORDER BY TotalQuantityOrdered DESC

-------------------------------------------------------------------------------------------------------------------

-- 5. Write an SQL query to retrieve a list of electronic gadgets along with their corresponding categories.
SELECT P.productid,P.ProductName,P.CategoryID, C.categoryname
FROM Products P
JOIN Category C ON P.categoryid = C.categoryid
WHERE C.CategoryName = 'Electronics'

-------------------------------------------------------------------------------------------------------------------

--6. Write an SQL query to calculate the average order value for each customer. Include the 
--customer's name and their average order value

SELECT C.FirstName, C.LastName , C.CustomerID, AVG(O.TotalAmount) 
AS AverageOrderValue  
FROM Customers C
LEFT JOIN Orders O ON
C.CustomerID = O.CustomerID
GROUP BY C.CustomerID, C.FirstName, C.LastName

Select * From Orders

-------------------------------------------------------------------------------------------------------------------

--7. Write an SQL query to find the order with the highest total revenue. Include the order ID, 
--customer information, and the total revenue.

SELECT TOP 1 C.FirstName, C.LastName , C.CustomerID, O.OrderID, O.TotalAmount
AS TotalRevenue  
FROM Customers C
LEFT JOIN Orders O ON
C.CustomerID = O.CustomerID
GROUP BY C.CustomerID, C.FirstName, C.LastName, O.TotalAmount, O.OrderID
ORDER BY O.TotalAmount DESC

-------------------------------------------------------------------------------------------------------------------

-- 8. Write an SQL query to list electronic gadgets and the number of times each product has been ordered.

SELECT P.ProductID, P.ProductName, C.CategoryName, COUNT(OD.OrderID)
FROM Products P
JOIN OrderDetail OD ON
P.ProductID = OD.ProductID
JOIN Category C ON
C.CategoryID = P.CategoryID
WHERE C.CategoryName = 'Electronics'
GROUP BY P.ProductID, P.ProductName, C.CategoryName

-------------------------------------------------------------------------------------------------------------------

--9. Write an SQL query to find customers who have purchased a specific electronic gadget product. 
--Allow users to input the product name as a parameter.

DECLARE @ProductName VARCHAR(50) = 'Smartwatch'

SELECT C.CustomerID, C.FirstName, C.LastName
FROM Customers C 
JOIN Orders O ON 
C.CustomerID = O.CustomerID
JOIN OrderDetail OD ON 
O.OrderID = OD.OrderID
JOIN Products P ON 
OD.ProductID = P.ProductID
WHERE P.ProductName = @ProductName  


-------------------------------------------------------------------------------------------------------------------

--10. Write an SQL query to calculate the total revenue generated by all orders placed within a 
--specific time period. Allow users to input the start and end dates as parameters.

DECLARE @StartDate DATE = '2023-11-01'
DECLARE @EndDate DATE = '2023-11-29'

SELECT SUM(OD.Quantity* P.Price) AS TotalRevenue
FROM Products P 
LEFT JOIN  OrderDetail OD ON
P.ProductID = OD.ProductID

-------------------------------------------------------------------------------------------------------------------

--# Aggregate Functions

--1.Write an SQL query to find out which customers have not placed any orders.

SELECT C.CustomerID, C.FirstName, C.LastName
FROM Customers C
LEFT JOIN Orders O ON C.CustomerID = O.CustomerID
WHERE O.OrderID IS NULL

-------------------------------------------------------------------------------------------------------------------

--2. Write an SQL query to find the total number of products available for sale.

SELECT COUNT(*) FROM Products

-------------------------------------------------------------------------------------------------------------------

--3. Write an SQL query to calculate the total revenue generated by TechShop. 

SELECT SUM(TotalAmount) AS REVENUE FROM Orders

-------------------------------------------------------------------------------------------------------------------

--4. Write an SQL query to calculate the average quantity ordered for products in a specific category. 
--Allow users to input the category name as a parameter.

DECLARE @CatName VARCHAR(50) = 'Electronics'
 
 SELECT AVG(Quantity)
 FROM OrderDetail OD
 WHERE OD.ProductID IN (SELECT P.ProductID FROM Products P WHERE P.CategoryID IN
 (SELECT C.CategoryID FROM Category C WHERE C.CategoryName = @CatName))

-------------------------------------------------------------------------------------------------------------------

--5. Write an SQL query to calculate the total revenue generated by a specific customer. Allow users 
--to input the customer ID as a parameter.


DECLARE @CName int = 1
 
 SELECT SUM(TotalAmount) FROM Orders
 WHERE CustomerID = @CName

 -------------------------------------------------------------------------------------------------------------------

 --6 Write an SQL query to find the customers who have placed the most orders. List their names 
--and the number of orders they've placed.

SELECT TOP 1 C.FirstName, C.LastName, (
SELECT COUNT(*)
FROM Orders O
WHERE O.CustomerID = C.CustomerID
) 
AS OrderCount
FROM Customers C
ORDER BY OrderCount DESC
 
--------------------------------------------------------------------------------------------------------------------

--7. Write an SQL query to find the most popular product category, which is the one with the highest 
--total quantity ordered across all orders

SELECT C.CategoryName ,SUM(OD.Quantity) AS TotalQuantityOrdered
FROM Products P 
JOIN  OrderDetail OD ON
P.ProductID = OD.ProductID
JOIN Category C ON
P.CategoryID = C.CategoryID
GROUP BY C.CategoryName
ORDER BY TotalQuantityOrdered DESC 

-------------------------------------------------------------------------------------------------------------------

--8. Write an SQL query to find the customer who has spent the most money (highest total revenue
--on electronic gadgets. List their name and total spending.

SELECT C.CustomerID, C.FirstName, SUM(O.TotalAmount) AS TA
FROM Customers C
JOIN Orders O ON
C.CustomerID = O.CustomerID
JOIN OrderDetail OD ON
O.OrderID = OD.OrderID
JOIN Products P ON
P.ProductID = OD.ProductID
WHERE P.CategoryID = 1001
GROUP BY C.CustomerID, C.FirstName, O.TotalAmount
ORDER BY TA DESC

-------------------------------------------------------------------------------------------------------------------

--9. Write an SQL query to calculate the average order value (total revenue divided by the number of 
--orders) for all customers.

SELECT AVG(TotalAmount) AS AverageOrderValue FROM Orders

-------------------------------------------------------------------------------------------------------------------


--10. Write an SQL query to find the total number of orders placed by each customer and list their 
--names along with the order count

SELECT C.FirstName, C.LastName, COUNT(O.OrderID) AS OCount 
FROM Customers C
LEFT JOIN Orders O ON
C.CustomerID = O.CustomerID
GROUP BY C.CustomerID,
C.FirstName, C.LastName
ORDER BY OCount DESC

-------------------------------------------------------------------------------------------------------------------
