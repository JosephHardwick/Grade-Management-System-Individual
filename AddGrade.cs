using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Grade_Management_System_Individual
{
    public partial class AddGrade : Form
    {
        public AddGrade()
        {
            InitializeComponent();
        }

        private void NameRB_CheckedChanged(object sender, EventArgs e)
        {

            //show proper fields depending on which radio button is checked
            if (NameRB.Checked)
            {

                PrefixL.Show();
                PrefixTB.Show();
                NumberL.Show();
                NumberTB.Show();
                SemesterL.Show();
                SemeterCB.Show();
                YearL.Show();
                YearTB.Show();
                CRNL.Hide();
                CRNTB.Hide();
            }
            else
            {
                PrefixL.Hide();
                PrefixTB.Hide();
                NumberL.Hide();
                NumberTB.Hide();
                SemesterL.Hide();
                SemeterCB.Hide();
                YearL.Hide();
                YearTB.Hide();
                CRNL.Show();
                CRNTB.Show();

            }



        }

        private void button1_Click(object sender, EventArgs e)
        {

            //case for adding grade by name
            if (NameRB.Checked)
            {
                //gather data
                string prefix = PrefixTB.Text;
                string number = NumberTB.Text;
                string semester = SemeterCB.Text;
                string year = YearTB.Text;
                string grade = GradeCB.Text;
                string studentID = StudentIDTB.Text;


                //validate data
                if (prefix == "" || number == "" || semester == "" || year == "" || grade == "" || studentID == "")
                {
                    MessageBox.Show("Please fill out all fields");
                    return;
                }

                if (grade != "A" && grade != "B" && grade != "C" && grade != "D" && grade != "F")
                {
                    MessageBox.Show("Please enter a valid grade (A, B, C, D, F)");
                    return;
                }

                if (!int.TryParse(studentID, out int parsedStudentID))
                {
                    MessageBox.Show("Please enter a valid numeric Student ID");
                    return;
                }

                if (Student.ifExists(parsedStudentID) == false)
                {
                    MessageBox.Show("Student does not exist");
                    return;
                }

                if (Course.getCRN(prefix, number, year, semester) == -1)
                {
                    MessageBox.Show("Course does not exist");
                    return;
                }


                int CRN = Course.getCRN(prefix, number, year, semester);

                //validate for grade already existing
                if (gradeExists(studentID, CRN.ToString()))
                {
                    MessageBox.Show("there is already a grade for this student in this course");
                    return;
                }


                //add grade
                string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";


                MySqlConnection conn = new MySqlConnection(connStr);

                string query = "INSERT INTO hardwick_grades (StudentID, CRN, Grade) VALUES (@studentID, @CRN, @Grade)";

                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@studentID", studentID);
                    cmd.Parameters.AddWithValue("@CRN", CRN);
                    cmd.Parameters.AddWithValue("@Grade", grade);
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show(ex.ToString());
                    
                }
                //close the connection
                conn.Close();
                MessageBox.Show("Grade added successfully");





            }
            //case for adding grade by CRN
            else
            {
                //gather data
                string grade = GradeCB.Text;
                string studentID = StudentIDTB.Text;
                string CRN = CRNTB.Text;


                //validation that all fileds are entered
                if (studentID == "" || CRN == "" || grade == "")
                {
                    MessageBox.Show("Please fill out all fields");
                    return;
                }

                //validate data for course existing
                // Validate CRN input
                if (!int.TryParse(CRN, out int parsedCRN))
                {
                    MessageBox.Show("Please enter a valid numeric CRN");
                    return;
                }

                // Validate data for course existing
                if (!Course.ifExists(parsedCRN))
                {
                    MessageBox.Show("Please enter a valid CRN");
                    return;
                }

                //validating for if a valid grade is entered
                if (grade != "A" && grade != "B" && grade != "C" && grade != "D" && grade != "F")
                {
                    MessageBox.Show("Please enter a valid grade (A, B, C, D, F)");
                    return;
                }

               

                //validating for if a valid student is entered
                if (Student.ifExists(Convert.ToInt32(studentID)) == false)
                {
                    MessageBox.Show("Student does not exist");
                    return;
                }

                //validating for if a grade already exists
                if (gradeExists(studentID, CRN.ToString()))
                {
                    MessageBox.Show("there is already a grade for this student in this course");
                    return;
                }

                //inserting grade
                string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
                MySqlConnection conn = new MySqlConnection(connStr);

                string query = "INSERT INTO hardwick_grades (StudentID, CRN, Grade) VALUES (@studentID, @CRN, @Grade)";

                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@studentID", studentID);
                    cmd.Parameters.AddWithValue("@CRN", CRN);
                    cmd.Parameters.AddWithValue("@Grade", grade);
                    cmd.ExecuteNonQuery();



                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show(ex.ToString());
                }
                //close the connection
                conn.Close();
                MessageBox.Show("Grade added successfully");


            }


        }

        public static bool gradeExists(string id, string crn)
        {
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";


            MySqlConnection conn1 = new MySqlConnection(connStr);

            string query1 = "SELECT * FROM hardwick_grades WHERE StudentID = @StudentID AND CRN = @CRN";

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn1.Open();

                MySqlCommand cmd = new MySqlCommand(query1, conn1);
                cmd.Parameters.AddWithValue("@studentID", id);
                cmd.Parameters.AddWithValue("@CRN", crn);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
                return false;
            }
            //close the connection
            conn1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();

        }
    }
}

