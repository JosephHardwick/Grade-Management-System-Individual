namespace Grade_Management_System_Individual
{
    partial class AddGrade
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
            label1 = new Label();
            StudentIDL = new Label();
            StudentIDTB = new TextBox();
            PrefixL = new Label();
            NumberL = new Label();
            SemesterL = new Label();
            YearL = new Label();
            GradeL = new Label();
            CRNL = new Label();
            GradeCB = new ComboBox();
            SemeterCB = new ComboBox();
            PrefixTB = new TextBox();
            NumberTB = new TextBox();
            YearTB = new TextBox();
            CRNTB = new TextBox();
            label2 = new Label();
            CRNRB = new RadioButton();
            NameRB = new RadioButton();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F);
            label1.Location = new Point(34, 18);
            label1.Name = "label1";
            label1.Size = new Size(181, 46);
            label1.TabIndex = 2;
            label1.Text = "Add Grade";
            // 
            // StudentIDL
            // 
            StudentIDL.AutoSize = true;
            StudentIDL.Location = new Point(133, 104);
            StudentIDL.Name = "StudentIDL";
            StudentIDL.Size = new Size(62, 15);
            StudentIDL.TabIndex = 4;
            StudentIDL.Text = "StudentID:";
            // 
            // StudentIDTB
            // 
            StudentIDTB.Location = new Point(133, 122);
            StudentIDTB.Name = "StudentIDTB";
            StudentIDTB.Size = new Size(101, 23);
            StudentIDTB.TabIndex = 5;
            // 
            // PrefixL
            // 
            PrefixL.AutoSize = true;
            PrefixL.Location = new Point(10, 104);
            PrefixL.Name = "PrefixL";
            PrefixL.Size = new Size(80, 15);
            PrefixL.TabIndex = 6;
            PrefixL.Text = "Course Prefix:";
            // 
            // NumberL
            // 
            NumberL.AutoSize = true;
            NumberL.Location = new Point(13, 161);
            NumberL.Name = "NumberL";
            NumberL.Size = new Size(94, 15);
            NumberL.TabIndex = 7;
            NumberL.Text = "Course Number:";
            // 
            // SemesterL
            // 
            SemesterL.AutoSize = true;
            SemesterL.Location = new Point(16, 223);
            SemesterL.Name = "SemesterL";
            SemesterL.Size = new Size(58, 15);
            SemesterL.TabIndex = 8;
            SemesterL.Text = "Semester:";
            // 
            // YearL
            // 
            YearL.AutoSize = true;
            YearL.Location = new Point(11, 277);
            YearL.Name = "YearL";
            YearL.Size = new Size(32, 15);
            YearL.TabIndex = 9;
            YearL.Text = "Year:";
            // 
            // GradeL
            // 
            GradeL.AutoSize = true;
            GradeL.Location = new Point(133, 170);
            GradeL.Name = "GradeL";
            GradeL.Size = new Size(38, 15);
            GradeL.TabIndex = 10;
            GradeL.Text = "Grade";
            // 
            // CRNL
            // 
            CRNL.AutoSize = true;
            CRNL.Location = new Point(10, 189);
            CRNL.Name = "CRNL";
            CRNL.Size = new Size(34, 15);
            CRNL.TabIndex = 11;
            CRNL.Text = "CRN:";
            // 
            // GradeCB
            // 
            GradeCB.FormattingEnabled = true;
            GradeCB.Items.AddRange(new object[] { "A", "B", "C", "D", "F" });
            GradeCB.Location = new Point(133, 188);
            GradeCB.Name = "GradeCB";
            GradeCB.Size = new Size(100, 23);
            GradeCB.TabIndex = 12;
            // 
            // SemeterCB
            // 
            SemeterCB.FormattingEnabled = true;
            SemeterCB.Items.AddRange(new object[] { "Fall", "Winter", "Spring", "Summer" });
            SemeterCB.Location = new Point(9, 241);
            SemeterCB.Name = "SemeterCB";
            SemeterCB.Size = new Size(101, 23);
            SemeterCB.TabIndex = 13;
            // 
            // PrefixTB
            // 
            PrefixTB.Location = new Point(9, 122);
            PrefixTB.Name = "PrefixTB";
            PrefixTB.Size = new Size(101, 23);
            PrefixTB.TabIndex = 14;
            // 
            // NumberTB
            // 
            NumberTB.Location = new Point(9, 179);
            NumberTB.Name = "NumberTB";
            NumberTB.Size = new Size(101, 23);
            NumberTB.TabIndex = 15;
            // 
            // YearTB
            // 
            YearTB.Location = new Point(10, 295);
            YearTB.Name = "YearTB";
            YearTB.Size = new Size(100, 23);
            YearTB.TabIndex = 16;
            // 
            // CRNTB
            // 
            CRNTB.Location = new Point(10, 208);
            CRNTB.Name = "CRNTB";
            CRNTB.Size = new Size(100, 23);
            CRNTB.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(133, 227);
            label2.Name = "label2";
            label2.Size = new Size(37, 28);
            label2.TabIndex = 3;
            label2.Text = "By:";
            // 
            // CRNRB
            // 
            CRNRB.AutoSize = true;
            CRNRB.Location = new Point(133, 283);
            CRNRB.Name = "CRNRB";
            CRNRB.Size = new Size(49, 19);
            CRNRB.TabIndex = 1;
            CRNRB.TabStop = true;
            CRNRB.Text = "CRN";
            CRNRB.UseVisualStyleBackColor = true;
            // 
            // NameRB
            // 
            NameRB.AutoSize = true;
            NameRB.Location = new Point(133, 258);
            NameRB.Name = "NameRB";
            NameRB.Size = new Size(97, 19);
            NameRB.TabIndex = 0;
            NameRB.TabStop = true;
            NameRB.Text = "Course Name";
            NameRB.UseVisualStyleBackColor = true;
            NameRB.CheckedChanged += NameRB_CheckedChanged;
            // 
            // button1
            // 
            button1.Location = new Point(159, 343);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 18;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(9, 343);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 19;
            button2.Text = "Back";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // AddGrade
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(244, 375);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(CRNTB);
            Controls.Add(YearTB);
            Controls.Add(NumberTB);
            Controls.Add(PrefixTB);
            Controls.Add(SemeterCB);
            Controls.Add(GradeCB);
            Controls.Add(CRNL);
            Controls.Add(GradeL);
            Controls.Add(YearL);
            Controls.Add(SemesterL);
            Controls.Add(NumberL);
            Controls.Add(PrefixL);
            Controls.Add(StudentIDTB);
            Controls.Add(StudentIDL);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(CRNRB);
            Controls.Add(NameRB);
            Name = "AddGrade";
            Text = "Add Grade";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label StudentIDL;
        private TextBox StudentIDTB;
        private Label PrefixL;
        private Label NumberL;
        private Label SemesterL;
        private Label YearL;
        private Label GradeL;
        private Label CRNL;
        private ComboBox GradeCB;
        private ComboBox SemeterCB;
        private TextBox PrefixTB;
        private TextBox NumberTB;
        private TextBox YearTB;
        private TextBox CRNTB;
        private Label label2;
        private RadioButton CRNRB;
        private RadioButton NameRB;
        private Button button1;
        private Button button2;
    }
}