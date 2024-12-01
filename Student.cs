using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.VisualBasic.Devices;
using MySql.Data.MySqlClient;

namespace Grade_Management_System_Individual
{
    internal class Student
    {
        private static readonly string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";

        public int StudentID;
        public string Name;
        public double GPA;

        public Student(int ID)
        {
            this.StudentID = ID;
            this.Name = GetName(ID);
            this.GPA = GetGPA(ID);
        }


        //method to check if student exists
        public static bool ifExists(int ID)
        {
            string query = "SELECT * FROM hardwick_student WHERE StudentID = @ID";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.ExecuteNonQuery();

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
            //close the connection
            conn.Close();
            return false;
        }

        //method to get the name of the student
        public static string GetName(int ID)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            string query = "SELECT Name FROM hardwick_student WHERE StudentID = @ID";

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.ExecuteNonQuery();

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetString(0);
                }
                MessageBox.Show("No student found with that ID");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
            //close the connection
            conn.Close();
            return null;

        }
        //method to create a student
        public static int createStudent(string name)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            string query = "INSERT INTO hardwick_student (name, GPA) VALUES (@name, 0); SELECT LAST_INSERT_ID();";

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return (int)reader.GetInt64(0);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
            //close the connection
            conn.Close();

            return -1;
        }
        //method to get the GPA of a student
        public static double GetGPA(int ID)
        {
            updateGPA(ID);
            MySqlConnection conn = new MySqlConnection(connStr);
            string query = "SELECT GPA FROM hardwick_student WHERE StudentID = @ID";

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.ExecuteNonQuery();

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetDouble(0);
                }
                MessageBox.Show("No student found with that ID");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
            //close the connection
            conn.Close();
            return 0;

        }
        //method to update the GPA of a student
        public static void updateGPA(int ID)
        {
            //MessageBox.Show("updateGPA running");
            //list to hold all the courses of the student and their grade in that course
            List<(int hours, char grade)> courses = new List<(int hours, char grade)>();

            //need a course object to get the grade and hours

            //query for all the grades of the student
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "SELECT* FROM hardwick_grades WHERE StudentID = @ID";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                //string sql = query;
                //execute the command

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("executing");
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.HasRows)
                    {
                        return;
                    }
                    int CRN = reader.GetInt32(reader.GetOrdinal("CRN"));
                    char grade = reader.GetChar(reader.GetOrdinal("Grade"));
                    //get the hours for that course
                    
                    int hours = Course.getHours(CRN);

                    //add the course to the list
                    courses.Add((hours, grade));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
            //close the connection
            conn.Close();

            //now that we have all the courses and their grades we can calculate the GPA
            double totalHours = 0;
            double totalPoints = 0;
            foreach ((int hours, char grade) course in courses)
            {
                switch (course.grade)
                {
                    case 'A':
                        totalPoints += course.hours * 4.0;
                        break;
                    case 'B':
                        totalPoints += course.hours * 3.0;
                        break;
                    case 'C':
                        totalPoints += course.hours * 2.0;
                        break;
                    case 'D':
                        totalPoints += course.hours * 1.0;
                        break;
                    case 'F':
                        totalPoints += course.hours * 0;
                        break;
                }
                totalHours += course.hours;
            }

            if (totalPoints == 0)//dont divide by zero if student is failing all classes
            {
                MessageBox.Show("divide by zero");
                return;
            }
            double updatedGPA = (double)totalPoints / totalHours;
            
            //add the updated GPA to the database
            MessageBox.Show("INSIDE UPDATE METHOD GPA: " + updatedGPA);
            //UPDATE cabj_studentinfo_1 SET GPA = @GPA WHERE ID = @ID
            query = "UPDATE hardwick_student SET GPA = @GPA WHERE StudentID = @ID";
            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                //string sql = query;
                //execute the command

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@GPA", updatedGPA);
                cmd.ExecuteNonQuery();
                MessageBox.Show("GPA updated successfully");


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
            //close the connection
            conn.Close();


        }

    }
}