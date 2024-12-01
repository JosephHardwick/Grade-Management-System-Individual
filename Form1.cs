namespace Grade_Management_System_Individual
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //add grade
        private void button1_Click(object sender, EventArgs e)
        {


            AddGrade addGrade = new AddGrade();
            addGrade.Show();
            this.Hide();
           
        }
        //edit/delete
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditDeleteSelect editDeleteSelect = new EditDeleteSelect();
            editDeleteSelect.Show();
        }
        //import
        private void button3_Click(object sender, EventArgs e)
        {
            ImportGrade importGrade = new ImportGrade();
            importGrade.Show();
        }

        //print transcript
        private void button4_Click_1(object sender, EventArgs e)
        {
            
            PrintTranscript printTranscript = new PrintTranscript();
            printTranscript.Show();
        }
    }
}
