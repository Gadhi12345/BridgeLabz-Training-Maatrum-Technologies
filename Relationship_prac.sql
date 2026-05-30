 CREATE DATABASE Customer_DB
USE Customer_DB;
CREATE TABLE customers(cus_id INT NOT NULL IDENTITY(101,1) PRIMARY KEY,
                       cus_name VARCHAR(250) NOT NULL,
                       cus_email VARCHAR(100) UNIQUE);

CREATE TABLE orders(od_id INT NOT NULL IDENTITY(5001,1) PRIMARY KEY,
                       od_date DATE NOT NULL,
                      tota_amount DECIMAL(10,2),
                      cus_id INT,
                      FOREIGN KEY(cus_id) REFERENCES customers(cus_id));
INSERT INTO customers VALUES('Raju','raju@gmail.com'),
                             ('Sham','sham@gmail.com'),
                             ('Baburao','babu@gmail.com');
INSERT INTO orders(od_date, tota_amount, cus_id)
VALUES
('2025-09-15', 1500.00, 101),
('2025-09-28', 800.00, 102),
('2025-10-05', 2200.00, 101),
('2025-10-12', 500.00, 103),
('2025-10-17', 1200.00, 102);

SELECT * FROM customers
SELECT * FROM orders

INSERT INTO orders(od_date,tota_amount) VALUES('2025-10-18','3500')

--Joins
--Cross Join
SELECT * FROM  customers CROSS JOIN orders
--Inner JOIN
SELECT * FROM customers INNER JOIN orders ON customers.cus_id=orders.cus_id

SELECT cus_name,COUNT(o.od_id),SUM(o.tota_amount) FROM customers c INNER JOIN orders o ON c.cus_id=o.cus_id 
GROUP BY cus_name

--left Join 

SELECT cus_name,COUNT(o.od_id),SUM(o.tota_amount) FROM customers c LEFT JOIN orders o ON c.cus_id=o.cus_id 
GROUP BY cus_name

--Right Join
SELECT cus_name,COUNT(o.od_id),SUM(o.tota_amount) FROM customers c RIGHT JOIN orders o ON c.cus_id=o.cus_id 
GROUP BY cus_name


--Full Outer Join
SELECT *  FROM customers FULL OUTER JOIN orders ON customers.cus_id=orders.cus_id

--MANY TO MANY
CREATE DATABASE institute
USE institute
CREATE TABLE courses ( 
  course_id INT IDENTITY(1,1) PRIMARY KEY, 
  course_name VARCHAR(100) NOT NULL, 
  course_fee NUMERIC(10, 2) NOT NULL 
);
INSERT INTO courses (course_name, course_fee)
VALUES
('Mathematics', 500.00),
('Physics', 600.00),
('Chemistry', 700.00);

CREATE TABLE stu (
    student_id INT IDENTITY(1,1) PRIMARY KEY,
    student_name VARCHAR(100) NOT NULL
);
INSERT INTO stu(student_name) VALUES
('Raju'),
('Sham'),
('Baburao'),
('Alex');

CREATE TABLE enrollment (
    enrollment_id INT IDENTITY(1,1) PRIMARY KEY,
    student_id INT NOT NULL,
    course_id INT NOT NULL,
    enrollment_date DATE NOT NULL,
 
    FOREIGN KEY (student_id) REFERENCES stu(student_id),
    FOREIGN KEY (course_id) REFERENCES courses(course_id)
);

INSERT INTO enrollment (student_id, course_id, enrollment_date)
VALUES
(1, 1, '2025-01-01'), -- Raju enrolled in Mathematics
(1, 2, '2025-01-15'), -- Raju enrolled in Physics
(2, 1, '2025-02-01'), -- Sham enrolled in Mathematics
(2, 3, '2025-02-15'), -- Sham enrolled in Chemistry
(3, 3, '2025-03-25'); -- Alex enrolled in Chemistry

SELECT * FROM stu
SELECT * FROM courses


SELECT c.course_name,COUNT(s.student_id),SUM(c.course_fee) FROM enrollment e
INNER JOIN stu s ON e.student_id=s.student_id
INNER JOIN courses c ON e.course_id=c.course_id 
GROUP BY c.course_name

 
 
-----------TAsk e-store-----------
CREATE DATABASE estore_DB
USE estore_DB

CREATE TABLE customers (
    cust_id INT IDENTITY(1,1) PRIMARY KEY,
    cust_name VARCHAR(100) NOT NULL
);

INSERT INTO customers (cust_name)
VALUES
    ('Raju'), ('Sham'), ('Paul'), ('Alex'),('Baburao') ;

CREATE TABLE orders (
    ord_id INT IDENTITY(1,1) PRIMARY KEY,
    ord_date DATE NOT NULL,
    cust_id INT NOT NULL,
    FOREIGN KEY (cust_id) REFERENCES customers(cust_id) ON DELETE CASCADE
);

INSERT INTO orders (ord_date, cust_id)
VALUES
    ('2025-01-01', 1),  -- Raju first order
    ('2025-02-01', 2),  -- Sham first order
    ('2025-03-01', 3),  -- Paul first order
    ('2025-04-04', 2);  -- Sham second order

CREATE TABLE products (
    p_id INT IDENTITY(1,1) PRIMARY KEY,
    p_name VARCHAR(100) NOT NULL,
    price NUMERIC NOT NULL
);

INSERT INTO products (p_name, price)
VALUES
    ('Laptop', 55000.00),
    ('Mouse', 500),
    ('Keyboard', 800.00),
    ('Cable', 250.00),
     ('Monitor', 12000.00);

CREATE TABLE order_items (
    item_id INT IDENTITY(1,1) PRIMARY KEY,
    ord_id INT NOT NULL,
    p_id INT NOT NULL,
    quantity INT NOT NULL,
    FOREIGN KEY (ord_id) REFERENCES orders(ord_id),
    FOREIGN KEY (p_id) REFERENCES products(p_id)
);
INSERT INTO order_items (ord_id, p_id, quantity)
VALUES
    (1, 1, 1),  -- Raju ordered 1 Laptop
    (1, 4, 2),  -- Raju ordered 2 Cables
    (2, 1, 1),  -- Sham ordered 1 Laptop
    (3, 2, 1),  -- Paul ordered 1 Mouse
    (3, 4, 5),  -- Paul ordered 5 Cables
    (4, 3, 1);  -- Sham ordered 1 Keyboard

    SELECT c.cust_name,
    o.ord_id,
    o.ord_date,
    p.p_name,
    p.price,
    oi.quantity,
    oi.quantity*p.price AS total_price
    FROM order_items oi INNER JOIN
    products p ON oi.ord_id=p.p_id INNER JOIN orders o
    ON oi.ord_id=o.ord_id INNER JOIN customers c 
    ON c.cust_id=o.cust_id



    CREATE VIEW enroll AS
    SELECT c.cust_name,COUNT(DISTINCT o.ord_id)  AS no_of_orders,SUM(oi.quantity) AS no_of_products,
    SUM(p.price * oi.quantity) AS total_amount
    FROM order_items oi INNER JOIN
    products p ON oi.ord_id=p.p_id INNER JOIN orders o
    ON oi.ord_id=o.ord_id INNER JOIN customers c 
    ON c.cust_id=o.cust_id GROUP BY c.cust_name
      
SELECT * FROM enroll
--To check existing view
SELECT TABLE_SCHEMA,TABLE_NAME FROM INFORMATION_SCHEMA.VIEWS
 

 --Window functions
 --STORED Procedure
 CREATE PROCEDURE get_employees_sp
 AS
 BEGIN
SELECT * FROM customers
 END

 EXEC get_employees_sp
