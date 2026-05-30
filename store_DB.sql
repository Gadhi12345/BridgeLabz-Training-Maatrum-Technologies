-- creating the database.--
create database store_db
use store_db

-- creating tables -- 
create table Customers
(
  customer_id int  identity(1,1) primary key,
  customer_name varchar(50) not null ,
  customer_email varchar(100) not null unique check (customer_email like '%@%.%'),
);

INSERT INTO Customers (customer_name, customer_email) 
VALUES 
('Amar', 'Amar@cloud.com'), 
('NTR', 'dragon@tfi.com'), 
('MSD', 'mahi@csk.com');

create table Orders
(
  order_id int identity(1,1) primary key,
  order_date date not null,
  total_amount decimal(10,2),
  customer_id int ,
  foreign key (customer_id) references  Customers(customer_id)
);

INSERT INTO Orders (order_date, total_amount, customer_id) 
VALUES 
('2025-09-15', 1500.00, 1), -- This links to Raju (customer_id 100) 
('2025-09-28', 800.00, 2), -- This links to Sham (customer_id 101) 
('2025-10-05', 2200.00, 1), -- This links to Raju (customer_id 100) 
('2025-10-12', 500.00, 3), -- This links to Baburao (customer_id 102) 
('2025-10-17', 1200.00, 1); -- New order for Sham (customer_id 101)

select * from Customers
select * from Orders

INSERT INTO Orders (order_date, total_amount) 
VALUES ('2025-10-18', 1200.00);


INSERT INTO Customers (customer_name, customer_email) 
VALUES ('Aditya', 'Adi@RCB.com')

-- joins --
-- cross join  --

select * from
Customers cross join Orders;

-- inner join --

select * from 
Customers inner join Orders
on Customers.customer_id = Orders.customer_id 

-- inner join using group by -- 
select c.customer_name, count (o.order_id) , sum(o.total_amount)  from
Customers c inner join Orders o
on 
c.customer_id = o.customer_id
group by c.customer_name 


--- left join -- 

select * from 
Customers left join Orders
on Customers.customer_id = Orders.customer_id 

select c.customer_name, count (o.order_id) , sum(o.total_amount)  from
Customers c left join Orders o
on 
c.customer_id = o.customer_id
group by c.customer_name 


-----------------------------------

CREATE TABLE CompanyHierarchy (
    EmployeeID INT PRIMARY KEY,
    Name VARCHAR(100),
    ManagerID INT
);

INSERT INTO CompanyHierarchy (EmployeeID, Name, ManagerID)
VALUES
(1, 'Sonia Verma', NULL),   -- The CEO
(2, 'Rohan Gupta', 1),      -- Reports to Sonia
(3, 'Amit Sharma', 2),      -- Reports to Rohan
(4, 'Priya Singh', 1),      -- Reports to Sonia
(5, 'Kabir Shah', 2);       -- Reports to Rohan


SELECT
    e.Name AS employee_name,
    m.Name AS manger_name
FROM CompanyHierarchy e
LEFT JOIN CompanyHierarchy m
ON e.ManagerID = m.EmployeeID;
select * from Orders

