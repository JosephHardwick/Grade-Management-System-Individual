using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics.Metrics;
//using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Grade_Management_System_Individual
{
    internal class Course
    {
        private static readonly string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";


        //public int CRN;
        //public string Name;
        //public string Prefix;
        //public string Number;
        //public String Year;
        //public string Semester;
        //public int Hours;

        //public Course(string prefix, string number, String year, string semester)
        //{


        //    this.Prefix = prefix;
        //    this.Number = number;
        //    this.Year = year;
        //    this.Semester = semester;
        //    this.CRN = getCRN(Prefix, Number, Year, Semester);
        //    this.Hours = getHours(this.CRN);
        //}
        ////second constructor to create a course object from CRN
        //public Course(int CRN)
        //{
        //    this.CRN = CRN;

        //    this.Prefix = getPrefix(CRN);

        //    this.Year = getYear(CRN);
        //    this.Semester = getSemester(CRN);
        //    this.Number = getNumber(CRN);
        //    this.Name = getName(CRN);
        //    this.Hours = getHours(CRN);
        //}

        //determines if a course exists by querying DB for CRN
        public static bool ifExists(int CRN)
        {
            string query = "SELECT * FROM hardwick_course WHERE CRN = @CRN";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CRN", CRN);
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

        //gets year from DB by CRN
        public static String getYear(int CRN)
        {

            if (CRN == -1)
            {
               // return -1;
            }
            //string name = "";
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "SELECT Year FROM hardwick_course WHERE CRN = @CRN";

            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CRN", CRN);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetInt32(0).ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("year error");
            }
            conn.Close();
            //return -1;
            return "";
;        }
        //gets course number from DB by CRN
        public static string getNumber(int CRN)
        {

            if (CRN == -1)
            {
                return "";
            }
            //string name = "";
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "SELECT Number FROM hardwick_course WHERE CRN = @CRN";

            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CRN", CRN);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetString(0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("number error");
            }
            conn.Close();
            return "";
        }
        //gets course name from DB by CRN
        public static string getName(int CRN)
        {
            if (CRN == -1)
            {
                return "";
            }
            //string name = "";
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "SELECT Name FROM hardwick_course WHERE CRN = @CRN";

            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CRN", CRN);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetString(0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //MessageBox.Show("Name error");
            }
            conn.Close();
            return "";

        }
        //gets semester from DB by CRN
        public static string getSemester(int CRN)
        {
            if (CRN == -1)
            {
                return "";
            }
            //string name = "";
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "SELECT Semester FROM hardwick_course WHERE CRN = @CRN";

            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CRN", CRN);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetString(0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Semester error");
            }
            conn.Close();
            return "";

        }
        //gets prefix from DB by CRN
        public static string getPrefix(int CRN)
        {
            if (CRN == -1)
            {
                return "";
            }
            //string name = "";
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "SELECT Prefix FROM hardwick_course WHERE CRN = @CRN";

            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CRN", CRN);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetString(0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("prefix error");
            }
            conn.Close();
            return "";

        }
        //gets hours from DB by CRN
        public static int getHours(int CRN)
        {

            if (CRN == -1)
            {
                return -1;
            }
            string name = "";
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "SELECT Hours FROM hardwick_course WHERE CRN = @CRN";

            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CRN", CRN);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("hour error");
            }
            conn.Close();
            return -1;
        }
      
        //get the CRN from the database
        public static int getCRN(string Prefix, string Number, string Year, string Semester)
        {
            int CRN = -1;
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "SELECT CRN FROM hardwick_course WHERE Prefix = @Prefix AND Number = @Number AND Year = @Year AND Semester = @Semester";

            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            //MessageBox.Show("RUNNING CRN METHOD");

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Prefix", Prefix);
                cmd.Parameters.AddWithValue("@Number", Number);
                cmd.Parameters.AddWithValue("@Year", Year);
                cmd.Parameters.AddWithValue("@Semester", Semester);
                //cmd.ExecuteNonQuery();
                //MessageBox.Show(Prefix);
                //MessageBox.Show(Number);
                //MessageBox.Show(Year.ToString());
                //MessageBox.Show(Semester);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    CRN = reader.GetInt32(0);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
                MessageBox.Show("ERROR");
            }
            conn.Close();
            Console.WriteLine("Done.");

            return CRN;
        }
        //create a course in the database
        public static int createCourse(string Prefix, string Number, string Year, string Semester, int Hours)
        {
            
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "INSERT INTO hardwick_course  (Prefix, Year, Semester, Number, Hours) VALUES (@Prefix, @Year, @Semester, @Number, @Hours)";

            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            //MessageBox.Show("RUNNING CRN METHOD");

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Prefix", Prefix);
                cmd.Parameters.AddWithValue("@Number", Number);
                cmd.Parameters.AddWithValue("@Year", Year);
                cmd.Parameters.AddWithValue("@Semester", Semester);
                cmd.Parameters.AddWithValue("@Hours", Hours);
                cmd.ExecuteNonQuery();
                
                
                }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
                MessageBox.Show("ERROR");
            }
            conn.Close();
            Console.WriteLine("Done.");

            return Course.getCRN(Prefix, Number, Year, Semester);
            
        }
            
    }
}
