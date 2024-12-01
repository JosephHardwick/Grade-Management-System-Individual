namespace Grade_Management_System_Individual
{
    partial class EditDeleteSelect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            Delete = new Button();
            tomenu = new Button();
            Searchforstudent = new Button();
            SIDLabel = new Label();
            SIDField = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(12, 71);
            listView1.Name = "listView1";
            listView1.Size = new Size(257, 277);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Course";
            columnHeader1.Width = 85;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Semester";
            columnHeader2.Width = 85;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Grade";
            columnHeader3.Width = 85;
            // 
            // Delete
            // 
            Delete.Location = new Point(194, 354);
            Delete.Name = "Delete";
            Delete.Size = new Size(75, 23);
            Delete.TabIndex = 1;
            Delete.Text = "Delete";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // tomenu
            // 
            tomenu.Location = new Point(12, 354);
            tomenu.Name = "tomenu";
            tomenu.Size = new Size(75, 23);
            tomenu.TabIndex = 3;
            tomenu.Text = "Back";
            tomenu.UseVisualStyleBackColor = true;
            tomenu.Click += tomenu_Click;
            // 
            // Searchforstudent
            // 
            Searchforstudent.Location = new Point(127, 18);
            Searchforstudent.Name = "Searchforstudent";
            Searchforstudent.Size = new Size(142, 41);
            Searchforstudent.TabIndex = 4;
            Searchforstudent.Text = "Search";
            Searchforstudent.UseVisualStyleBackColor = true;
            Searchforstudent.Click += Searchforstudent_Click;
            // 
            // SIDLabel
            // 
            SIDLabel.AutoSize = true;
            SIDLabel.Location = new Point(12, 18);
            SIDLabel.Name = "SIDLabel";
            SIDLabel.Size = new Size(65, 15);
            SIDLabel.TabIndex = 5;
            SIDLabel.Text = "Student ID:";
            // 
            // SIDField
            // 
            SIDField.Location = new Point(12, 36);
            SIDField.Name = "SIDField";
            SIDField.Size = new Size(100, 23);
            SIDField.TabIndex = 6;
            // 
            // button1
            // 
            button1.Location = new Point(102, 354);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 7;
            button1.Text = "Edit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // EditDeleteSelect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(279, 387);
            Controls.Add(button1);
            Controls.Add(SIDField);
            Controls.Add(SIDLabel);
            Controls.Add(Searchforstudent);
            Controls.Add(tomenu);
            Controls.Add(Delete);
            Controls.Add(listView1);
            Name = "EditDeleteSelect";
            Text = "EditDeleteSelect";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private Button Delete;
        private Button tomenu;
        private Button Searchforstudent;
        private Label SIDLabel;
        private TextBox SIDField;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Button button1;
    }
}