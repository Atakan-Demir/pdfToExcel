namespace pdfToExcel
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            button3 = new Button();
            label1 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(83, 25);
            button1.Name = "button1";
            button1.Size = new Size(191, 105);
            button1.TabIndex = 0;
            button1.Text = "pdf To excel";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(280, 25);
            button2.Name = "button2";
            button2.Size = new Size(176, 105);
            button2.TabIndex = 1;
            button2.Text = "pdf to excel (table)";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(220, 319);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(231, 23);
            textBox1.TabIndex = 2;
            // 
            // button3
            // 
            button3.Location = new Point(462, 25);
            button3.Name = "button3";
            button3.Size = new Size(176, 105);
            button3.TabIndex = 3;
            button3.Text = "pdf to excel (custom)";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Courier New", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(39, 319);
            label1.Name = "label1";
            label1.Size = new Size(175, 22);
            label1.TabIndex = 4;
            label1.Text = "İsim Soyisim : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Courier New", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(40, 349);
            label2.Name = "label2";
            label2.Size = new Size(98, 22);
            label2.TabIndex = 6;
            label2.Text = "Tutar : ";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(220, 348);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(231, 23);
            textBox2.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Courier New", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(41, 378);
            label3.Name = "label3";
            label3.Size = new Size(131, 22);
            label3.TabIndex = 8;
            label3.Text = "Komisyon : ";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(220, 377);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(231, 23);
            textBox3.TabIndex = 7;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(83, 179);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(555, 96);
            richTextBox1.TabIndex = 9;
            richTextBox1.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBox1);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private Button button3;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private RichTextBox richTextBox1;
    }
}