using System.Data;
using System; 
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
namespace Review_8_ADONET
{

    public class Program
    {
        static void Main(string[] args)
        {


            using SqlConnection con = new SqlConnection("Data Source=ADARSH-PC\\SQLEXPRESS;Initial Catalog=StudentManagement_DB;Integrated Security=True;Trust Server Certificate=True");
            {
                //View employee
                SqlCommand cmd = new SqlCommand("sp_viewemployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@emp_id ", 104);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine("Employee ID : " + dr["emp_id"]);
                    Console.WriteLine("Name       : " + dr["emp_name"]);
                    Console.WriteLine("email        : " + dr["emp_email"]);

                }
                dr.Close();

                /*
                 //Delete employee
                   SqlCommand cmd = new SqlCommand("sp_deleteemployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@emp22_id", 103);

                con.Open();

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                    Console.WriteLine("Student Deleted Successfully");
                else
                    Console.WriteLine("Student Not Found");


             
                 //Delete the student 
                  SqlCommand cmd = new SqlCommand("sp_deletestudent", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@stu11_id", 1);

                con.Open();

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                    Console.WriteLine("Student Deleted Successfully");
                else
                    Console.WriteLine("Student Not Found");



                 //View the student
                 SqlCommand cmd = new SqlCommand("sp_viewstudent", con);
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.AddWithValue("@stu_id ", 1);
                 con.Open();
                 SqlDataReader dr = cmd.ExecuteReader();
                 while (dr.Read())
                {
                   Console.WriteLine("Student ID : " + dr["ID"]);
                   Console.WriteLine("Name       : " + dr["St_Name"]);
                   Console.WriteLine("email       : " + dr["Email"]);

                }
                dr.Close();


                 //Update employee name in employees table
                SqlCommand cmd = new SqlCommand("UPDATE employees SET emp_name='koseksi panchapulusula' WHERE emp_id=103", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader[1]);
                }



                //Update student name in student table
                 SqlCommand cmd = new SqlCommand("UPDATE students SET st_Name='Pancha Batla Saranga Pani' WHERE ID=1", con);
                 con.Open();
                 SqlDataReader reader = cmd.ExecuteReader();
                 while (reader.Read())
                 {
                     Console.WriteLine( reader[1]);
                 }

                 /*
                  //Inserting employee details
                 SqlCommand cmd =new SqlCommand("INSERT INTO employees VALUES ('Johny','Johny@gmail.com'),('Dani','Dani@gmail.com'),('Baba','Baba@gmail.com'),('Raja','Raja@gmail.com'),('kajal','kajal@gmail.com')", con);
                 con.Open();
                 SqlDataReader reader = cmd.ExecuteReader();
                 while (reader.Read())
                 {
                     Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2]);
                 }


                 //Inserting student details
                 SqlCommand cmd =new SqlCommand("INSERT INTO students VALUES ('Adipurush','Adipurush@gmail.com'),('Arundathi','Arundathi@gmail.com')", con);
                 con.Open();
                 SqlDataReader reader = cmd.ExecuteReader();
                 while (reader.Read())
                 {
                     Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2]);
                 }
                 */



                ;
            }
        }
    }
}
