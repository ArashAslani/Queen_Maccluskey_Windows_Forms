using Quine_Maccluskey_Windows_Forms.Services;
using System.Diagnostics;

namespace Quine_Maccluskey_Windows_Forms
{
    public partial class MainForm : Form
    {
        QuineMaccluskeyAlgorithm mq = new();
        public MainForm()
        {
            InitializeComponent();
        }

        private void resultBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            int numberOfVaribles = Convert.ToInt32(this.variableNumericUpDown.Value);
            var result = mq.MQCalculator(this.MintermsTextBox.Text, this.DontCaresTextBox.Text, numberOfVaribles);
            this.ResultTextBox.Text = result.ToString();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = @"https://www.linkedin.com/in/arash-aslani-2002-ge", UseShellExecute = true });
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = @"https://github.com/ArashAslani/Quine_Mccluskey_Windows_Forms", UseShellExecute = true });
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // MainForm
        //    // 
        //    this.ClientSize = new System.Drawing.Size(284, 261);
        //    this.Name = "MainForm";
        //    this.Load += new System.EventHandler(MainForm_Load_1);
        //    this.ResumeLayout(false);
        //
        //}

        private void MainForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}