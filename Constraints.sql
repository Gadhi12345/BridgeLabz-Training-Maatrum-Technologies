CREATE DATABASE employees_db
USE employees_db
CREATE TABLE employees(emp_id INT IDENTITY(101,1) PRIMARY KEY,
                       fName VARCHAR(100) NOT NULL,
                       lNAme VARCHAR(100) NOT NULL,
                       email VARCHAR(100) NOT NULL UNIQUE,
                       job_title VARCHAR(100) NOT NULL,
                       dept VARCHAR(100) NOT NULL,
                       salary DECIMAL(10,2) DEFAULT 300000.00,
                       hire_Date DATE NOT NULL DEFAULT CONVERT(date,GETDATE()),
                       city VARCHAR(50));

EXEC sp_help employees;
INSERT INTO employees

(fname, lname, email, job_title, dept, salary, hire_date, city)

VALUES

('Aarav', 'Sharma', 'aarav.sharma@example.com', 'Director', 'Management', 180000, '2019-02-10', 'Mumbai'),

('Diya', 'Pate', 'diya.patel@example.com', 'Lead Engineer', 'Tech', 120000, '2020-08-15', 'Bengaluru'),

('Rohan', 'Mehra', 'rohan.mehra@example.com', 'Software Engineer', 'Tech', 85000, '2022-05-20', 'Bengaluru'),

('Priya', 'Singh', 'priya.singh@example.com', 'HR Manager', 'Human Resources', 95000, '2019-11-05', 'Mumbai'),

('Arjun', 'Kumar', 'arjun.kumar@example.com', 'Data Scientist', 'Tech', 110000, '2021-07-12', 'Hyderabad'),

('Ananya', 'Gupta', 'ananya.gupta@example.com', 'Marketing Lead', 'Marketing', 90000, '2020-03-01', 'Delhi'),

('Vikram', 'Reddy', 'vikram.reddy@example.com', 'Sales Executive', 'Sales', 75000, '2023-01-30', 'Mumbai'),

('Sameera', 'Rao', 'sameera.rao@example.com', 'Software Engineer', 'Tech', 88000, '2023-06-25', 'Pune'),

('Ishaan', 'Verma', 'ishaan.verma@example.com', 'Recruiter', 'Human Resources', 65000, '2022-09-01', 'Mumbai'),

('Kavya', 'Joshi', 'kavya.joshi@example.com', 'Product Designer', 'Design', 92000, '2021-04-18', 'Bengaluru'),

('Zain', 'Khan', 'zain.khan@example.com', 'Sales Manager', 'Sales', 115000, '2019-09-14', 'Delhi'),

('Nish', 'Desai', 'nisha.desai@example.com', 'Jr. Data Analyst', 'Tech', 70000, '2024-02-01', 'Hyderabad'),

('Aditya', 'Nair', 'aditya.nair@example.com', 'Marketing Analyst', 'Marketing', 68000, '2022-10-10', 'Delhi'),

('Fatima', 'Ali', 'fatima.ali@example.com', 'Sales Executive', 'Sales', 78000, '2022-11-22', 'Mumbai'),

('Kabir', 'Shah', 'kabir.shah@example.com', 'DevOps Engineer', 'Tech', 105000, '2020-12-01', 'Pune');

SELECT * FROM employees;
SELECT * FROM employees WHERE dept='Tech';
SELECT * FROM employees WHERE salary>150000;
SELECT * FROM employees WHERE hire_Date>'2020-12-31';
-- if you want to print depaertments wihout any duplicates 
SELECT DISTINCT dept FROM employees;

SELECT * FROM employees ORDER BY salary DESC;
SELECT * FROM employees ORDER BY dept,lNAme; 

--like clause=maches the pattern with text
SELECT * FROM employees WHERE email LIKE '%gupta%';

--Top=if you limited number of records
SELECT TOP 1 * FROM employees  WHERE dept LIKE 'M%' ORDER BY dept DESC ;
SELECT * FROM employees WHERE fName LIKE '____';

--logical Operators AND= if both conditions are true then true  |   OR=if any 1 conditions is true then it is true
SELECT * FROM employees WHERE salary>50000 AND dept='sales';
SELECT * FROM employees WHERE salary>50000 OR dept='sales';

-- IN | NOT IN | BETWEEN
SELECT * FROM employees WHERE dept IN ('Marketing','Sales' , 'M%');
SELECT * FROM employees WHERE salary BETWEEN 50000 AND 680000;

--Aggregate functions 
SELECT COUNT(emp_id) AS Total_Employees  FROM employees;
SELECT MIN(salary) AS Min_Salary FROM employees;
SELECT MAX(salary) AS Max_Salary FROM employees;
SELECT AVG(salary) AS Avg_Salary FROM employees;

--GROUP BY 

SELECT dept FROM employees GROUP BY dept;
SELECT dept,COUNT(emp_id) AS Total FROM employees GROUP BY dept;
SELECT city,COUNT(emp_id) AS No_of_Emplyees FROM employees GROUP BY city;


--Multi-level Grouping
SELECT dept,city, COUNT(emp_id) FROM employees  GROUP BY dept,city ORDER BY dept;

--Having (works with GROUPBY clause)
SELECT dept, COUNT(emp_id) AS total FROM employees  GROUP BY dept HAVING COUNT(emp_id)>2;

--Sub queries =query inside a query(sub query runs firstand gives the result  and then main query uses that result)
SELECT * FROM employees WHERE salary>(select AVG(salary) FROM employees);


--To get highest salary from each dept

SELECT * FROM employees e1 WHERE salary=(SELECT MAX(salary) FROM employees e2 WHERE e2.dept=e1.dept);
SELECT dept,MAX(Salary) FROM employees GROUP BY dept;

--String Functions
SELECT CONCAT(fName,' ',LNAme) AS Full_Name FROM employees; 
SELECT REPLACE(dept,'Human Resources','HR') FROM employees;
SELECT CONCAT(LEFT(dept,1),emp_id),fName FROM employees;
SELECT CONCAT_WS(':',emp_id,CONCAT(fName,' ',lNAme),dept) FROM employees;

--Date Functions
SELECT GETDATE();
SELECT DATEADD( YEAR,2,GETDATE());


--Alter=We can add or remove the column
SELECT * FROM employees
ALTER TABLE employees
ADD phone VARCHAR(15);
ALTER TABLE employees
DROP column phone
--Changing datatype of column means if ou want to increase the limit we can use it 
ALTER TABLE employees
ALTER COLUMN lNAme VARCHAR(275) NOT NULL;
EXEC sp_help employees;
--if you want to change the column name 
EXEC sp_rename 'employees.fName','First_Name','COLUMN';

--To set a default value to a column
ALTER TABLE  employees
ADD CONSTRAINT default_dept DEFAULT 'Trainee' FOR dept;

ALTER TABLE employees
ADD CONSTRAINT check_emp_sal CHECK (salary>0);

ALTER TABLE employees
DROP CONSTRAINT check_emp_sal;

 
 --STORED PROCEDURE
 --with INPUT Parameter
