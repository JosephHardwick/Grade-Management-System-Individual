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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Grade_Management_System_Individual
{
    public partial class UpdateGrade : Form
    {
        public int ID;
        public int CRN;
       
        public UpdateGrade(int ID, int CRN)
        {
            InitializeComponent();
            this.ID = ID;
            this.CRN = CRN;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "UPDATE hardwick_grades SET grade = @grade WHERE StudentID = @StudentID AND CRN = @CRN";
            MySqlConnection conn = new MySqlConnection(connStr);

            

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Grade", comboBox1.Text);
                cmd.Parameters.AddWithValue("@CRN", CRN);
                cmd.Parameters.AddWithValue("@StudentID", ID);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Grade Updated Successfully");


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
            
        }
    }
    
}
