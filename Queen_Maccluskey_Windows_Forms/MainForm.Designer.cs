namespace Queen_Maccluskey_Windows_Forms
{
    partial class MainForm
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
            this.MintermsTextBox = new System.Windows.Forms.TextBox();
            this.DontCaresTextBox = new System.Windows.Forms.TextBox();
            this.variableNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.submitBtn = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.ResultTextBox = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.variableNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // MintermsTextBox
            // 
            this.MintermsTextBox.Location = new System.Drawing.Point(121, 63);
            this.MintermsTextBox.Name = "MintermsTextBox";
            this.MintermsTextBox.Size = new System.Drawing.Size(656, 23);
            this.MintermsTextBox.TabIndex = 0;
            // 
            // DontCaresTextBox
            // 
            this.DontCaresTextBox.Location = new System.Drawing.Point(121, 92);
            this.DontCaresTextBox.Name = "DontCaresTextBox";
            this.DontCaresTextBox.Size = new System.Drawing.Size(656, 23);
            this.DontCaresTextBox.TabIndex = 2;
            // 
            // variableNumericUpDown
            // 
            this.variableNumericUpDown.Location = new System.Drawing.Point(121, 34);
            this.variableNumericUpDown.Name = "variableNumericUpDown";
            this.variableNumericUpDown.Size = new System.Drawing.Size(120, 23);
            this.variableNumericUpDown.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Don\'t care terms :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Minterms :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Number of values :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(454, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "This program simplifies your logical expressions using Quinn McCluskey\'s algorith" +
    "m.";
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(658, 34);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(119, 23);
            this.submitBtn.TabIndex = 8;
            this.submitBtn.Text = "Make it simple";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(88, 488);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(276, 15);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://www.linkedin.com/in/arash-aslani-2002-ge";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Result : ";
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Location = new System.Drawing.Point(121, 140);
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.Size = new System.Drawing.Size(656, 345);
            this.ResultTextBox.TabIndex = 11;
            this.ResultTextBox.Text = "";
            this.ResultTextBox.TextChanged += new System.EventHandler(this.resultBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 488);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Developed by\r";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(370, 488);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Github ";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(413, 488);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(375, 15);
            this.linkLabel2.TabIndex = 14;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "https://github.com/ArashAslani/Queen_Maccluskey_Windows_Forms";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 512);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.variableNumericUpDown);
            this.Controls.Add(this.DontCaresTextBox);
            this.Controls.Add(this.MintermsTextBox);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.variableNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox MintermsTextBox;
        private TextBox DontCaresTextBox;
        private NumericUpDown variableNumericUpDown;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button submitBtn;
        private LinkLabel linkLabel1;
        private Label label5;
        private RichTextBox ResultTextBox;
        private Label label6;
        private Label label7;
        private LinkLabel linkLabel2;
    }
}