
--Creating a DB
CREATE DATABASE school_db
CREATE DATABASE Adarsh
--Selecting a DB
USE school_db
SELECT DB_NAME()
--Creating a Table 
CREATE TABLE students(student_id INT, name VARCHAR(250),
                        age INT,grade INT);
--Checking Existing Table
EXEC sp_help 'students'

--Inserting data in Tables
INSERT INTO students(student_id,name,age,grade) VALUES(101,'Raju',10,5);
INSERT INTO students VALUES (102,'Sham',12,7);
INSERT INTO students VALUES(103,'Babu',14,9);
--Reading Data 
SELECT * FROM students 
SELECT * FROM students WHERE name='Sham';
SELECT age FROM students WHERE name='Raju';
--Updating Data
UPDATE students SET grade=12 WHERE student_id=103;
UPDATE students SET grade=6 WHERE student_id=101;
--Deleting Data
DELETE FROM students WHERE student_id=101;
--Inserting Data
INSERT INTO students VALUES(104,'Alex',11,6);
DELETE FROM students WHERE name='Babu';
