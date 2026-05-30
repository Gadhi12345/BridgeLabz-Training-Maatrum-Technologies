CREATE DATABASE University_DB
USE University_DB

CREATE TABLE Students(stu_id INT PRIMARY KEY IDENTITY(1,1),
                      stu_Name VARCHAR(100) NOT NULL,
                      email VARCHAR(100) UNIQUE NOT NULL,
                      addmission_date DATE DEFAULT GETDATE(),
                      phone VARCHAR(15),
                      dept VARCHAR(100) NOT NULL,
                      stu_status VARCHAR(100) NOT NULL
                      )
INSERT INTO Students(stu_Name,email,phone,dept,stu_status) VALUES('Adarsh','adarsh@gmail.com','9390875475','CINTEL','active')
INSERT INTO students
(stu_Name, email, phone, dept, stu_status)
VALUES
('Rahul', 'rahul@srmist.edu.in', '9030388269', 'NWC', 'active'),

('kiran', 'kiran@srmist.edu.in', '9876543210', 'CTECH', 'active'),

('Tarun', 'tarun@srmist.edu.in', '9123456780', 'CINTEL', 'inactive'),

('Varun', 'varun@srmist.edu.in', '9012345678', 'DSBS', 'active'),

('Charan', 'charan@srmist.edu.in', '9345678123', 'NWC', 'active'),

('Aditya', 'aditya@srmist.edu.in', '9785612340', 'CTECH', 'inactive'),

('Durga', 'durga@srmist.edu.in', '9090909090', 'CINTEL', 'active'),

('MSD', 'msd@srmist.edu.in', '9887766554', 'DSBS', 'active'),

('NTR', 'ntr@srmist.edu.in', '9556677889', 'NWC', 'active');
SELECT * FROM Students

CREATE TABLE Course(course_id INT PRIMARY KEY IDENTITY(101,1),
                    course_Name VARCHAR(100) NOT NULL,
                    course_fee NUMERIC(10,0) CHECK(course_fee>0) NOT NULL,
                    course_duration VARCHAR(100) NOT NULL,
                    faculty_name VARCHAR(100) NOT NULL
                    )
INSERT INTO Course(course_Name,course_fee,course_duration,faculty_name) VALUES('DIP',30000,'6 Months','Dr.Bali');
INSERT INTO Course(course_Name,course_fee,course_duration,faculty_name) VALUES('Cloud Computing' , 100000  , '3 Months' , 'Dr.Ali');
INSERT INTO Course(course_Name,course_fee,course_duration,faculty_name) VALUES('.NET' , 150000 , '6 Months' , 'Dr.Coolie');
INSERT INTO Course(course_Name,course_fee,course_duration,faculty_name) VALUES('DBMS' , 55000 , '3 Months' , 'Dr.Brucelee');
INSERT INTO Course(course_Name,course_fee,course_duration,faculty_name) VALUES('AIML' , 120000, '6 Months' , 'Dr.Dongelee');

SELECT * FROM Course

CREATE TABLE enrollement(enroll_id INT PRIMARY KEY IDENTITY(1001,1),
                          stu_id INT NOT NULL
                          FOREIGN KEY(stu_id) REFERENCES Students(stu_id) ON DELETE CASCADE,
                          course_id INT NOT NULL
                          FOREIGN KEY(course_id) REFERENCES Course(course_id)  ON DELETE CASCADE,
                          enroll_date DATE DEFAULT GETDATE() NOT NULL,
                          subject_status VARCHAR(100) NOT NULL)
insert into enrollement values(1,101,default , 'on going');
insert into enrollement values     
(1 , 102 , default , 'completed'),   
(1 , 105 , default , 'on going'),     

(2 , 101 , default , 'completed'),    
(2 , 102 , default , 'on going'),     
(2 , 105 , default , 'completed'),    

(3 , 103 , default , 'on going'),     

(4 , 104 , default , 'completed'),   
(4 , 103 , default , 'on going'),    

(5 , 104 , default , 'on going'),     

(6 , 103 , default , 'completed'),    

(7 , 104 , default , 'on going'),     
(7 , 103 , default , 'completed'),   

(8 , 104 , default , 'completed');
insert into enrollement values (3 , 105 , default , 'on going')

--Update
UPDATE Students SET dept='NWC' WHERE stu_id=1;
SELECT * FROM Students
UPDATE Students SET dept='Cloud' WHERE dept='NWC';
UPDATE Course SET course_fee=690000 WHERE course_Name='AIML';
SELECT * FROM Course
--Delete
SELECT * FROM Students
SELECT * FROM enrollement


--students enroolled in courses
SELECT DISTINCT(stu_id),(course_id) FROM enrollement
--student not enrolled in any course
SELECT * FROM Students WHERE stu_status='inactive'
--student who enrolled the course
SELECT * FROM Students WHERE stu_status='active'


--JOINS
--student Name with course name
SELECT s.stu_Name, c.course_Name FROM Students s INNER JOIN enrollement e ON s.stu_id=e.stu_id INNER JOIN Course c ON e.course_id=c.course_id

INSERT INTO Students(stu_Name,email,phone,dept,stu_status) VALUES('qwerty','qwerty@gmail.com','123456789','CINTEL','inactive')
INSERT INTO Students(stu_Name,email,phone,dept,stu_status) VALUES('abcde','abcde@gmail.com','234567788','NWC','inactive')

--Left JOIN
SELECT s.stu_id,s.stu_Name,s.stu_status FROM Students s LEFT JOIN enrollement e ON s.stu_id=e.stu_id WHERE s.stu_status='inactive'


SELECT s.stu_id,s.stu_Name,s.email,s.addmission_date,s.dept,s.stu_status,e.course_id,e.enroll_date,e.subject_status FROM Students s FULL OUTER JOIN enrollement e ON s.stu_id=e.stu_id

--INDEX
CREATE NONCLUSTERED INDEX idx_email
ON Students(email)

--STORED Procedure 
CREATE or alter PROCEDURE sp_add_student
   @p_st_name VARCHAR(100),
   @p_email VARCHAR(100),
   @p_phone VARCHAR(100),
   @p_dept1 VARCHAR(100),
   @p_status VARCHAR(100)
   AS
   BEGIN 
       INSERT INTO Students(stu_Name,email,phone,dept,stu_status) VALUES(@p_st_name,@p_email,@p_phone,@p_dept1,@p_status)
   END 

  EXEC sp_add_student 'Chandra','chandra@gmail.com','937582668','.Net','active'

  insert into enrollement values(11,105,default , 'on going');



--Triggers 
CREATE TRIGGER msg_trigger
ON enrollement
 AFTER INSERT
 AS
 BEGIN
   PRINT 'Succes'
 END

 EXEC sp_help 'msg_trigger'


 CREATE TRIGGER trg_prevent_student_delete
ON Students
INSTEAD OF DELETE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM enrollement e
        INNER JOIN deleted d
        ON e.stu_id = d.stu_id
    )

    BEGIN
        PRINT 'Cannot delete student because enrollments exist'
    END

    ELSE

    BEGIN
        DELETE FROM students
        WHERE stu_id IN (SELECT stu_id FROM deleted)

        PRINT 'Student deleted successfully'
    END

END

EXEC sp_help 'trg_prevent_student_delete'