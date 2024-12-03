using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace Grade_Management_System_Individual
{
    public partial class EditDeleteSelect : Form
    {
        public int StudentID;



        public EditDeleteSelect()
        {
            InitializeComponent();
        }

        //methid to populate the list view
        private void populateList(string course, string semester, string grade, string crn)
        {
            ListViewItem item = new ListViewItem(course);
            item.SubItems.Add(semester);
            item.SubItems.Add(grade);
            item.Tag = crn;
            listView1.Items.Add(item);
        }

        private void Searchforstudent_Click(object sender, EventArgs e)
        {
            //refreshes list
            listView1.Items.Clear();

            if (!int.TryParse(SIDField.Text, out int studentID))
            {
                MessageBox.Show("Please enter a valid numeric Student ID.");
                return;
            }

            StudentID = studentID;

            //check if student exists
            if (!Student.ifExists(StudentID))
            {
                MessageBox.Show("Student does not exist");
                return;
            }
            //query to get grades for student
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "SELECT * FROM hardwick_grades JOIN hardwick_course ON hardwick_course.CRN = hardwick_grades.CRN WHERE StudentID = @ID";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", StudentID);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    MessageBox.Show("Student Does Not Have Any Grades To Delete.");
                    return;
                }

                while (reader.Read())
                {

                    int CRN = reader.GetInt32(reader.GetOrdinal("CRN"));
                    char grade = reader.GetChar(reader.GetOrdinal("Grade"));
                    int hours = reader.GetInt32(reader.GetOrdinal("Hours"));
                    string prefix = reader.GetString(reader.GetOrdinal("Prefix"));
                    string number = reader.GetString(reader.GetOrdinal("Number"));
                    string semester = reader.GetString(reader.GetOrdinal("Semester"));
                    string year = reader.GetInt32(reader.GetOrdinal("Year")).ToString();

                    populateList(prefix + " " + number, semester + " " + year, grade.ToString(), CRN.ToString());

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            //delete grade
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "DELETE FROM hardwick_grades WHERE CRN = @CRN AND StudentID = @SID";
            MySqlConnection conn = new MySqlConnection(connStr);

            if (listView1.SelectedItems.Count < 1)
            {
                MessageBox.Show("Please select a grade to delete");
                return;
            }

            string CRN = listView1.SelectedItems[0].Tag.ToString();

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SID", StudentID);
                //MessageBox.Show(StudentID.ToString());
                cmd.Parameters.AddWithValue("@CRN", CRN);
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
            
            Searchforstudent_Click(this, EventArgs.Empty);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            //edit grade
            //validate that a grade is selected
            if (listView1.SelectedItems.Count > 0)
            {

                int selectedCRN = int.Parse(listView1.SelectedItems[0].Tag.ToString());
                UpdateGrade updateGrade = new UpdateGrade(StudentID, selectedCRN);
                updateGrade.Show();
            }
            else
            {
                MessageBox.Show("Please select a grade to edit.");
            }
        }

        private void tomenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}

