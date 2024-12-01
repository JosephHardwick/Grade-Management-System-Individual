﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;

namespace Grade_Management_System_Individual
{
    public partial class PrintTranscript : Form
    {
        public PrintTranscript()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //validate that student exists
            if (!Student.ifExists(int.Parse(textBox1.Text)))
            {
                MessageBox.Show("Student does not exist");
                return;
            }

            //get student info
            String ID = textBox1.Text;
            String Name = Student.GetName(int.Parse(ID));
            String GPA = Student.GetGPA(int.Parse(ID)).ToString();

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                Title = "Save Transcript as PDF"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
                string query = "SELECT * FROM hardwick_grades JOIN hardwick_course ON hardwick_grades.CRN = hardwick_course.CRN WHERE StudentID = @ID";
                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", ID);
                MySqlDataReader reader = cmd.ExecuteReader();

                //check if student has records
                if (!reader.HasRows)
                {
                    MessageBox.Show("Student has no records");
                    return;
                }

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    Document doc = new Document(PageSize.A4);
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    // Add student info
                    doc.Add(new Paragraph($"{Name}'s Transcript", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18)));
                    doc.Add(new Paragraph($"Student ID: {ID}"));
                    doc.Add(new Paragraph($"Name: {Name}"));
                    doc.Add(new Paragraph($"GPA: {GPA}"));
                    doc.Add(new Paragraph(" ")); // Add a blank line

                    // Add table for courses
                    PdfPTable table = new PdfPTable(6);
                    table.AddCell("Course Desc");
                    table.AddCell("Course Name");
                    table.AddCell("Year");
                    table.AddCell("Semester");
                    table.AddCell("Hours");
                    table.AddCell("Grade");

                    //itteratively add courses
                    while (reader.Read())
                    {
                        int CRN = reader.GetInt32(reader.GetOrdinal("CRN"));
                        string grade = reader.GetString(reader.GetOrdinal("grade"));
                        string courseName = reader.IsDBNull(reader.GetOrdinal("name")) ? "N/A" : reader.GetString(reader.GetOrdinal("name"));

                        string prefix = reader.GetString(reader.GetOrdinal("prefix"));
                        string number = reader.GetString(reader.GetOrdinal("number"));
                        string year = reader.GetInt32(reader.GetOrdinal("year")).ToString();
                        string semester = reader.GetString(reader.GetOrdinal("semester"));
                        int hours = reader.GetInt32(reader.GetOrdinal("hours"));

                        table.AddCell(courseName);
                        table.AddCell(prefix + " " + number);
                        table.AddCell(year);
                        table.AddCell(semester);
                        table.AddCell(hours.ToString());
                        table.AddCell(grade);
                    }

                    doc.Add(table);
                    doc.Close();
                }
            }
        }

    }
}
