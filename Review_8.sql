CREATE DATABASE StudentManagement_DB
USE StudentManagement_DB
--Create table with table name as students
CREATE TABLE students(ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
                      St_Name VARCHAR(250) NOT NULL,
                      Email VARCHAR(250) NOT NULL UNIQUE);
--Create table with table name as employees
SELECT * FROM students

CREATE TABLE employees(emp_id int NOT NULL IDENTITY(101,1) PRIMARY KEY,
                        emp_name VARCHAR(250) NOT NULL,
                        emp_email VARCHAR(250) NOT NULL UNIQUE)
--Create a Stored procedure for viewstudent in student table
CREATE PROCEDURE sp_viewstudent
@stu_id INT
AS 
BEGIN
SELECT * FROM students WHERE ID=@stu_id;
END;
--Create a Stored procedure for deletestudent in student table
SELECT * FROM employees

CREATE PROCEDURE sp_deletestudent
@stu11_id INT
AS 
BEGIN
   DELETE FROM students WHERE ID=@stu11_id;
END;
--Create a Stored procedure for viewemployee in employees table


CREATE PROCEDURE sp_viewemployee
@emp_id INT
AS 
BEGIN
SELECT * FROM employees WHERE emp_id=@emp_id;
END;
--Create a Stored procedure for deleteemployee in employees table
CREATE PROCEDURE sp_deleteemployee
@emp22_id INT
AS 
BEGIN
   DELETE FROM employees WHERE emp_id=@emp22_id;
END;

